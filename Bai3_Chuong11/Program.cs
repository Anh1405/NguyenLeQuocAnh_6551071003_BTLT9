using System;
using System.IO;
using System.Windows.Forms;
using Serilog; // BẮT BUỘC phải có dòng này để nhận diện hàm .File()

namespace QLDaNgoaiApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Khởi tạo Serilog ghi log hệ thống ra thư mục Logs
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine("Logs", "log-.txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();

            // Đăng ký xử lý lỗi toàn cục
            Application.ThreadException += (sender, e) =>
            {
                Log.Error(e.Exception, "Lỗi UI Thread Exception chưa được bắt");
                MessageBox.Show("Đã xảy ra lỗi hệ thống, thông tin đã được ghi lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                {
                    Log.Error(ex, "Lỗi AppDomain Unhandled Exception");
                }
                MessageBox.Show("Lỗi hệ thống nghiêm trọng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            // Khởi chạy Form chính
            Application.Run(new FormChuyenDi());
        }
    }
}