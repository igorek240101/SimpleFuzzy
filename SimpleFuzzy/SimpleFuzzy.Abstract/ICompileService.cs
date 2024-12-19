using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;
using System.Runtime.Loader;

namespace SimpleFuzzy.Abstract
{
    public interface ICompileService
    {
        public (CSharpCompilation, IModulable, AssemblyLoadContext) Compile(string exeCode);

        public void Save(string file, CSharpCompilation compilation);
    }
}
