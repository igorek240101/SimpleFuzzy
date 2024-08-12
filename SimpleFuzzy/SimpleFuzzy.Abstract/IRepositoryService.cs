public interface IRepositoryService
{
    public void AssemblyHandler(object sender, EventArgs e);
    List<T> GetCollection<T>();
}