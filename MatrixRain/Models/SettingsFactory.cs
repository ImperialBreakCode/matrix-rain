using MatrixRain.Constants;
using MatrixRain.Interfaces;

namespace MatrixRain.Models
{
    public class SettingsFactory : ISettingsFactory
    {
        public Settings CreateSettings()
        {
            return new Settings()
            {
                InterfaceColor = DefaultSettings.InterfaceColor,
                SelectionColor = DefaultSettings.SelectionColor,
                MatrixColor = DefaultSettings.MatrixColor,
                MatrixRainSpeed = DefaultSettings.MatrixSpeed,
                BrokenMatrixColor = DefaultSettings.BrokenMatrixColor,
                MatrixVirusColor = DefaultSettings.MatrixVirusColor,
                SkullColor = DefaultSettings.SkullColor,
                TextColor = DefaultSettings.TextColor
            };
        }
    }
}
