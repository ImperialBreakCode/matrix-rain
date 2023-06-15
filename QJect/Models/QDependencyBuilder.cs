using QJect.Core;
using QJect.Core.Internals;

namespace QJect.Models
{
    internal class QDependencyBuilder : IDependencyBuilder
    {
        private readonly ISContainer container;

        public QDependencyBuilder(ISContainer container)
        {
            this.container = container;
        }

        public void RegisterSingleton<T>(T implementation)
        {
            Type type = typeof(T);
            container.AddService(type, type, implementation, SLifeTime.Singleton);
        }

        public void RegisterSingleton<T>()
        {
            Type type = typeof(T);
            container.AddService(type, type, null, SLifeTime.Singleton);
        }

        public void RegisterSingleton<I, C>(C implementation)
        {
            Type type = typeof(I);
            Type bindType = typeof(C);
            container.AddService(type, bindType, implementation, SLifeTime.Singleton);
        }

        public void RegisterSingleton<I, C>()
        {
            Type type = typeof(I);
            Type bindType = typeof(C);
            container.AddService(type, bindType, null, SLifeTime.Singleton);
        }

        public void RegisterTransient<T>()
        {
            Type type = typeof(T);
            container.AddService(type, type, null, SLifeTime.Transient);
        }

        public void RegisterTransient<I, C>()
        {
            Type type = typeof(I);
            Type bindType = typeof(C);
            container.AddService(type, bindType, null, SLifeTime.Transient);
        }
    }
}
