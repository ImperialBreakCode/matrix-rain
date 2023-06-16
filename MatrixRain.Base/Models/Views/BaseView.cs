using MatrixRain.Base.Constants;
using MatrixRain.Base.Interfaces;

namespace MatrixRain.Base.Models.Views
{
    public abstract class BaseView : IView
    {
        public BaseView()
        {
            BaseColor = ConsoleColors.BaseColor;
        }

        public ConsoleColor BaseColor { get; set; }

        protected void WriteLine<T>(T val)
        {
            Console.WriteLine(val);
        }

        protected void WriteLine()
        {
            Console.WriteLine();
        }

        protected void Write<T>(T val)
        {
            Console.Write(val);
        }

        public abstract void Display();
    }
}
