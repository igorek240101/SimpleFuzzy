using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.Service
{
    public class CompileService : ICompileService
    {
        private static readonly IEnumerable<MetadataReference> DefaultReferences =
            new []
            {
                MetadataReference.CreateFromFile(typeof(ISimulator).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Regex).Assembly.Location),
                MetadataReference.CreateFromFile(Path.Combine(Path.GetDirectoryName(typeof(object).Assembly.Location), "System.Runtime.dll"))
            };

        private static readonly CSharpCompilationOptions DefaultCompilationOptions =
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                    .WithOverflowChecks(true).WithOptimizationLevel(OptimizationLevel.Release);

        public static SyntaxTree Parse(string text, string filename = "", CSharpParseOptions options = null)
        {
            var stringText = SourceText.From(text, Encoding.UTF8);
            return SyntaxFactory.ParseSyntaxTree(stringText, options, filename);
        }

        public (CSharpCompilation, IModulable, AssemblyLoadContext) Compile(string exeCode)
        {
            var source = exeCode;
            var parsedSyntaxTree = Parse(source, "", CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp10));
            
            var compilation = CSharpCompilation.Create($"{DateTime.Now.Ticks}.dll", new SyntaxTree[] { parsedSyntaxTree }, DefaultReferences, DefaultCompilationOptions);
            using var stream = new MemoryStream();
            var result = compilation.Emit(stream);
            if (!result.Success) 
            {

            }
            stream.Seek(0, SeekOrigin.Begin);
            var assemblyContext = new AssemblyLoadContext(name: $"{DateTime.Now.Ticks}", isCollectible: true);
            assemblyContext.LoadFromStream(stream);
            var assembly = assemblyContext.Assemblies.ElementAt(0);
            return (compilation, assembly.GetTypes()[0].GetConstructors()[0].Invoke(null) as IModulable, assemblyContext);
        }

        public void Save(string file, CSharpCompilation compilation)
        {
            compilation.Emit(file);
        }
    }
}

