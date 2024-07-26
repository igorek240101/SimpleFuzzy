using System.Collections.ObjectModel;

public interface IRepository
{
    ReadOnlyCollection<T> GetCollection<T>();
}