using MatrixRain.Base.Interfaces;

namespace MatrixRain.Base.Models
{
    public abstract class Controller
    {
        private readonly INavigation navigation;

        public Controller(INavigation navigation)
        {
            this.navigation = navigation;
        }

        protected INavigation Navigation => navigation;
    }
}
