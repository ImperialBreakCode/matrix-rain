using MatrixRain.Base.Models.Views;

namespace MatrixRain.Views
{
    public class MatrixSpeedView : View
    {
        protected override void DisplayView()
        {
            WriteLine();
            WriteLine("Type the speed of the matrix animation then press enter to confirm");
            Write("a number between 20 - 500: ");

            Console.CursorVisible = true;

            string? numStr = Console.ReadLine();

            Console.CursorVisible = false;

            InvokeSignal("ChangeSpeed", numStr);
        }
    }
}
