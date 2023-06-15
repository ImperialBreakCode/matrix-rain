namespace QJect.Core
{
    public interface IAddConfig
    {
        void AddConfig<T>() where T : IQJectConfigurable;
    }
}
