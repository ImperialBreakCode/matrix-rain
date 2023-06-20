using MatrixRain.Views.Common;

namespace MatrixRain.Views
{
    public class InterfaceColorView : ChangeColorView
    {
        protected override void BeforeNav()
        {
            WriteLine();
            WriteLine("\tChange ui text color".ToUpper());
            WriteLine();
        }
    }
}
