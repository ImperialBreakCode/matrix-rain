using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ModuleGenerator
{
    internal class SyntaxReceiver : ISyntaxContextReceiver
    {
        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {

            if (context.Node is MethodDeclarationSyntax)
            {
                var node = context.Node as MethodDeclarationSyntax;
                var name = node.ConstraintClauses;
            }
        }
    }
}
