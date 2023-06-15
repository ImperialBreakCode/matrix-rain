using QJect.Models;

namespace QJect.Utils
{
    internal static class ServiceActivation
    {
        public static object? ActivateService(Type type, QJectServiceProvider provider)
        {
            var constructorInfo = type.GetConstructors().First();
            var parameters = constructorInfo.GetParameters()
                .Select(p => provider.GetService(p.ParameterType))
                .ToArray();

            return Activator.CreateInstance(type, parameters);
        } 
    }
}
