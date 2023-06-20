using MatrixRain.Base.Models;
using MatrixRain.Base.Models.Views;
using MatrixRain.Controllers;
using MatrixRain.Views;

namespace MatrixRain.Modules
{
    public class BrokenMatrixModule : SignalModuleBase
    {
        private readonly BrokenMatrixController controller;

        public BrokenMatrixModule(BrokenMatrixView view, BrokenMatrixController controller) : base(view)
        {
            this.controller = controller;
        }

        protected override void SignalHandler(object? sender, SignalArgs args)
        {

            switch (args.SignalMessage)
            {
                case "ChangeColor":
	                controller.ChangeColor(args.Data);
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
