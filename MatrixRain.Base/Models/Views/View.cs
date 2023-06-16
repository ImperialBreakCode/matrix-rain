using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Models.Internals;

namespace MatrixRain.Base.Models.Views
{
    public class View : BaseView, ISignalView
    {
        private bool navIsInit;

        protected event EventHandler<SignalArgs> Signal;

        public View()
        {
            NavSection = new NavSection();
            navIsInit = false;
        }
        
        public INavSection NavSection { get; set; }

        public sealed override void Display()
        {
            

            if (!navIsInit)
            {
                InitNavItems();
                navIsInit = true;
            }

            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = BaseColor;

            NavSection.PrintNav();
            DisplayView();

            Console.ForegroundColor = currentColor;
        }

        public void SubscribeToSignal(EventHandler<SignalArgs> eventHandler)
        {
            Signal += eventHandler;
        }

        public void ChangeNavItemSelectionColor(ConsoleColor consoleColor)
        {
            NavSection.SelectedNavItemColor = consoleColor;
        }

        protected virtual void DisplayView()
        {
            WriteLine("This is a View");
        }

        protected virtual void InitNavItems()
        {
            throw new NotImplementedException();
        }

        protected void InvokeSignal(string message, string? data)
        {
            SignalArgs args = new SignalArgs(message, data);
            Signal?.Invoke(this, args);
        }
    }
}
