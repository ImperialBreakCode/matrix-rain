using MatrixRain.Models;

namespace MatrixRain.Services.Interfaces
{
    public interface ISettingsService
    {
        public Settings GetSettings();
        public void UpdateSettings(Settings settings);
        public void RestoreDefault();
        public void EnsureSettings();
        public void Refresh();
        public void SetRefreshAction(Action action);
    }
}
