using MatrixRain.Base.Models;
using MatrixRain.Base.Models.Views;
using MatrixRain.Views;
using MatrixRain.Controllers;

namespace MatrixRain.Modules
{
    public class SelectionColorModule : SignalModuleBase
    {
        private readonly SelectionColorController controller;

        public SelectionColorModule(SelectionColorView view, SelectionColorController controller) : base(view)
        {
            this.controller = controller;
        }

        protected override void SignalHandler(object? sender, SignalArgs args)
        {

            switch (args.SignalMessage)
            {
                case "GoBack":
	                controller.GoBack();
	                break;
                case "ChangeColor":
	                controller.ChangeColor(args.Data);
	                break;

                default:
                    break;
            }
        }
    }
}
