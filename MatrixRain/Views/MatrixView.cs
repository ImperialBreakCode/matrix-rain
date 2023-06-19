using MatrixRain.Base.Models.Views;
using MatrixRain.Constants;

namespace MatrixRain.Views
{
    public class MatrixView : View
    {

        protected override void DisplayView()
        {
            WriteLine("Matrix Rain Animation");
            WriteLine();
            WriteLine("Press s start the animation.");
            WriteLine("Press any key to stop the animation.");
            WriteLine("Press b to go back.");

            ReadKeys();
        }

        private void ReadKeys()
        {
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.S:
                    InvokeSignal("StartMatrix", null);
                    break;

                case ConsoleKey.B:
                    InvokeSignal("nav", Routes.Back);
                    break;

                default:
                    break;
            }
        }
    }
}
