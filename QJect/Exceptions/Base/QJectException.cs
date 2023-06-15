namespace QJect.Exceptions.Base
{
    public abstract class QJectException : Exception
    {
        public QJectException(string message) : base($"QJect exception: {message}")
        {
        }
    }
}
