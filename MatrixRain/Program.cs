using MatrixRain.Base.Models;
using MatrixRain.Controllers;
using MatrixRain.Views;

namespace MatrixRain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestView view = new TestView();
            Navigation nav = new Navigation();
            TestController testController = new TestController(nav);
            TestModule testModule = new TestModule(view, testController);

            while (true)
            {
                Console.Clear();
                testModule.Run();
            }

            
        }
    }
}