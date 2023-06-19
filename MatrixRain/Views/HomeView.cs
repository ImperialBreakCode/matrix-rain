using MatrixRain.Base.Models.Views;
using MatrixRain.Constants;

namespace MatrixRain.Views
{
    public class HomeView : View
    {
        protected override void BeforeNav()
        {
            WriteLine("MATRIX Digital Rain v3");
            WriteLine();
            WriteLine();
            WriteLine("\tMENU");
            WriteLine();
        }

        protected override void InitNavItems()
        {
            NavSection.AddNavItem(Routes.Matrix, "Matrix Rain Animation");
            NavSection.AddNavItem(Routes.MatrixVirus, "Matrix-virus animation cycle (~33 seconds for a full animation cycle)");
        }

        protected override void DisplayView()
        {
            WriteLine();
            WriteLine();
            WriteLine("Use up and down arrow keys to navigate in the menu above");
            WriteLine("Press ENTER to select a menu item.");
            //WriteLine("Press x exit the program.");

            ReadKeys();
        }

        private void ReadKeys()
        {
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.Enter:
                    InvokeSignal("nav", NavSection.CurrentItemName());
                    break;

                case ConsoleKey.UpArrow:
                    NavSection.Up();
                    break;

                case ConsoleKey.DownArrow:
                    NavSection.Down();
                    break;

                default:
                    break;
            }
        }
    }
}
