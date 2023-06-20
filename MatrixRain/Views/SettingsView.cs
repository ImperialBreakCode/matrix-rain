using MatrixRain.Base.Models.Views;
using MatrixRain.Constants;

namespace MatrixRain.Views
{
    public class SettingsView : View
    {
        private const string ResetSettingsSelection = "ResetSettings";

        protected override void BeforeNav()
        {
            WriteLine();
            WriteLine("\tSETTINGS");
            WriteLine();
        }

        protected override void InitNavItems()
        {
            NavSection.AddNavItem(Routes.MatrixSpeed, "Change matrix animation speed.");
            NavSection.AddNavItem(Routes.MatrixColor, "Change matrix animation color.");
            NavSection.AddNavItem(Routes.MatrixVirusSettingsView, "Matrix-virus animation settings.");
            NavSection.AddNavItem(Routes.InterfaceColor, "Change text ui color.");
            NavSection.AddNavItem(Routes.SelectionColor, "Change menu selection color.");
            NavSection.AddNavItem(ResetSettingsSelection, "Reset default settings");
            NavSection.AddNavItem(Routes.Back, "Go back");
        }

        protected override void DisplayView()
        {
            WriteLine();
            Nav();
        }

        private void Nav()
        {
            var key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.DownArrow:
                    NavSection.Down();
                    break;

                case ConsoleKey.UpArrow:
                    NavSection.Up();
                    break;

                case ConsoleKey.Enter:
                    Select(NavSection.CurrentItemName());
                    break;

                default:
                    break;
            }
        }

        private void Select(string selection)
        {
            if (selection == ResetSettingsSelection)
            {
                Console.Clear();
                WriteLine("Are you sure you want to reset the settings?");
                WriteLine("Press y for yes or n for no");

                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    InvokeSignal(ResetSettingsSelection, null);
                }
            }
            else
            {
                InvokeSignal("nav", selection);
            }
        }
    }
}
