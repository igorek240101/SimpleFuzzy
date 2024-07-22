using System.CodeDom.Compiler;
using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.Service
{
    public class CompileService : ICompileService
    {
        public void SaveFileAt(string exeCode, string savePath)
        {
            var compiler = CodeDomProvider.CreateProvider("CSharp");

            CompilerParameters cp = new CompilerParameters();

            cp.GenerateExecutable = false;

            cp.OutputAssembly = "CompiledOutput.dll";

            if (Directory.Exists(savePath))
            {
                if (compiler.Supports(GeneratorSupport.Resources))
                {
                    cp.EmbeddedResources.Add(savePath);
                }
            }

            CompilerResults cr = compiler.CompileAssemblyFromFile(cp, exeCode);
        }
    }
}
