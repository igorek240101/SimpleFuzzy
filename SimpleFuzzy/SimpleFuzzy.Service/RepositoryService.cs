using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;

public class RepositoryService : IRepositoryService
{
    // Коллекции для хранения различных типов объектов
    public readonly List<AssemblyContextModel> _assemblyContext;
    public readonly List<IObjectSet> _objectSets;
    public readonly List<IMembershipFunction> _membershipFunctions;
    public readonly List<ISimulator> _simulators;
    public readonly List<LinguisticVariable> _linguisticVariables;

    public RepositoryService()
    {
        _assemblyContext = new List<AssemblyContextModel>();
        _objectSets = new List<IObjectSet>();
        _membershipFunctions = new List<IMembershipFunction>();
        _simulators = new List<ISimulator>();
        _linguisticVariables = new List<LinguisticVariable>();
    }

    public void AssemblyHandler(object sender, EventArgs e)
    {
        string context = sender as string;
        for (int k = 0; k < _membershipFunctions.Count; k++)
        {
            if (_membershipFunctions[k].GetType().Assembly.Location == context)
            {
                _membershipFunctions.RemoveAt(k);
            }
        }
        for (int k = 0; k < _objectSets.Count; k++)
        {
            if (_objectSets[k].GetType().Assembly.Location == context)
            {
                _objectSets.RemoveAt(k);
            }
        }
        for (int k = 0; k < _simulators.Count; k++)
        {
            if (_simulators[k].GetType().Assembly.Location == context)
            {
                _simulators.RemoveAt(k);
            }
        }
    }

    public void ClearAll()
    {
        GetCollection<IMembershipFunction>().Clear();
        GetCollection<IObjectSet>().Clear();
        GetCollection<ISimulator>().Clear();
        GetCollection<LinguisticVariable>().Clear();
        GetCollection<AssemblyContextModel>().Clear();
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
        if (typeof(T) == typeof(AssemblyContextModel))
        {
            return (List<T>)(object)_assemblyContext;
        }

        throw new InvalidOperationException($"Collection for type {typeof(T).Name} is not supported.");
    }
}