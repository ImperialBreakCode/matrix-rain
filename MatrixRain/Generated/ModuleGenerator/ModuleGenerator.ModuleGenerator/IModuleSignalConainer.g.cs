using MatrixRain.Base.Interfaces;

namespace MatrixRain
{
    public interface IModuleSignalConainer
    {
        public IDictionary<string, ISignalModule> Container { get; }
    }
}