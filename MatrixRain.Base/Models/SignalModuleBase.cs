using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Models.Views;

namespace MatrixRain.Base.Models
{
    public abstract class SignalModuleBase : IModule
    {
        public SignalModuleBase(ISignalView view)
        {
            View = view;
            View.SubscribeToSignal(SignalHandler);
        }

        protected ISignalView View { get; set; }

        protected abstract void SignalHandler(object? sender, SignalArgs args);
        public void Run()
        {
            View.Display();
        }
    }
}
