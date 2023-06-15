using QJect.Core;
using QJect.Core.Internals;
using QJect.Utils;

namespace QJect.Models
{
    internal class QJectServiceProvider : IQJectServiceProvider
    {
        private readonly ISContainer container;

        public QJectServiceProvider(ISContainer container)
        {
            this.container = container;
        }

        public T? GetService<T>()
        {
            return (T?)GetService(typeof(T));
        }

        internal object? GetService(Type type)
        {
            var serviceInfo = (ServiceInformation)container.GetService(type);

            if (serviceInfo.ServiceLifeTime == SLifeTime.Transient)
            {
                return ServiceActivation.ActivateService(serviceInfo.BindType, this);
            }
            else
            {
                if (serviceInfo.Implementation is null)
                {
                    serviceInfo.Implementation = ServiceActivation.ActivateService(serviceInfo.BindType, this);
                }

                return serviceInfo.Implementation;
            }
        }
    }
}