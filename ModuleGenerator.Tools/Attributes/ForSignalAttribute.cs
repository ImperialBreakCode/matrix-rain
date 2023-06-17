namespace ModuleGenerator.Tools.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ForSignalAttribute : Attribute
    {
        public ForSignalAttribute(string signal)
        {
            Signal = signal;
        }

        public string Signal { get; private set; }
    }
}
