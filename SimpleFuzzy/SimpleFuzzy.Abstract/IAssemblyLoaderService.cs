using System.Runtime.Loader;

namespace SimpleFuzzy.Abstract
{
    public interface IAssemblyLoaderService
    {
        public string AssemblyLoader(string filePath);
        void UnloadAssembly(string assemblyName);
    }
}
