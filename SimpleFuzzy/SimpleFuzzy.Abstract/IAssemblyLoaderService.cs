using System.Runtime.Loader;

namespace SimpleFuzzy.Abstract
{
    public interface IAssemblyLoaderService
    {
        public void AssemblyLoader(string filePath);
        void UnloadAssembly(string assemblyName);
    }
}
