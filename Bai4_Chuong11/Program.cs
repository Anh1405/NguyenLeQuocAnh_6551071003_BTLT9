using Serilog;
using System;
using System.IO;
using System.Windows.Forms;
using Log = Serilog.Log; // Khai báo rõ ràng Alias để tránh xung đột CS0104

namespace QLTraSuaApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Log.Logger = new Serilog.LoggerConfiguration()
                .WriteTo.File(Path.Combine("Logs", "log-.txt"), rollingInterval: Serilog.RollingInterval.Day)
                .CreateLogger();

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.ThreadException += (s, e) =>
            {
                Log.Error(e.Exception, "Lỗi UI Thread Exception trong ứng dụng");
                MessageBox.Show("Đã xảy ra lỗi hệ thống, thông tin đã được ghi lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                {
                    Log.Error(ex, "Lỗi AppDomain Unhandled Exception");
                }
                MessageBox.Show("Lỗi hệ thống nghiêm trọng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            Application.Run(new FormBanHang());
        }
    }
}