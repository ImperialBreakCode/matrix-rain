using MatrixRain.Interfaces;

namespace MatrixRain.BaseModels
{
    public abstract class AppBase : IMatrixRainApp
    {
        public AppBase()
        {
            CanRun = false;
            IsRunning = false;
        }

        protected bool CanRun { get; set; }
        protected bool IsRunning { get; set; }

        public void Run()
        {
            PreRun();
            AppLoop();
        }

        protected abstract void PreRun();
        protected abstract void AppLoop();
    }
}
