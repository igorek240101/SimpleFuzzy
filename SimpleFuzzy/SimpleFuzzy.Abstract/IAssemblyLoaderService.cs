using System.Runtime.Loader;

namespace SimpleFuzzy.Abstract
{
    public delegate void UsingContext(object sender, EventArgs e);
    public interface IAssemblyLoaderService
    {
        public void AssemblyLoader(string filePath);
        void UnloadAssembly(string assemblyName, UsingContext funcforEvent);
    }
}
