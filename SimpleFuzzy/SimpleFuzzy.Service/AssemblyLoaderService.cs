using SimpleFuzzy.Abstract;
using System.Reflection;
using System.Runtime.Loader;

namespace SimpleFuzzy.Service
{
    public class AssemblyLoaderService : IAssemblyLoaderService
    {
        public IRepositoryService repositoryService;
        public AssemblyLoaderService(IRepositoryService repositoryService)
        {
            this.repositoryService = repositoryService;
        }
        public string AssemblyLoader(string filePath)
        {
            return AddElements(LoadAssembly(filePath));
        }
        private string AddElements(AssemblyLoadContext context)
        {
            for (int i = 0; i < context.Assemblies.Count(); i++)
            {
                Type[] array = context.Assemblies.ElementAt(i).GetTypes();
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j].IsAbstract || array[j].IsInterface) { continue; }

                    if (array[j] is IMembershipFunction)
                    {
                        try { repositoryService.GetCollection<IMembershipFunction>().Add(array[j].GetConstructor(null).Invoke(null) as IMembershipFunction); }
                        catch { }
                    }
                    else if (array[j] is IObjectSet)
                    {
                        try { repositoryService.GetCollection<IObjectSet>().Add(array[j].GetConstructor(null).Invoke(null) as IObjectSet); }
                        catch { }
                    }
                    else if (array[j] is ISimulator)
                    {
                        try { repositoryService.GetCollection<ISimulator>().Add(array[j].GetConstructor(null).Invoke(null) as ISimulator); }
                        catch { }
                    }
                }
            }
            return context.Assemblies.ElementAt(0).FullName;
        }
        private AssemblyLoadContext LoadAssembly(string filePath)
        {
            foreach (var assemblyContextfromList in repositoryService.GetCollection<AssemblyLoadContext>())
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
            repositoryService.GetCollection<AssemblyLoadContext>().Add(assemblyContext);
            return assemblyContext;
        }
        public void UnloadAssembly(string assemblyName)
        {
            bool loaded = false;
            foreach (var assemblyContext in repositoryService.GetCollection<AssemblyLoadContext>())
            {
                if (assemblyContext.Assemblies.ElementAt(0).FullName == assemblyName)
                {
                    loaded = true;
                    try
                    {
                        assemblyContext.Unload();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        repositoryService.GetCollection<AssemblyLoadContext>().Remove(assemblyContext);
                        break;
                    }
                    catch
                    {
                        throw new InvalidOperationException("Выгрузить сборку не удалось.");
                    }
                }   
            }
            if (!loaded)
            {
                throw new InvalidOperationException("Удаляемой сборки нет в домене.");
            }
        }
    }
}
