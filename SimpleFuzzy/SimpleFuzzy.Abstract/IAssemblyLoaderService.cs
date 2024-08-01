using System.Runtime.Loader;

namespace SimpleFuzzy.Abstract
{
    public interface IAssemblyLoaderService
    {
        string GetInfo(string filePath);
        void UnloadAssembly(string assemblyName, Action<AssemblyLoadContext> Assembly_Unload);
    }
}
