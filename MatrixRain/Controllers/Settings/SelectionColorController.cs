using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Models;
using MatrixRain.Services.Interfaces;
using ModuleGenerator.Tools.Attributes;

namespace MatrixRain.Controllers
{
    [SignalConnector("SelectionColorView")]
    public class SelectionColorController : Controller
    {
        private ISettingsService settingsService;

        public SelectionColorController(INavigation navigation, ISettingsService settingsService) : base(navigation)
        {
            this.settingsService = settingsService;
        }

        public void GoBack()
        {
            Navigation.GoBack();
        }

        public void ChangeColor(string selection)
        {
            var settings = settingsService.GetSettings();

            ConsoleColor color;
            Enum.TryParse(selection, out color);
            settings.SelectionColor = color;

            settingsService.UpdateSettings(settings);
            settingsService.Refresh();
        }
    }
}
