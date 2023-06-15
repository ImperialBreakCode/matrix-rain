using QJect.Exceptions.Base;

namespace QJect.Exceptions
{
    public class ServiceNotRegistered : QJectException
    {
        public ServiceNotRegistered(string message) : base(message)
        {
        }
    }
}
