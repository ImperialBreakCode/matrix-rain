using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Models.Internals;

namespace MatrixRain.Base.Models.Views
{
    public class View : BaseView, ISignalView
    {
        protected event EventHandler<SignalArgs> KeySignal;

        public View(INavigation navigation) : base(navigation)
        {
            NavSection = new NavSection();
        }
        
        public INavSection NavSection { get; set; }

        public sealed override void Display()
        {
            WriteLine(NavSection.NavSectionString());
            DisplayView();
        }

        public void SubscribeToSignal(EventHandler<SignalArgs> eventHandler)
        {
            KeySignal += eventHandler;
        }

        protected virtual void DisplayView()
        {
            WriteLine("This is a View");
        }

        public void ChangeNavItemSelectionColor(ConsoleColor consoleColor)
        {
            NavSection.SelectedNavItemColor = consoleColor;
        }
    }
}
