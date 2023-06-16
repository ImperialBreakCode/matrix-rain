using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Models;

namespace MatrixRain.Controllers
{
    internal class TestController : Controller
    {
        public TestController(INavigation navigation) : base(navigation)
        {
        }

        public void Action()
        {
            Console.WriteLine("this is a console action");
        }
    }
}
