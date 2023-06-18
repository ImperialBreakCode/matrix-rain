using ModuleGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleGenerator.Utils
{
    internal class GenerateModuleQJectConfig
    {
        public static string GenerateConfigSource(Dictionary<string, ModuleItem> modules)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var module in modules)
            {
                stringBuilder.AppendLine($"builder.RegisterSingleton<{module.Key}Module>();");
            }

            return GenerateString(stringBuilder.ToString());
        }

        private static string GenerateString(string confBody)
        {
            return $@"using MatrixRain.Modules;
using QJect;
using QJect.Core;

namespace MatrixRain.Configs
{{
    public class QJectModuleConfig : QJectConfig
    {{
        public override void Configure(IDependencyBuilder builder)
        {{
            {confBody}
        }}
    }}
}}";
        }
    }
}
