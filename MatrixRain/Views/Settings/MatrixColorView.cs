using MatrixRain.Views.Common;

namespace MatrixRain.Views
{
    public class MatrixColorView : ChangeColorView
    {
        protected override void BeforeNav()
        {
            WriteLine();
            WriteLine("\tChange matrix animation color".ToUpper());
            WriteLine();
        }

        protected override void InitNavItems()
        {
            foreach (var color in Enum.GetNames(typeof(ConsoleColor)))
            {
                if (color == "Black" || !color.StartsWith("Dark"))
                {
                    continue;
                }

                NavSection.AddNavItem(color, color.Remove(0, 4));
            }
        }
    }
}
