using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;

public class Repository : IRepository
{
    // Коллекции для хранения различных типов объектов
    private readonly List<IObjectSet> _objectSets;
    private readonly List<IMembershipFunction> _membershipFunctions;
    private readonly List<LinguisticVariable> _linguisticVariables;

    public Repository()
    {
        _objectSets = new List<IObjectSet>();
        _membershipFunctions = new List<IMembershipFunction>();
        _linguisticVariables = new List<LinguisticVariable>();
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
        if (typeof(T) == typeof(LinguisticVariable))
        {
            return (List<T>)(object)_linguisticVariables;
        }

        throw new InvalidOperationException($"Collection for type {typeof(T).Name} is not supported.");
    }
}