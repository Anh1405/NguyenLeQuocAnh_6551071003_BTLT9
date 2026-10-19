using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QLNhaTroApp.Services
{
    public class ProvinceDto
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("wards")]
        public List<WardDto>? Wards { get; set; }
    }

    public class WardDto
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }

    public class AddressApiService
    {
        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        public async Task<List<ProvinceDto>> GetProvincesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ProvinceDto>>("https://provinces.open-api.vn/api/v2/");
            return response ?? new List<ProvinceDto>();
        }

        public async Task<List<WardDto>> GetWardsAsync(int provinceCode)
        {
            var response = await _httpClient.GetFromJsonAsync<ProvinceDto>($"https://provinces.open-api.vn/api/v2/p/{provinceCode}?depth=2");
            return response?.Wards ?? new List<WardDto>();
        }
    }
}