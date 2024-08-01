using SimpleFuzzy.Abstract;
using System.Reflection;
using System.Runtime.Loader;

namespace SimpleFuzzy.Service
{
    public class AssemblyLoaderService : IAssemblyLoaderService
    {
        private List<AssemblyLoadContext> assemblyContextList;
        public AssemblyLoaderService()
        {
            assemblyContextList = new List<AssemblyLoadContext>();
        }
        public string GetInfo(string filePath)
        {
            foreach (var assemblyContextfromList in assemblyContextList)
            {
                if (assemblyContextfromList.Name == filePath)
                {
                    throw new InvalidOperationException("Повторная загрузка сборки в домен невозможна.");
                }
            }
            var assemblyContext = new AssemblyLoadContext(name: $"{filePath}", isCollectible: true);
            try
            {
                assemblyContext.LoadFromAssemblyPath(filePath);
            }
            catch
            {
                throw new InvalidOperationException("Абсолютный путь файла введен неправильно.");
            }
            assemblyContextList.Add(assemblyContext);
            Assembly assembly = assemblyContext.Assemblies.ElementAt(0);
            string ans = "";
            ans = assembly.FullName;
            return ans;
        }
        public void UnloadAssembly(string assemblyName, Action<AssemblyLoadContext> Assembly_Unload)
        {
            foreach (var assemblyContext in assemblyContextList)
            {
                if (assemblyContext.Assemblies.ElementAt(0).FullName == assemblyName)
                {
                    assemblyContext.Unloading += Assembly_Unload; 
                    try
                    {
                        assemblyContext.Unload();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        assemblyContextList.Remove(assemblyContext);
                        break;
                    }
                    catch
                    {
                        throw new InvalidOperationException("Выгрузить сборку не удалось.");
                    }
                }   
            }
        }
    }
}
