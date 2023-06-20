using MatrixRain.Views.Common;
using ModuleGenerator.Tools.Attributes;

namespace MatrixRain.Views
{
    public class SelectionColorView : ChangeColorView
    {
        protected override void BeforeNav()
        {
            WriteLine();
            WriteLine("\tChange menu selection color".ToUpper());
            WriteLine();
        }
    }
}
