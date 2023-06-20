using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Models;
using MatrixRain.Constants;
using MatrixRain.Services.Interfaces;
using ModuleGenerator.Tools.Attributes;

namespace MatrixRain.Controllers
{
    [SignalConnector("SettingsView")]
    public class SettingsController : Controller
    {
        private ISettingsService settingsService;
        public SettingsController(INavigation navigation, ISettingsService settingsService) 
            : base(navigation)
        {
            this.settingsService = settingsService;
        }

        public void ResetSettings()
        {
            settingsService.RestoreDefault();
            settingsService.Refresh();
        }

        [ForSignal("nav")]
        public void NavigationRouter(string data)
        {
            if (data == Routes.Back)
            {
                Navigation.GoBack();
            }
            else
            {
                Navigation.AddView(data);
            }
        }
    }
}
