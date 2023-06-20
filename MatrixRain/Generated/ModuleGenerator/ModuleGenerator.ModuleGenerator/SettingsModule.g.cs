using MatrixRain.Base.Models;
using MatrixRain.Base.Models.Views;
using MatrixRain.Views;
using MatrixRain.Controllers;

namespace MatrixRain.Modules
{
    public class SettingsModule : SignalModuleBase
    {
        private readonly SettingsController controller;

        public SettingsModule(SettingsView view, SettingsController controller) : base(view)
        {
            this.controller = controller;
        }

        protected override void SignalHandler(object? sender, SignalArgs args)
        {

            switch (args.SignalMessage)
            {
                case "ResetSettings":
	                controller.ResetSettings();
	                break;
                case "nav":
	                controller.NavigationRouter(args.Data);
	                break;

                default:
                    break;
            }
        }
    }
}
