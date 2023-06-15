using QJect.Exceptions.Base;

namespace QJect.Exceptions
{
    public class InvalidServiceType : QJectException
    {
        public InvalidServiceType(string message) : base(message)
        {
        }
    }
}
