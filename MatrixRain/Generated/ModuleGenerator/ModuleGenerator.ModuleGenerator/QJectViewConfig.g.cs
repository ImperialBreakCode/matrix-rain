using MatrixRain.Views;
using QJect;
using QJect.Core;

namespace MatrixRain.Configs
{
    public class QJectViewConfig : QJectConfig
    {
        public override void Configure(IDependencyBuilder builder)
        {
            builder.RegisterSingleton<HomeView>();
            builder.RegisterSingleton<MatrixAnimationView>();
            builder.RegisterSingleton<MatrixView>();
            builder.RegisterSingleton<BrokenMatrixView>();
            builder.RegisterSingleton<MatrixVirusSettingsView>();
            builder.RegisterSingleton<RegularMatrixView>();
            builder.RegisterSingleton<SettingsView>();
            builder.RegisterSingleton<InterfaceColorView>();
            builder.RegisterSingleton<MatrixColorView>();
            builder.RegisterSingleton<MatrixSpeedView>();
            builder.RegisterSingleton<SelectionColorView>();

        }
    }
}