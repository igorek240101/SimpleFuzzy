using SimpleFuzzy.Abstract;
using System.Reflection;
using System.Runtime.Loader;

namespace SimpleFuzzy.Service
{
    public class AssemblyLoaderService : IAssemblyLoaderService
    {
        public string GetInfo(string filePath)
        {
            string ans = "";
            try
            {
                ans = Assembly.LoadFrom(filePath).FullName;
            }
            catch (Exception exp)
            {
                throw;
            }
            return ans;
        }
        public void UnloadAssembly(string? filePath)
        {
            if (filePath is string)
            {
                var assemblyContext = new AssemblyLoadContext(name: "UnloadAssemplyContext", isCollectible: true);
                assemblyContext.LoadFromAssemblyPath(filePath);
                assemblyContext.Unload();
            }
            else
            {
                throw new InvalidOperationException("Путь к библиотеке не может быть null");
            }
        }   
    }
}
