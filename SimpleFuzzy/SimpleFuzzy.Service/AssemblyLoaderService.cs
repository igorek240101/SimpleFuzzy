using SimpleFuzzy.Abstract;
using System.Reflection;
using System.Runtime.Loader;

namespace SimpleFuzzy.Service
{
    public class AssemblyLoaderService : IAssemblyLoaderService
    {
        private List<AssemblyLoadContext> assemblyContextList;
        public AssemblyLoadContext AssemblyContextList { get { return assemblyContextList[assemblyContextList.Count - 1]; } }
        public AssemblyLoaderService()
        {
            assemblyContextList = new List<AssemblyLoadContext>();
        }

        public (List<IMembershipFunction>, List<IObjectSet>, List<ISimulator>) AddElements(AssemblyLoadContext context)
        {
            List<IMembershipFunction> memberFList = new List<IMembershipFunction>();
            List<IObjectSet> objectSetList = new List<IObjectSet>();
            List<ISimulator> simulatorList = new List<ISimulator>();
            for (int i = 0; i < context.Assemblies.Count(); i++)
            {
                Type[] array = context.Assemblies.ElementAt(i).GetTypes();
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j].IsAbstract || array[j].IsInterface) { continue; }

                    if (array[j] is IMembershipFunction)
                    {
                        try { memberFList.Add(array[j].GetConstructor(null).Invoke(null) as IMembershipFunction); }
                        catch { }
                    }
                    else if (array[j] is IObjectSet)
                    {
                        try { objectSetList.Add(array[j].GetConstructor(null).Invoke(null) as IObjectSet); }
                        catch { }
                    }
                    else if (array[j] is ISimulator)
                    {
                        try { simulatorList.Add(array[j].GetConstructor(null).Invoke(null) as ISimulator); }
                        catch { }
                    }
                }
            } 
            return (memberFList, objectSetList, simulatorList);
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
        public void UnloadAssembly(string assemblyName)
        {
            bool loaded = false;
            foreach (var assemblyContext in assemblyContextList)
            {
                if (assemblyContext.Assemblies.ElementAt(0).FullName == assemblyName)
                {
                    loaded = true;
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
            if (!loaded)
            {
                throw new InvalidOperationException("Удаляемой сборки нет в домене.");
            }
        }
    }
}
