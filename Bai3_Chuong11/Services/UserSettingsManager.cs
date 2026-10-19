using System;
using System.IO;
using System.Text.Json;

namespace QLDaNgoaiApp.Services
{
    public class UserSettings
    {
        public string Language { get; set; } = "vi-VN";
    }

    public static class UserSettingsManager
    {
        private static readonly string _filePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "QLDaNgoai", "usersettings.json");

        public static UserSettings Load()
        {
            if (!File.Exists(_filePath)) return new UserSettings();
            try
            {
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<UserSettings>(json) ?? new UserSettings();
            }
            catch
            {
                return new UserSettings();
            }
        }

        public static void Save(UserSettings settings)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);
                string json = JsonSerializer.Serialize(settings);
                File.WriteAllText(_filePath, json);
            }
            catch { }
        }
    }
}