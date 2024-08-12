using SimpleFuzzy.Abstract;
using System.Runtime.Loader;

namespace SimpleFuzzy.Service
{
    public class AssemblyLoaderService : IAssemblyLoaderService
    {
        public IRepositoryService repositoryService;
        public event EventHandler? UseAssembly;
        public AssemblyLoaderService(IRepositoryService repositoryService)
        {
            UseAssembly += repositoryService.AssemblyHandler;
            this.repositoryService = repositoryService;
        }
        public void AssemblyLoader(string filePath)
        {
            AddElements(LoadAssembly(filePath));
        }
        private void AddElements(AssemblyLoadContext context)
        {

            for (int i = 0; i < context.Assemblies.Count(); i++)
            {
                Type[] array = context.Assemblies.ElementAt(i).GetTypes();
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j].IsAbstract || array[j].IsInterface) { continue; }

                    if (array[j].GetInterface(nameof(IMembershipFunction)) != null)
                    {
                        try 
                        {
                            var module = array[j].GetConstructor(new Type[] { }).Invoke(null) as IMembershipFunction;
                            module.Active = true;
                            repositoryService.GetCollection<IMembershipFunction>().Add(module); }
                        catch { }
                    }
                    else if (array[j].GetInterface(nameof(IObjectSet)) != null)
                    {
                        try 
                        {
                            var module = array[j].GetConstructor(new Type[] { }).Invoke(null) as IObjectSet;
                            module.Active = true;
                            repositoryService.GetCollection<IObjectSet>().Add(module);
                        }
                        catch { }
                    }
                    else if (array[j].GetInterface(nameof(ISimulator)) != null)
                    {
                        try 
                        {
                            var module = array[j].GetConstructor(new Type[] { }).Invoke(null) as ISimulator;
                            module.Active = false;
                            repositoryService.GetCollection<ISimulator>().Add(module);
                        }
                        catch { }
                    }
                }
            }
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
                    var e = new EventArgs();
                    UseAssembly(assemblyContext, e);
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
        public void UnloadAllAssemblies()
        {
            foreach (var context in repositoryService.GetCollection<AssemblyLoadContext>().ToList())
            {
                UnloadAssembly(context.Assemblies.ElementAt(0).FullName);
            }
            
        }
    }
}
