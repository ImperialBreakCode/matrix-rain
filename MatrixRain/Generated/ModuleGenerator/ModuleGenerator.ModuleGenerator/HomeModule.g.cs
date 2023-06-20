using MatrixRain.Base.Models;
using MatrixRain.Base.Models.Views;
using MatrixRain.Views;
using MatrixRain.Controllers;

namespace MatrixRain.Modules
{
    public class HomeModule : SignalModuleBase
    {
        private readonly HomeController controller;

        public HomeModule(HomeView view, HomeController controller) : base(view)
        {
            this.controller = controller;
        }

        protected override void SignalHandler(object? sender, SignalArgs args)
        {

            switch (args.SignalMessage)
            {
                case "nav":
	                controller.ChangeNav(args.Data);
	                break;

                default:
                    break;
            }
        }
    }
}
