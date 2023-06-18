using MatrixRain.Base.Models.Views;

namespace MatrixRain.Views
{
    public class TestView : View
    {
        
        protected override void DisplayView()
        {
            WriteLine();
            WriteLine("Test Content");

            var key = Console.ReadKey(true).Key.ToString();

            if (key == "Y")
            {
                InvokeSignal("wow", null);
            }
            else
            {
                InvokeSignal("smth", null);
            }
        }
    }
}
