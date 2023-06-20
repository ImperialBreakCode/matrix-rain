using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Models;
using MatrixRain.Services.Interfaces;
using ModuleGenerator.Tools.Attributes;

namespace MatrixRain.Controllers
{
    [SignalConnector("InterfaceColorView")]
    public class InterfaceColorController : Controller
    {
        private ISettingsService settingsService;

        public InterfaceColorController(INavigation navigation, ISettingsService settingsService) : base(navigation)
        {
            this.settingsService = settingsService;
        }

        public void ChangeColor(string selection)
        {
            var settings = settingsService.GetSettings();

            ConsoleColor color;
            Enum.TryParse(selection, out color);
            settings.InterfaceColor = color;

            settingsService.UpdateSettings(settings);
            settingsService.Refresh();
        }

        public void GoBack()
        {
            Navigation.GoBack();
        }
    }
}
