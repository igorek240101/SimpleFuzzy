namespace SimpleFuzzy.Abstract
{
    public interface IRepositoryService
    {
        public void AssemblyHandler(object sender, EventArgs e);
        public void ClearAll();
        List<T> GetCollection<T>();
    }
}