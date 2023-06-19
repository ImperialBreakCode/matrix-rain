using MatrixRain.Base.Interfaces;
using MatrixRain.BaseModels;

namespace MatrixRain
{
    public class MatrixRainApp : AppBase
    {
        private readonly IModuleSignalConainer modules;
        private readonly INavigation navigation;

        public MatrixRainApp(IModuleSignalConainer container, INavigation navigation)
        {
            modules = container;
            this.navigation = navigation;
        }

        protected override void PreRun()
        {
            navigation.AddView("Home");

            CanRun = true;
            IsRunning = true;
        }

        protected override void AppLoop()
        {
            while (IsRunning)
            {
                Console.Clear();
                modules.Container[navigation.CurrentView()].Run();
            }
        }
    }
}
