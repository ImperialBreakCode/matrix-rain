using Microsoft.CodeAnalysis;
using ModuleGenerator.Models;
using ModuleGenerator.Utils;
using System.Collections.Generic;
using System.Diagnostics;

namespace ModuleGenerator
{
    [Generator]
    public class ModuleGenerator : ISourceGenerator
    {
        private readonly Dictionary<string, ModuleItem> modules = new Dictionary<string, ModuleItem>();

        public void Execute(GeneratorExecutionContext context)
        {
            foreach (var module in modules)
            {
                context.AddSource($"{module.Key}Module.g.cs", Generations.GenerateModuleSource(module.Value, module.Key));
            }
        }

        public void Initialize(GeneratorInitializationContext context)
        {

            context.RegisterForSyntaxNotifications(() => new MainSyntaxReceiver(modules));

//#if DEBUG
//            if (!Debugger.IsAttached)
//            {
//                Debugger.Launch();
//            }
//#endif

        }
    }
}
