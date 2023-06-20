using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Models;
using MatrixRain.Services.Interfaces;
using ModuleGenerator.Tools.Attributes;

namespace MatrixRain.Controllers
{
    [SignalConnector("MatrixSpeedView")]
    public class MatrixSpeedController : Controller
    {
        private readonly ISettingsService settingsService;

        public MatrixSpeedController(INavigation navigation, ISettingsService settingsService) : base(navigation)
        {
            this.settingsService = settingsService;
        }

        public void ChangeSpeed(string speed)
        {
            int speedNum;
            if (speed is not null && int.TryParse(speed, out speedNum) && speedNum >= 20 && speedNum <= 500)
            {
                var settings = settingsService.GetSettings();
                settings.MatrixRainSpeed = speedNum;
                settingsService.UpdateSettings(settings);

                Navigation.GoBack();
            }
            else
            {
                Utils.PrintError("Speed should be a number between 20 and 500");

                Console.WriteLine("Press t to try again");
                Console.WriteLine("Press any other key to go back");

                if (Console.ReadKey(true).Key != ConsoleKey.T)
                {
                    Navigation.GoBack();
                }
            }
        }
    }
}
