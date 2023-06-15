using QJect.Core;
using QJect.Core.Internals;
using QJect.Models;

namespace QJect
{
    public sealed class QJectBuilder : IQJectBuilder
    {
        private readonly IAddConfig configurationExecutor;
        private readonly IDependencyBuilder dependencyBuilder;
        private readonly ISContainer serviceContainer;

        public QJectBuilder()
        {
            serviceContainer = new QServiceContainer();
            dependencyBuilder = new QDependencyBuilder(serviceContainer);
            configurationExecutor = new ConfigurationExecutor(dependencyBuilder);
        }

        public void AddConfigs(Action<IAddConfig> addConfigs)
        {
            addConfigs(configurationExecutor);
        }

        public IQJectServiceProvider Build()
        {
            QJectServiceProvider serviceProvider = new QJectServiceProvider(serviceContainer);

            return serviceProvider;
        }
    }
}
