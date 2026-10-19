using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Log = Serilog.Log; // Khai báo rõ ràng Alias để tránh xung đột CS0104

namespace QLTraSuaApp.Services
{
    public class VietQrService
    {
        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        static VietQrService()
        {
            if (!_httpClient.DefaultRequestHeaders.Contains("User-Agent"))
            {
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppWinForms/1.0");
            }
        }

        public async Task<Image?> GenerateQrCodeAsync(string bankId, string accountNo, string template, decimal amount, string addInfo, string accountName)
        {
            try
            {
                string url = $"https://img.vietqr.io/image/{bankId}-{accountNo}-{template}.png?" +
                             $"amount={Convert.ToInt64(amount)}&addInfo={Uri.EscapeDataString(addInfo)}&accountName={Uri.EscapeDataString(accountName)}";

                byte[] bytes = await _httpClient.GetByteArrayAsync(url);
                using var ms = new MemoryStream(bytes);
                return Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi tải mã VietQR cho thông tin đơn: {AddInfo}", addInfo);
                return null;
            }
        }
    }
}