using System.Runtime.Loader;

namespace SimpleFuzzy.Abstract
{
    public interface IAssemblyLoaderService
    {
        public AssemblyLoadContext AssemblyContextList { get; }
        public (List<IMembershipFunction>, List<IObjectSet>, List<ISimulator>) AddElements(AssemblyLoadContext context);
        string GetInfo(string filePath);
        void UnloadAssembly(string assemblyName);
    }
}
