using MatrixRain.Base.Models;
using MatrixRain.Controllers;
using MatrixRain.Views;
using MatrixRain.Modules;
using QJect;
using MatrixRain.Configs;
using QJect.Core;

namespace MatrixRain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QJectBuilder qJectBuilder = new QJectBuilder();
            qJectBuilder.AddConfigs(c =>
            {
                c.AddConfig<QJectViewConfig>();
                c.AddConfig<QJectControllerConfig>();
                c.AddConfig<QJectModuleConfig>();
                c.AddConfig<MyConfig>();
            });

            IQJectServiceProvider provider = qJectBuilder.Build();

            var module = provider.GetService<TestModule>();

            if (module is not null)
            {
                module.Run();
            }
            else
            {
                Console.WriteLine("Module is null");
            }
        }
    }
}