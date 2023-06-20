using MatrixRain.Base.Models;
using MatrixRain.Base.Models.Views;
using MatrixRain.Views;
using MatrixRain.Controllers;

namespace MatrixRain.Modules
{
    public class MatrixVirusSettingsModule : SignalModuleBase
    {
        private readonly MatrixVirusSettingsController controller;

        public MatrixVirusSettingsModule(MatrixVirusSettingsView view, MatrixVirusSettingsController controller) : base(view)
        {
            this.controller = controller;
        }

        protected override void SignalHandler(object? sender, SignalArgs args)
        {

            switch (args.SignalMessage)
            {
                case "ChangeText":
	                controller.ChangeText(args.Data);
	                break;
                case "ChangeSettings":
	                controller.ChangeSettings(args.Data);
	                break;
                case "nav":
	                controller.Nav(args.Data);
	                break;
                case "GoBack":
	                controller.GoBack();
	                break;

                default:
                    break;
            }
        }
    }
}
