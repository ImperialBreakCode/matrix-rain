using MatrixRain.Base.Models;
using MatrixRain.Base.Models.Views;
using MatrixRain.Views;
using MatrixRain.Controllers;

namespace MatrixRain.Modules
{
    public class MatrixAnimationModule : SignalModuleBase
    {
        private readonly MatrixAnimationController controller;

        public MatrixAnimationModule(MatrixAnimationView view, MatrixAnimationController controller) : base(view)
        {
            this.controller = controller;
        }

        protected override void SignalHandler(object? sender, SignalArgs args)
        {

            switch (args.SignalMessage)
            {
                case "StartMatrix":
	                controller.StartMatrix();
	                break;

                case "nav":
	                controller.GoBack(args.Data);
	                break;

                default:
                    break;
            }
        }
    }
}
