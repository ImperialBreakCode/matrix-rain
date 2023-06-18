using ModuleGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleGenerator.Utils
{
    internal class GenerateControllerQJectConfig
    {
        public static string GenerateConfigSource(Dictionary<string, ModuleItem> modules)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var module in modules)
            {
                stringBuilder.AppendLine($"builder.RegisterSingleton<{module.Value.Controller}>();");
            }

            return GenerateString(stringBuilder.ToString());
        }

        private static string GenerateString(string confBody)
        {
            return $@"using MatrixRain.Controllers;
using QJect;
using QJect.Core;

namespace MatrixRain.Configs
{{
    public class QJectControllerConfig : QJectConfig
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
