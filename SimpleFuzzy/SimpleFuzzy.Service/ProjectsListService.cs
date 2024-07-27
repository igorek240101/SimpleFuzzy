using System.IO;
using System.Text;
using System.Windows.Forms;
using SimpleFuzzy.Abstract;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimpleFuzzy.Service
{
    public class ProjectListService : IProjectListService
    {
        public string pathPL = Directory.GetCurrentDirectory() + "\\ProjectsList.tt";
        public string? currentProjectName;
        public void AddProject(string name, string path)
        {
            if (!IsContainsName(name))
            {
                if (name == "") throw new InvalidOperationException("Некорректное имя проекта");
                currentProjectName = name;
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
            DirectoryInfo source = new DirectoryInfo(GivePath(currentProjectName, true));
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
                string[] text = File.ReadAllLines(pathPL, Encoding.Default);
                FileStream file = new FileStream(pathPL, FileMode.Truncate);
                StreamWriter writer = new StreamWriter(file);
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] != name) { writer.WriteLine(text[i]); }
                    else { i += 2; }
                }
                writer.Close();
                file.Close();
                currentProjectName = null;
            }
            else { throw new InvalidOperationException("Проекта с таким именем не существует"); }
        }
        public void RenameProject(string name)
        {
            string lastName = currentProjectName;
            CopyProject(name, GivePath(currentProjectName, false) + $"\\{name}");
            string currentName = currentProjectName;
            DeleteProject(lastName);
            currentProjectName = currentName;
        }
        public bool IsContainsName(string name)
        {
            FileStream file = new FileStream(pathPL, FileMode.Open);
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
                    currentProjectName = list[i - 1]; // Устанавливаем имя текущего проекта
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
                string[] text = File.ReadAllLines(pathPL, Encoding.Default);
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
        public string[] GiveList() { return File.ReadAllLines(pathPL, Encoding.Default); }
        public string OpenExplorer(string path, string oldPath = "") {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.SelectedPath = path;
            if (dialog.ShowDialog() == DialogResult.Cancel) return oldPath;
            else { return dialog.SelectedPath; }
        }
    }
}