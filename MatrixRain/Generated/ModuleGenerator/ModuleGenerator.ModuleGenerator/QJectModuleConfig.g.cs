using MatrixRain.Modules;
using QJect;
using QJect.Core;

namespace MatrixRain.Configs
{
    public class QJectModuleConfig : QJectConfig
    {
        public override void Configure(IDependencyBuilder builder)
        {
            builder.RegisterSingleton<HomeModule>();
            builder.RegisterSingleton<MatrixAnimationModule>();
            builder.RegisterSingleton<MatrixModule>();
            builder.RegisterSingleton<BrokenMatrixModule>();
            builder.RegisterSingleton<MatrixVirusSettingsModule>();
            builder.RegisterSingleton<RegularMatrixModule>();
            builder.RegisterSingleton<SettingsModule>();
            builder.RegisterSingleton<InterfaceColorModule>();
            builder.RegisterSingleton<MatrixColorModule>();
            builder.RegisterSingleton<MatrixSpeedModule>();
            builder.RegisterSingleton<SelectionColorModule>();

        }
    }
}