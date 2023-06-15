namespace QJect.Core
{
    public interface IQJectBuilder
    {
        void AddConfigs(Action<IAddConfig> action);
        IQJectServiceProvider Build();
    }
}
