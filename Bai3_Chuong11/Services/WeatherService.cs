using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Serilog;

namespace QLDaNgoaiApp.Services
{
    public class WeatherForecastResult
    {
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int RainProbability { get; set; }
        public string Description { get; set; } = string.Empty;
        public int WeatherCode { get; set; }
    }

    public class WeatherService
    {
        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        static WeatherService()
        {
            if (!_httpClient.DefaultRequestHeaders.Contains("User-Agent"))
            {
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppWinForms/1.0");
            }
        }

        public async Task<WeatherForecastResult?> GetWeatherForecastAsync(string diaDiem, DateTime ngayDi, bool isEnglish = false)
        {
            try
            {
                // Bước 1: Geocoding - Lấy tọa độ từ tên địa danh
                string langCode = isEnglish ? "en" : "vi";
                string geoUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(diaDiem)}&count=1&language={langCode}";

                var geoResponse = await _httpClient.GetFromJsonAsync<JsonElement>(geoUrl);

                if (!geoResponse.TryGetProperty("results", out var results) || results.ValueKind != JsonValueKind.Array || results.GetArrayLength() == 0)
                {
                    Log.Warning("Không tìm thấy tọa độ cho địa danh: {DiaDiem}", diaDiem);
                    return null;
                }

                var loc = results[0];
                double lat = loc.GetProperty("latitude").GetDouble();
                double lon = loc.GetProperty("longitude").GetDouble();

                // ĐIỂM MẤU CHỐC: Ép định dạng vĩ độ / kinh độ về InvariantCulture (dùng dấu chấm .)
                string latStr = lat.ToString(CultureInfo.InvariantCulture);
                string lonStr = lon.ToString(CultureInfo.InvariantCulture);

                // Bước 2: Gọi API thời tiết 16 ngày
                string forecastUrl = $"https://api.open-meteo.com/v1/forecast?latitude={latStr}&longitude={lonStr}&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max&timezone=auto&forecast_days=16";

                var weatherData = await _httpClient.GetFromJsonAsync<JsonElement>(forecastUrl);
                if (!weatherData.TryGetProperty("daily", out var daily))
                {
                    return null;
                }

                var times = daily.GetProperty("time").EnumerateArray().Select(x => x.GetString()).ToList();
                string targetDateStr = ngayDi.ToString("yyyy-MM-dd");
                int index = times.IndexOf(targetDateStr);

                if (index == -1)
                {
                    Log.Warning("Ngày đi {NgayDi} vượt quá dải dự báo 16 ngày", targetDateStr);
                    return null;
                }

                int code = daily.GetProperty("weather_code")[index].GetInt32();
                double tempMin = daily.GetProperty("temperature_2m_min")[index].GetDouble();
                double tempMax = daily.GetProperty("temperature_2m_max")[index].GetDouble();

                int rainProb = 0;
                if (daily.TryGetProperty("precipitation_probability_max", out var rainArray) && rainArray.GetArrayLength() > index)
                {
                    rainProb = rainArray[index].GetInt32();
                }

                return new WeatherForecastResult
                {
                    TempMin = Math.Round(tempMin, 1),
                    TempMax = Math.Round(tempMax, 1),
                    RainProbability = rainProb,
                    WeatherCode = code,
                    Description = MapWeatherCode(code, isEnglish)
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi chi tiết gọi API cho địa điểm {DiaDiem}", diaDiem);
                throw;
            }
        }

        private string MapWeatherCode(int code, bool isEnglish)
        {
            if (isEnglish)
            {
                return code switch
                {
                    0 => "Clear sky",
                    1 or 2 or 3 => "Partly cloudy",
                    45 or 48 => "Foggy",
                    >= 51 and <= 67 or >= 80 and <= 82 => "Light rain showers",
                    >= 95 and <= 99 => "Thunderstorm",
                    _ => "Overcast"
                };
            }

            return code switch
            {
                0 => "Trời quang",
                1 or 2 or 3 => "Có mây",
                45 or 48 => "Sương mù",
                >= 51 and <= 67 or >= 80 and <= 82 => "Mưa rào nhẹ",
                >= 95 and <= 99 => "Có dông",
                _ => "Nhiều mây"
            };
        }
    }
}