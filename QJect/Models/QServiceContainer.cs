using QJect.Exceptions;
using QJect.Constants;
using QJect.Core.Internals;

namespace QJect.Models
{
    internal class QServiceContainer : ISContainer
    {
        private readonly Dictionary<Type, ServiceInformation> _services;

        public QServiceContainer()
        {
            _services = new Dictionary<Type, ServiceInformation>();
        }

        public void AddService(Type type, Type bindType, object? impl, SLifeTime lifeTime)
        {
            if (!type.IsInterface && !type.IsClass)
            {
                throw new InvalidServiceType(ExMessages.ServiceTypeInvalid);
            }

            if (!bindType.IsClass)
            {
                throw new InvalidServiceType(ExMessages.BindTypeInvalid);
            }

            if (_services.ContainsKey(type))
            {
                throw new QServiceException(string.Format(ExMessages.ServiceAlreadyRegistered, type));
            }

            ServiceInformation serviceInformation = new ServiceInformation(type, bindType, impl, lifeTime);
            _services.Add(type, serviceInformation);
        }

        public object GetService(Type serviceType)
        {
            try
            {
                ServiceInformation serviceInformation = _services[serviceType];
                return serviceInformation;
            }
            catch (KeyNotFoundException)
            {
                throw new ServiceNotRegistered(string.Format(ExMessages.ServiceNotRegistered, serviceType));
            }
        }
    }
}
