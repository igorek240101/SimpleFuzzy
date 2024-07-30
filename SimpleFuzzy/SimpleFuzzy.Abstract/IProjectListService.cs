using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFuzzy.Abstract
{
    public interface IProjectListService
    {
        string? CurrentProjectName { get; set; }
        public void AddProject(string name, string path);
        public void CopyProject(string name, string path);
        public void RenameProject(string name);
        public void DeleteProject(string name);
        public bool IsContainsName(string name);
        public bool IsContainsPath(string path);
        public string GivePath(string name, bool isFull);
        public string[] GiveList();
    }
}
