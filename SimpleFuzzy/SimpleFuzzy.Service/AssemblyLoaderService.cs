using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;

namespace SimpleFuzzy.Service
{
    public class AssemblyLoaderService : IAssemblyLoaderService
    {
        public IRepositoryService repositoryService;
        private List<AssemblyLoadContext> assemblyLoadContexts = new List<AssemblyLoadContext>();
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
                            repositoryService.GetCollection<IMembershipFunction>().Add(module);
                        }
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
            foreach (var assemblyContextfromList in repositoryService.GetCollection<AssemblyContextModel>())
            {
                if (assemblyContextfromList.AssemblyName == filePath)
                {
                    throw new InvalidOperationException("Повторная загрузка сборки в домен невозможна.");
                }
            }
            var assemblyContext = new AssemblyLoadContext(name: $"{filePath}", isCollectible: true);
            try
            {
                assemblyContext.LoadFromAssemblyPath(filePath);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            assemblyLoadContexts.Add(assemblyContext);
            repositoryService.GetCollection<AssemblyContextModel>().Add(new AssemblyContextModel() { AssemblyName = assemblyContext.Name });
            return assemblyContext;
        }
        public void UnloadAssembly(string assemblyName)
        {
            UseAssembly(assemblyName, new EventArgs());
            try
            {
                WeakReference weakReference;
                UnloadWeak(assemblyName, out weakReference);
                for (int j = 0; weakReference.IsAlive && (j < 10); j++)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                repositoryService.GetCollection<AssemblyContextModel>().RemoveAll(x => x.AssemblyName == assemblyName);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Выгрузить сборку не удалось." + e.Message);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void UnloadWeak(string assemblyName, out WeakReference weakReference)
        {
            var assemblyLoadContext = assemblyLoadContexts.FirstOrDefault(t => t.Name == assemblyName);
            if (assemblyLoadContext != null)
            {
                assemblyLoadContexts.Remove(assemblyLoadContext);
                weakReference = new WeakReference(assemblyLoadContext, true);
                assemblyLoadContext.Unload();
            }
            else
            {
                throw new InvalidOperationException("Удаляемой сборки нет в домене.");
            }
        }


        public void UnloadAllAssemblies()
        {
            while(repositoryService.GetCollection<AssemblyContextModel>().Count > 0)
            {
                UnloadAssembly(repositoryService.GetCollection<AssemblyContextModel>()[0].AssemblyName);
            }

        }
    }
}
