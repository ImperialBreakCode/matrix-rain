using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Models;
using MatrixRain.Interfaces;
using MatrixRain.Models;
using MatrixRain.Services;
using MatrixRain.Services.Interfaces;
using QJect;
using QJect.Core;

namespace MatrixRain.Configs
{
    internal class MatrixRainConfig : QJectConfig
    {
        public override void Configure(IDependencyBuilder builder)
        {
            builder.RegisterSingleton<IModuleSignalConainer, SignalModuleContainer>();
            builder.RegisterSingleton<IMatrixRainApp, MatrixRainApp>();
            builder.RegisterSingleton<INavigation, Navigation>();

            builder.RegisterSingleton<ISettingsService, SettingsService>();

            builder.RegisterTransient<IMatrixService, MatrixService>();
            builder.RegisterTransient<ISettingsFactory, SettingsFactory>();

            builder.RegisterSingleton<Random>();
        }
    }
}
