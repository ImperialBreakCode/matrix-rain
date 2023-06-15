using QJect.Exceptions.Base;

namespace QJect.Exceptions
{
    public class QServiceException : QJectException
    {
        public QServiceException(string message) : base(message)
        {
        }
    }
}
