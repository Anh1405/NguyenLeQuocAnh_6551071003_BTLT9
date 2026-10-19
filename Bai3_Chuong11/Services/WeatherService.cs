using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
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
                string langCode = isEnglish ? "en" : "vi";

                // BƯỚC 1: XỬ LÝ CHUỖI TIẾNG VIỆT CÓ DẤU
                string cleanSearchTerm = CleanAndUnaccentLocation(diaDiem);

                double lat = 11.9404; // Tọa độ mặc định (Đà Lạt)
                double lon = 108.4583;
                bool foundLocation = false;

                // Thử tìm theo chuỗi đã bỏ dấu & làm sạch tiền tố
                string geoUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(cleanSearchTerm)}&count=1&language={langCode}";
                var geoResponse = await _httpClient.GetFromJsonAsync<JsonElement>(geoUrl);

                if (geoResponse.TryGetProperty("results", out var results) && results.ValueKind == JsonValueKind.Array && results.GetArrayLength() > 0)
                {
                    var loc = results[0];
                    lat = loc.GetProperty("latitude").GetDouble();
                    lon = loc.GetProperty("longitude").GetDouble();
                    foundLocation = true;
                }
                else
                {
                    // Dự phòng: Thử lại với tên gốc
                    geoUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(diaDiem)}&count=1&language={langCode}";
                    geoResponse = await _httpClient.GetFromJsonAsync<JsonElement>(geoUrl);

                    if (geoResponse.TryGetProperty("results", out results) && results.ValueKind == JsonValueKind.Array && results.GetArrayLength() > 0)
                    {
                        var loc = results[0];
                        lat = loc.GetProperty("latitude").GetDouble();
                        lon = loc.GetProperty("longitude").GetDouble();
                        foundLocation = true;
                    }
                }

                if (!foundLocation)
                {
                    Log.Warning("Không tìm thấy tọa độ API cho '{DiaDiem}'. Sử dụng tọa độ mặc định để hiển thị.", diaDiem);
                }

                // BƯỚC 2: GỌI API THỜI TIẾT DÙNG TỌA ĐỘ
                string latStr = lat.ToString(CultureInfo.InvariantCulture);
                string lonStr = lon.ToString(CultureInfo.InvariantCulture);

                string forecastUrl = $"https://api.open-meteo.com/v1/forecast?latitude={latStr}&longitude={lonStr}&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max&timezone=auto&forecast_days=16";

                var weatherData = await _httpClient.GetFromJsonAsync<JsonElement>(forecastUrl);
                if (!weatherData.TryGetProperty("daily", out var daily)) return null;

                var times = daily.GetProperty("time").EnumerateArray().Select(x => x.GetString()).ToList();
                string targetDateStr = ngayDi.ToString("yyyy-MM-dd");
                int index = times.IndexOf(targetDateStr);

                // Nếu ngày ở quá khứ hoặc vượt quá 16 ngày, lấy ngày đầu tiên trong dải dự báo
                if (index == -1)
                {
                    index = 0;
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
                Log.Error(ex, "Lỗi chi tiết khi gọi API thời tiết cho địa điểm {DiaDiem}", diaDiem);
                throw;
            }
        }

        // HÀM XỬ LÝ CHUỖI TIẾNG VIỆT TOÀN DIỆN
        private static string CleanAndUnaccentLocation(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            string str = input.Trim();

            // 1. Loại bỏ các từ tiền tố hành chính hay gặp
            str = Regex.Replace(str, @"^(Thành phố|TP\.|Tỉnh|Huyện|Thị xã|Q\.|Quận)\s+", "", RegexOptions.IgnoreCase);

            // 2. Chuyển FormD để tách dấu Unicode
            string normalized = str.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char c in normalized)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            // 3. Thay thế Đ/đ và trả về FormC
            return sb.ToString()
                     .Normalize(NormalizationForm.FormC)
                     .Replace('Đ', 'D')
                     .Replace('đ', 'd')
                     .Trim();
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