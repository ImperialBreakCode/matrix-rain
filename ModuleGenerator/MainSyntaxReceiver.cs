using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ModuleGenerator.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModuleGenerator
{
    internal class MainSyntaxReceiver : ISyntaxContextReceiver
    {
        private readonly Dictionary<string, ModuleItem> list;

        public MainSyntaxReceiver(Dictionary<string, ModuleItem> dict)
        {
            list = dict;
        }

        public Dictionary<string, ModuleItem> ModuleList => list;

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            if (context.Node is ClassDeclarationSyntax)
            {
                ClassDeclarationSyntax node = context.Node as ClassDeclarationSyntax;

                foreach (var attr in node.AttributeLists)
                {
                    string connectorAttrName = "SignalConnector";

                    if (attr.Attributes.Any(a => a.Name.GetText().ToString() == connectorAttrName))
                    {
                        AttributeSyntax attribute = attr.Attributes.First(a => a.Name.GetText().ToString() == connectorAttrName);
                        AddModule(node, attribute);
                        break;
                    }
                }
                
            }
        }

        private void AddModule(ClassDeclarationSyntax node, AttributeSyntax attribute)
        {
            string controllerName = node.Identifier.ValueText;
            string controllerNameSpace = (node.Parent as NamespaceDeclarationSyntax).Name.ToString().Replace("\n", "").Replace("\r", "");

            string viewName = attribute.ArgumentList.Arguments.First().Expression.ToString();
            viewName = viewName.Substring(1, viewName.Length - 2);
            string viewNameSpace = controllerNameSpace.Split('.')[0] + ".Views";

            ModuleItem module = new ModuleItem()
            {
                Controller = controllerName,
                ControllerNameSpace = controllerNameSpace,
                ViewName = viewName,
                ViewNameSpace = viewNameSpace
            };

            var methods = node.Members.Where(m => m is MethodDeclarationSyntax);
            foreach (var method in methods)
            {
                AddMethod(method as MethodDeclarationSyntax, module);
            }

            string key = viewName.EndsWith("View") ? viewName.Remove(viewName.Length - 4) : viewName;

            if (!list.ContainsKey(key))
            {
                list.Add(key, module);
            }
            else
            {
                list[key] = module;
            }
        }

        private void AddMethod(MethodDeclarationSyntax method, ModuleItem module)
        {
            string methodName = method.Identifier.ValueText;
            string forSignal = method.Identifier.ValueText;
            bool hasData = method.ParameterList.Parameters.Any();

            foreach (var attr in method.AttributeLists)
            {
                string forSignalAttrName = "ForSignal";

                if (attr.Attributes.Any(a => a.Name.ToString() == forSignalAttrName))
                {
                    AttributeSyntax attributeSyntax = attr.Attributes
                        .First(a => a.Name.ToString() == forSignalAttrName);

                    string arg = attributeSyntax.ArgumentList.Arguments.First().Expression.ToString();
                    forSignal = arg.Substring(1, arg.Length - 2);

                    break;
                }
            }

            ActionItem actionItem = new ActionItem(methodName, forSignal, hasData);
            module.ActionList.Add(actionItem);
        }
    }
}
