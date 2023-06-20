using MatrixRain.Base.Models;
using MatrixRain.Base.Models.Views;
using MatrixRain.Views;
using MatrixRain.Controllers;

namespace MatrixRain.Modules
{
    public class RegularMatrixModule : SignalModuleBase
    {
        private readonly RegularMatrixController controller;

        public RegularMatrixModule(RegularMatrixView view, RegularMatrixController controller) : base(view)
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
