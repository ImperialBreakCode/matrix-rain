using MatrixRain.Base.Models;
using MatrixRain.Base.Models.Views;
using MatrixRain.Views;
using MatrixRain.Controllers;

namespace MatrixRain.Modules
{
    public class MatrixSpeedModule : SignalModuleBase
    {
        private readonly MatrixSpeedController controller;

        public MatrixSpeedModule(MatrixSpeedView view, MatrixSpeedController controller) : base(view)
        {
            this.controller = controller;
        }

        protected override void SignalHandler(object? sender, SignalArgs args)
        {

            switch (args.SignalMessage)
            {
                case "ChangeSpeed":
	                controller.ChangeSpeed(args.Data);
	                break;

                default:
                    break;
            }
        }
    }
}
