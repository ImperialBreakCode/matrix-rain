using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Models;
using MatrixRain.Services.Interfaces;
using ModuleGenerator.Tools.Attributes;

namespace MatrixRain.Controllers
{
    [SignalConnector("MatrixColorView")]
    public class MatrixColorController : Controller
    {
        private ISettingsService settingsService;

        public MatrixColorController(INavigation navigation, ISettingsService settingsService) : base(navigation)
        {
            this.settingsService = settingsService;
        }

        public void ChangeColor(string selection)
        {
            var settings = settingsService.GetSettings();

            ConsoleColor color;
            Enum.TryParse(selection, out color);
            settings.MatrixColor = color;

            settingsService.UpdateSettings(settings);
            settingsService.Refresh();

            Navigation.GoBack();
        }

        public void GoBack()
        {
            Navigation.GoBack();
        }
    }
}
