using ModuleGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleGenerator.Utils
{
    internal static class GenerateContainer
    {

        public static string GenerateContainerSource(Dictionary<string, ModuleItem> modules)
        {
            List<string> moduleParams = new List<string>();
            StringBuilder stringBuilder = new StringBuilder();

            int i = 0;
            foreach (var module in modules)
            {
                moduleParams.Add($"{module.Key}Module module{i}");

                stringBuilder.AppendLine($@"container.Add(""{module.Key}"", module{i});");

                i++;
            }

            return ContainerString(string.Join(", ", moduleParams), stringBuilder.ToString());
        }

        private static string ContainerString(string moduleParams, string addingToList)
        {
            return $@"using MatrixRain.Base.Interfaces;
using MatrixRain.Modules;
using MatrixRain;

namespace MatrixRain
{{
    public class SignalModuleContainer : IModuleSignalConainer
    {{
        private IDictionary<string, ISignalModule> container;

        public SignalModuleContainer({moduleParams})
        {{
            container = new Dictionary<string, ISignalModule>();
            {addingToList}
        }}

        public IDictionary<string, ISignalModule> Container => container;
    }}
}}";
        }

        public static string GenerateInterfaceSource()
        {
            return @"using MatrixRain.Base.Interfaces;

namespace MatrixRain
{
    public interface IModuleSignalConainer
    {
        public IDictionary<string, ISignalModule> Container { get; }
    }
}";
        }
    }
}
