using MatrixRain.Base.Models.Views;

namespace MatrixRain.Views
{
    internal class TestView : View
    {
        
        protected override void DisplayView()
        {
            WriteLine();
            WriteLine("Test Content");

            var key = Console.ReadKey().Key.ToString();

            if (key == "y")
            {
                InvokeSignal("ActionOne", null);
            }
            else
            {
                InvokeSignal("smth", null);
            }
        }
    }
}
