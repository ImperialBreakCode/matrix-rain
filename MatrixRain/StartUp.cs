using MatrixRain.Configs;
using MatrixRain.Interfaces;
using QJect;
using QJect.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixRain
{
    public class StartUp
    {
        private IQJectServiceProvider provider;

        public StartUp()
        {
            Configure();
        }

        public void Start()
        {
            var app = provider.GetService<IMatrixRainApp>();

            if (app is not null)
            {
                app.Run();
            }
            else
            {
                throw new NullReferenceException("Problem with app initialization.");
            }
        }

        private void Configure()
        {
            QJectBuilder builder = new QJectBuilder();
            builder.AddConfigs(c =>
            {
                c.AddConfig<QJectViewConfig>();
                c.AddConfig<QJectControllerConfig>();
                c.AddConfig<QJectModuleConfig>();
                c.AddConfig<MatrixRainConfig>();
            });

            provider = builder.Build();
        } 
    }
}
