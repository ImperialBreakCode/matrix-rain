using QJect.Core.Internals;

namespace QJect.Models
{
    internal class ServiceInformation
    {
        public ServiceInformation(Type type, Type bindType, object? implementation, SLifeTime serviceLifeTime)
        {
            Type = type;
            BindType = bindType;
            Implementation = implementation;
            ServiceLifeTime = serviceLifeTime;
        }

        public Type Type { get; private set; }
        public Type BindType { get; private set; }
        public object? Implementation { get; set; }
        public SLifeTime ServiceLifeTime { get; private set; }
    }
}
