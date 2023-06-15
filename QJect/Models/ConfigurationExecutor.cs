using QJect.Core;

namespace QJect.Models
{
    internal class ConfigurationExecutor : IAddConfig
    {
        private readonly IDependencyBuilder builder;

        public ConfigurationExecutor(IDependencyBuilder builder)
        {
            this.builder = builder;
        }

        public void AddConfig<T>() where T : IQJectConfigurable
        {
            T config = Activator.CreateInstance<T>();
            config.Configure(builder);
        }
    }
}
