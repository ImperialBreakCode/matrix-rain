using MatrixRain.Models;
using MatrixRain.Services.Interfaces;
using Newtonsoft.Json;
using MatrixRain.Interfaces;

namespace MatrixRain.Services
{
    public class SettingsService : ISettingsService
    {
        private const string SettingsFolder = "Settings";
        private const string SettingsFile = "Settings.json";
        private readonly ISettingsFactory settingsFactory;

        private string SettingsPath => Path.Combine(SettingsFolder, SettingsFile);

        public SettingsService(ISettingsFactory settingsFactory)
        {
            this.settingsFactory = settingsFactory;
        }

        public void EnsureSettings()
        {
            Directory.CreateDirectory(SettingsFolder);

            if (!File.Exists(SettingsPath))
            {
                string json = JsonConvert.SerializeObject(settingsFactory.CreateSettings());
                File.WriteAllText(SettingsPath, json);
            }
        }

        public Settings GetSettings()
        {
            string json = File.ReadAllText(SettingsPath);
            var settings = JsonConvert.DeserializeObject<Settings>(json);

            if (settings is null)
            {
                throw new MatrixRainException("Settings file is corrupted. Please close and start the application again.");
            }

            return settings;
        }

        public void RestoreDefault()
        {
            string json = JsonConvert.SerializeObject(settingsFactory.CreateSettings());
            File.WriteAllText(SettingsPath, json);
        }

        public void UpdateSettings(Settings settings)
        {
            string json = JsonConvert.SerializeObject(settings);
            File.WriteAllText(SettingsPath, json);
        }
    }
}
