using QJect.Core;

namespace QJect
{
    public abstract class QJectConfig : IQJectConfigurable
    {
        public abstract void Configure(IDependencyBuilder builder);
    }
}
