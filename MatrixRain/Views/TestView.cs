using MatrixRain.Base.Models.Views;

namespace MatrixRain.Views
{
    internal class TestView : View
    {
        protected override void InitNavItems()
        {
            NavSection.AddNavItem("1", "One");
            NavSection.AddNavItem("2", "Two");
            NavSection.AddNavItem("3", "Three");
        }

        protected override void DisplayView()
        {
            WriteLine("");
            WriteLine("Test Content");

            Nav();
        }

        private void Nav()
        {
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.UpArrow)
            {
                NavSection.Up();
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                NavSection.Down();
            }
        }
    }
}
