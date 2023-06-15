using MatrixRain.Base.Models.Views;

namespace MatrixRain.Base.Interfaces
{
    public interface ISignalView : IView
    {
        public void ChangeNavItemSelectionColor(ConsoleColor consoleColor);
        public void SubscribeToSignal(EventHandler<SignalArgs> eventHandler);
    }
}
