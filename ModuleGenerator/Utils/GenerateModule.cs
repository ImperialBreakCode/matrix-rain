using ModuleGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleGenerator.Utils
{
    internal static class GenerateModule
    {
        public static string GenerateModuleSource(ModuleItem module, string moduleName)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var actionItem in module.ActionList)
            {
                string dataArg = actionItem.HasData ? "args.Data" : "";

                stringBuilder.AppendLine($@"case ""{actionItem.ForSignal}"":");
                stringBuilder.AppendLine($"\tcontroller.{actionItem.ActionName}({dataArg});");
                stringBuilder.AppendLine("\tbreak;");
            }

            return GenerateString(module.ViewNameSpace, 
                                  module.ControllerNameSpace,
                                  moduleName,
                                  module.Controller,
                                  module.ViewName,
                                  stringBuilder.ToString());
        }


        private static string GenerateString(string viewNameSpace, string contrNameSpace, string moduleName, string controller, string view, string switchStatement)
        {
            return $@"using MatrixRain.Base.Models;
using MatrixRain.Base.Models.Views;
using {viewNameSpace};
using {contrNameSpace};

namespace MatrixRain.Modules
{{
    public class {moduleName}Module : SignalModuleBase
    {{
        private readonly {controller} controller;

        public TestModule({view} view, {controller} controller) : base(view)
        {{
            this.controller = controller;
        }}

        protected override void SignalHandler(object? sender, SignalArgs args)
        {{

            switch (args.SignalMessage)
            {{
                {switchStatement}
                default:
                    break;
            }}
        }}
    }}
}}
";
        }
    }
}
