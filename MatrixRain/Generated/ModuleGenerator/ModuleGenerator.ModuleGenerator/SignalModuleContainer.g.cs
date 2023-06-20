using MatrixRain.Base.Interfaces;
using MatrixRain.Modules;
using MatrixRain;

namespace MatrixRain
{
    public class SignalModuleContainer : IModuleSignalConainer
    {
        private IDictionary<string, ISignalModule> container;

        public SignalModuleContainer(HomeModule module0, MatrixAnimationModule module1, MatrixModule module2, BrokenMatrixModule module3, MatrixVirusSettingsModule module4, RegularMatrixModule module5, SettingsModule module6, InterfaceColorModule module7, MatrixColorModule module8, MatrixSpeedModule module9, SelectionColorModule module10)
        {
            container = new Dictionary<string, ISignalModule>();
            container.Add("Home", module0);
            container.Add("MatrixAnimation", module1);
            container.Add("Matrix", module2);
            container.Add("BrokenMatrix", module3);
            container.Add("MatrixVirusSettings", module4);
            container.Add("RegularMatrix", module5);
            container.Add("Settings", module6);
            container.Add("InterfaceColor", module7);
            container.Add("MatrixColor", module8);
            container.Add("MatrixSpeed", module9);
            container.Add("SelectionColor", module10);

        }

        public IDictionary<string, ISignalModule> Container => container;
    }
}