using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;
using System.Collections.ObjectModel;

public class Repository : IRepository
{
    // Коллекции для хранения различных типов объектов
    private readonly List<IObjectSet> _objectSets;
    private readonly List<IMembershipFunction> _membershipFunctions;
    private readonly List<ISimulator> _simulators;
    private readonly List<LinguisticVariable> _linguisticVariables;

    public Repository()
    {
        _objectSets = new List<IObjectSet>();
        _membershipFunctions = new List<IMembershipFunction>();
        _simulators = new List<ISimulator>();
        _linguisticVariables = new List<LinguisticVariable>();
    }

    // Универсальный метод для получения коллекций только для чтения
    public ReadOnlyCollection<T> GetCollection<T>()
    {
        if (typeof(T) == typeof(IObjectSet))
        {
            return _objectSets.AsReadOnly() as ReadOnlyCollection<T>;
        }
        if (typeof(T) == typeof(IMembershipFunction))
        {
            return _membershipFunctions.AsReadOnly() as ReadOnlyCollection<T>;
        }
        if (typeof(T) == typeof(ISimulator))
        {
            return _simulators.AsReadOnly() as ReadOnlyCollection<T>;
        }
        if (typeof(T) == typeof(LinguisticVariable))
        {
            return _linguisticVariables.AsReadOnly() as ReadOnlyCollection<T>;
        }

        throw new InvalidOperationException($"Collection for type {typeof(T).Name} is not supported.");
    }
}