using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.Service
{
    public class RepositoryService : IRepositoryService
    {
        // Коллекции для хранения различных типов объектов
        public readonly List<AssemblyLoadContext> _assemblyContext;
        public readonly List<IObjectSet> _objectSets;
        public readonly List<IMembershipFunction> _membershipFunctions;
        public readonly List<ISimulator> _simulators;
        public readonly List<LinguisticVariable> _linguisticVariables;

        public RepositoryService()
        {
            _assemblyContext = new List<AssemblyLoadContext>();
            _objectSets = new List<IObjectSet>();
            _membershipFunctions = new List<IMembershipFunction>();
            _simulators = new List<ISimulator>();
            _linguisticVariables = new List<LinguisticVariable>();
        }

        public void AssemblyHandler(object sender, EventArgs e)
        {
            AssemblyLoadContext context = sender as AssemblyLoadContext;
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
                            GetCollection<IMembershipFunction>().Remove(module);
                        }
                        catch { }
                    }
                    else if (array[j].GetInterface(nameof(IObjectSet)) != null)
                    {
                        try
                        {
                            var module = array[j].GetConstructor(new Type[] { }).Invoke(null) as IObjectSet;
                            GetCollection<IObjectSet>().Remove(module);
                        }
                        catch { }
                    }
                    else if (array[j].GetInterface(nameof(ISimulator)) != null)
                    {
                        try
                        {
                            var module = array[j].GetConstructor(new Type[] { }).Invoke(null) as ISimulator;
                            GetCollection<ISimulator>().Remove(module);
                        }
                        catch { }
                    }
                }
            }
        }

        // Универсальный метод для получения коллекций
        public List<T> GetCollection<T>()
        {
            if (typeof(T) == typeof(IObjectSet))
            {
                return (List<T>)(object)_objectSets;
            }
            if (typeof(T) == typeof(IMembershipFunction))
            {
                return (List<T>)(object)_membershipFunctions;
            }
            if (typeof(T) == typeof(ISimulator))
            {
                return (List<T>)(object)_simulators;
            }
            if (typeof(T) == typeof(LinguisticVariable))
            {
                return (List<T>)(object)_linguisticVariables;
            }
            if (typeof(T) == typeof(AssemblyLoadContext))
            {
                return (List<T>)(object)_assemblyContext;
            }

            throw new InvalidOperationException($"Collection for type {typeof(T).Name} is not supported.");
        }
    }
}
