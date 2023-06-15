namespace QJect.Core.Internals
{
    internal interface ISContainer
    {
        void AddService(Type type, Type bindType, object? impl, SLifeTime lifeTime);
        object GetService(Type serviceType);
    }
}
