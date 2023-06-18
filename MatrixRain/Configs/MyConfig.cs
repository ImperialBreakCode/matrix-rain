using MatrixRain.Base.Interfaces;
using MatrixRain.Base.Models;
using QJect;
using QJect.Core;

namespace MatrixRain.Configs
{
    internal class MyConfig : QJectConfig
    {
        public override void Configure(IDependencyBuilder builder)
        {
            builder.RegisterSingleton<INavigation, Navigation>();
        }
    }
}
