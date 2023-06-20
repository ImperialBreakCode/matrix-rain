using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Models;
using MatrixRain.Services.Interfaces;
using ModuleGenerator.Tools.Attributes;

namespace MatrixRain.Controllers
{
    [SignalConnector("BrokenMatrixView")]
    public class BrokenMatrixController : Controller
    {
        private readonly ISettingsService settingsService;

        public BrokenMatrixController(INavigation navigation, ISettingsService settingsService) : base(navigation)
        {
            this.settingsService = settingsService;
        }

        public void ChangeColor(string data)
        {
            var settings = settingsService.GetSettings();

            ConsoleColor color;
            Enum.TryParse(data, out color);
            settings.BrokenMatrixColor = color;

            settingsService.UpdateSettings(settings);

            Navigation.GoBack();
        }

        public void GoBack()
        {
            Navigation.GoBack();
        }
    }
}
