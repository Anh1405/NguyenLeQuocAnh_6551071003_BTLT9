using System;
using System.IO;
using System.Windows.Forms;
using Serilog;

namespace QLNhaTroApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 1. Khởi tạo Serilog ghi log hệ thống ra thư mục Logs
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine("Logs", "log-.txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();

            // 2. Đăng ký xử lý lỗi toàn cục BẮT BUỘC trước khi tạo Form
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.ThreadException += (sender, e) =>
            {
                Log.Error(e.Exception, "Lỗi UI Thread Exception chưa được bắt");
                MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại.", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                {
                    Log.Error(ex, "Lỗi AppDomain Unhandled Exception chưa được bắt");
                }
                MessageBox.Show("Đã xảy ra lỗi hệ thống nghiêm trọng!", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            // 3. Khởi chạy Form chính
            Application.Run(new FormKhachThue());
        }
    }
}