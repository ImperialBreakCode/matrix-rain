namespace QJect.Core
{
    public interface IDependencyBuilder
    {
        void RegisterSingleton<T>(T implementation);
        void RegisterSingleton<T>();
        void RegisterSingleton<I, C>(C implementation);
        void RegisterSingleton<I, C>();
        void RegisterTransient<T>();
        void RegisterTransient<I, C>();
    }
}
