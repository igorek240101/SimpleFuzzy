namespace SimpleFuzzy.Abstract
{
    public interface IProjectListService
    {
        string CurrentProjectName { get; set; }
        public void AddProject(string name, string path);
        public void OpenProjectfromName(string name);
        public void OpenProjectfromPath(string path);
        public void CopyProject(string name, string path, bool save);
        public void RenameProject(string name);
        public void DeleteOnlyInList(string name);
        public void DeleteProject(string name);
        public bool IsContainsName(string name);
        public bool IsContainsPath(string path);
        public string GivePath(string name, bool isFull);
        public string[]? GiveList();
        public void SaveAll(string name = "\\Save.xml");
        public void LoadAll(string name = "\\Save.xml");
        public void CheckAll();
    }
}
