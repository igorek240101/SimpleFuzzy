using System.IO;
using System.Text;
using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.Service
{
    public class ProjectListService : IProjectListService
    {
        public string pathPL = Directory.GetCurrentDirectory() + "\\ProjectsList.tt";
        public string? CurrentProjectName { get; set; }
        public void AddProject(string name, string path)
        {
            if (!IsContainsName(name))
            {
                if (name == "") throw new InvalidOperationException("Некорректное имя проекта");
                CurrentProjectName = name;
                FileStream file = new FileStream(pathPL, FileMode.Append);
                StreamWriter writer = new StreamWriter(file);
                writer.WriteLine(name);
                writer.WriteLine(path);
                writer.WriteLine("--------------------");
                writer.Close();
                file.Close();
                DirectoryInfo directory = new DirectoryInfo(path);
                directory.Create();
            }
            else { throw new InvalidOperationException("Проект с таким именем уже существует"); }
        }
        public void CopyProject(string name, string path)
        {
            AddProject(name, path);
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.Create();
            DirectoryInfo source = new DirectoryInfo(GivePath(CurrentProjectName, true));
            DirectoryInfo destin = new DirectoryInfo(path);
            foreach (var item in source.GetFiles()) { item.CopyTo(destin + item.Name, true); }
        }
        public void DeleteProject(string name)
        {
            if (IsContainsName(name))
            {
                DirectoryInfo directory = new DirectoryInfo(GivePath(name, true));
                foreach (FileInfo file1 in directory.GetFiles()) { file1.Delete(); }
                Directory.Delete(GivePath(name, true), true);
                string[] text = GiveList();
                FileStream file = new FileStream(pathPL, FileMode.Truncate);
                StreamWriter writer = new StreamWriter(file);
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] != name) { writer.WriteLine(text[i]); }
                    else { i += 2; }
                }
                writer.Close();
                file.Close();
                CurrentProjectName = null;
            }
            else { throw new InvalidOperationException("Проекта с таким именем не существует"); }
        }
        public void RenameProject(string name)
        {
            string lastName = CurrentProjectName;
            CopyProject(name, GivePath(CurrentProjectName, false) + $"\\{name}");
            string currentName = CurrentProjectName;
            DeleteProject(lastName);
            CurrentProjectName = currentName;
        }
        public bool IsContainsName(string name)
        {
            FileStream file = new FileStream(pathPL, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(file);
            string? line;
            while (true)
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    if (line == name)
                    {
                        reader.Close();
                        file.Close();
                        return true;
                    }
                }
                else
                {
                    reader.Close();
                    file.Close();
                    return false;
                }
                reader.ReadLine();
                reader.ReadLine();
            }
        }
        public bool IsContainsPath(string path)
        {
            string[] list = GiveList();
            for (int i = 1; i < list.Length; i++)
            {
                if (path == list[i])
                {
                    CurrentProjectName = list[i - 1]; // Устанавливаем имя текущего проекта
                    return true;
                }
            }
            return false;
        }
        public string GivePath(string name, bool isFull)
        {
            if (IsContainsName(name))
            {
                string path = "";
                string[] text = GiveList();
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == name)
                    {
                        path = text[i + 1];
                        break;
                    }
                }
                if (isFull) return path;
                else
                {
                    string newPath = "";
                    int count = 0;
                    for (int i = path.Length - 1, j = 0; i != 0; i--, j++) { if (path[i] == '\\') { count = j + 1; break; } }
                    for (int i = 0; i < path.Length - count; i++) { newPath += path[i]; }
                    return newPath;
                }
            }
            else { throw new InvalidOperationException("Проекта с таким именем не существует"); }
        }
        public string[] GiveList() 
        {
            FileStream file = new FileStream(pathPL, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(file);
            List<string> list = new List<string>();
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null) { break; }
                else 
                {
                    list.Add(line);
                }
            }
            reader.Close();
            file.Close();
            string[] text = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                text[i] = list.ElementAt(i);
            }
            return text; 
        }
    }
}