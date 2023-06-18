using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Models.Views;

namespace MatrixRain.Base.Models
{
    public abstract class SignalModuleBase : ISignalModule
    {
        private readonly ISignalView signalView;

        public SignalModuleBase(ISignalView view)
        {
            signalView = view;
            View.SubscribeToSignal(SignalHandler);
        }

        public ISignalView View => signalView;

        protected abstract void SignalHandler(object? sender, SignalArgs args);
        public void Run()
        {
            View.Display();
        }
    }
}
