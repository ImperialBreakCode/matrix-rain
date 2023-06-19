using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Models;
using ModuleGenerator.Tools.Attributes;

namespace MatrixRain.Controllers
{
    [SignalConnector("HomeView")]
    public class HomeController : Controller
    {
        public HomeController(INavigation navigation) : base(navigation)
        {
        }

        [ForSignal("nav")]
        public void ChangeNav(string data)
        {
            Navigation.AddView(data);
        }
    }
}
