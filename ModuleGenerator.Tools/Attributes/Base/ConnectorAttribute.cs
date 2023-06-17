namespace ModuleGenerator.Tools.Attributes.Base
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class ConnectorAttribute : Attribute
    {
        public ConnectorAttribute(string moduleName)
        {
            ModuleName = moduleName;
        }

        public string ModuleName { get; private set; }
    }
}
