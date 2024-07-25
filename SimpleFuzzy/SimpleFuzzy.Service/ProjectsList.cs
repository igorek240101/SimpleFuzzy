using System.IO;
using System.Text;

namespace SimpleFuzzy.Service
{
    public class ProjectList
    {
        public string pathPL = Directory.GetCurrentDirectory() + "\\ProjectsList.tt";
        public string? currentProjectName;
        public void AddProject(string name, string path)
        {
            if (!IsContainsName(name))
            {
                using (FileStream file = new FileStream(pathPL, FileMode.Append))
                {
                    StreamWriter writer = new StreamWriter(file);
                    writer.WriteLine(name);
                    writer.WriteLine(path);
                    writer.WriteLine("--------------------");
                    writer.Close();
                }
            }
            else { throw new InvalidOperationException("Проект с таким именем уже существует"); }
        }
        public void RedactNameProject(string lastName, string newName, string lastPath, string newPath)
        {
            if (!IsContainsName(newName))
            {
                string text;
                using (StreamReader reader = File.OpenText(pathPL)) { text = reader.ReadToEnd(); }
                text = text.Replace(lastName, newName);
                text = text.Replace(lastPath, newPath);
                using (StreamWriter file = new StreamWriter(pathPL)) { file.Write(text); }
            }
            else { throw new InvalidOperationException("Проект с новым именем уже существует"); }
        }
        public void DeleteProject(string name)
        {
            if (IsContainsName(name))
            {
                string[] text = File.ReadAllLines(pathPL, Encoding.Default);
                using (FileStream file = new FileStream(pathPL, FileMode.Truncate))
                {
                    StreamWriter writer = new StreamWriter(file);
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i] != name) { writer.WriteLine(text[i]); }
                        else { i += 2; }
                    }
                    writer.Close();
                }
            }
            else { throw new InvalidOperationException("Проекта с таким именем не существует"); }
        }
        public bool IsContainsName(string name)
        {
            using (FileStream file = new FileStream(pathPL, FileMode.Open))
            {
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
                            return true;
                        }
                    }
                    else
                    {
                        reader.Close();
                        return false;
                    }
                    reader.ReadLine();
                    reader.ReadLine();
                }
            }
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
    }
}