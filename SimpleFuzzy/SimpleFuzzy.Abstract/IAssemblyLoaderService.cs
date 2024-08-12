
namespace SimpleFuzzy.Abstract
{
    public interface IAssemblyLoaderService
    {
        event EventHandler? UseAssembly;
        public void AssemblyLoader(string filePath);
        void UnloadAssembly(string assemblyName);
        public void UnloadAllAssemblies();
    }
}
