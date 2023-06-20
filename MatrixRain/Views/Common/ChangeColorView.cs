using MatrixRain.Base.Models.Views;

namespace MatrixRain.Views.Common
{
    public class ChangeColorView : View
    {
        protected override void InitNavItems()
        {
            foreach (var color in Enum.GetNames(typeof(ConsoleColor)))
            {
                if (color == "Black")
                {
                    continue;
                }

                string displayString = color.StartsWith("Dark") ? "Dark " + color.Remove(0, 4) : color;
                NavSection.AddNavItem(color, displayString);
            }
        }

        protected override void DisplayView()
        {
            WriteLine();
            WriteLine("Use up and down arrow keys to navigate and press ENTER to accept color.");
            WriteLine("Press b go to back");

            Nav();
        }

        protected void Nav()
        {
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.DownArrow:
                    NavSection.Down();
                    break;

                case ConsoleKey.UpArrow:
                    NavSection.Up();
                    break;

                case ConsoleKey.Enter:
                    SelectItem(NavSection.CurrentItemName());
                    break;

                case ConsoleKey.B:
                    InvokeSignal("GoBack", null);
                    break;

                default:
                    break;
            }
        }

        private void SelectItem(string selection)
        {
            InvokeSignal("ChangeColor", selection);
        }
    }
}
