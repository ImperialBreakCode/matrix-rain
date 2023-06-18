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
                context.AddSource($"{module.Key}Module.g.cs", GenerateModule.GenerateModuleSource(module.Value, module.Key));
            }

            context.AddSource($"QJectViewConfig.g.cs", GenerateViewQJectConfig.GenerateConfigSource(modules));
            context.AddSource($"QJectControllerConfig.g.cs", GenerateControllerQJectConfig.GenerateConfigSource(modules));
            context.AddSource($"QJectModuleConfig.g.cs", GenerateModuleQJectConfig.GenerateConfigSource(modules));

            context.AddSource($"IModuleSignalConainer.g.cs", GenerateContainer.GenerateInterfaceSource());
            context.AddSource($"SignalModuleContainer.g.cs", GenerateContainer.GenerateContainerSource(modules));
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
