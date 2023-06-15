namespace QJect.Core
{
    public interface IQJectServiceProvider
    {
        T? GetService<T>();
    }
}
