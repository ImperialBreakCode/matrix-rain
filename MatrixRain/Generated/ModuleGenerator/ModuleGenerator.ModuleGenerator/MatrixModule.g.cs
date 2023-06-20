using MatrixRain.Base.Models;
using MatrixRain.Base.Models.Views;
using MatrixRain.Views;
using MatrixRain.Controllers;

namespace MatrixRain.Modules
{
    public class MatrixModule : SignalModuleBase
    {
        private readonly MatrixController controller;

        public MatrixModule(MatrixView view, MatrixController controller) : base(view)
        {
            this.controller = controller;
        }

        protected override void SignalHandler(object? sender, SignalArgs args)
        {

            switch (args.SignalMessage)
            {
                case "nav":
	                controller.Nav(args.Data);
	                break;

                case "StartMatrix":
	                controller.StartMatrix();
	                break;

                default:
                    break;
            }
        }
    }
}
