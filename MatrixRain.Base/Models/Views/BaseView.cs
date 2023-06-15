using MatrixRain.Base.Constants;
using MatrixRain.Base.Interfaces;

namespace MatrixRain.Base.Models.Views
{
    public abstract class BaseView : IView
    {
        private readonly INavigation navigation;

        public BaseView(INavigation navigation)
        {
            this.navigation = navigation;
            BaseColor = ConsoleColors.BaseColor;
        }

        public ConsoleColor BaseColor { get; set; }
        protected INavigation Navigation => navigation;

        protected void WriteLine<T>(T val)
        {
            Console.WriteLine(val);
        }

        protected void Write<T>(T val)
        {
            Console.Write(val);
        }

        public abstract void Display();
    }
}
