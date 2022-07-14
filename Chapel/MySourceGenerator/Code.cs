using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Diagnostics;
using System.Text;

namespace MySourceGenerator
{
    [Generator]
    public class MySourceGenerator : ISourceGenerator
    {
        public const string Source = @" 
namespace MyNamespace
{
    public class SnippetClass 
    {
        public static int Add(int i, int j )
        {
            return i + j;
        }
    }
}";

        public void Execute(GeneratorExecutionContext context)
        {
            Debugger.Break();

            context.AddSource("CodeSnippet.cs", SourceText.From(Source, Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
}
