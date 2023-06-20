using MatrixRain.Controllers;
using QJect;
using QJect.Core;

namespace MatrixRain.Configs
{
    public class QJectControllerConfig : QJectConfig
    {
        public override void Configure(IDependencyBuilder builder)
        {
            builder.RegisterSingleton<HomeController>();
            builder.RegisterSingleton<MatrixAnimationController>();
            builder.RegisterSingleton<MatrixController>();
            builder.RegisterSingleton<BrokenMatrixController>();
            builder.RegisterSingleton<MatrixVirusSettingsController>();
            builder.RegisterSingleton<RegularMatrixController>();
            builder.RegisterSingleton<SettingsController>();
            builder.RegisterSingleton<InterfaceColorController>();
            builder.RegisterSingleton<MatrixColorController>();
            builder.RegisterSingleton<MatrixSpeedController>();
            builder.RegisterSingleton<SelectionColorController>();

        }
    }
}