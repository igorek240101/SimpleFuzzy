using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Loader;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;
using System.Data;

namespace SimpleFuzzy.Service
{
    public class ProjectListService : IProjectListService
    {
        public string pathPL = Directory.GetCurrentDirectory() + "\\ProjectsList.tt";
        public string pathPR = Directory.GetCurrentDirectory() + "\\Projects";
        public IRepositoryService repository;
        public IAssemblyLoaderService loaderService;
        private IDefazificationService defazificationService;
        Dictionary<string, Action<XmlNodeList>> pair = new Dictionary<string, Action<XmlNodeList>>();
        public ProjectListService(IAssemblyLoaderService loaderService, IRepositoryService repositoryService, IDefazificationService defazificationService)
        {
            repository = repositoryService;
            this.loaderService = loaderService;
            pair.Add("activeModules", ChooseActive);
            pair.Add("allLinguisticVariables", LoadLinguisticVariable);
            this.defazificationService = defazificationService;
        }
        public string? CurrentProjectName { get; set; }

        public void CheckAll()
        {
            string[] list = GiveList();
            for (int i = 0; i < list.Length; i++)
            {
                if (i % 3 == 0) ContainsCheckName(list[i]);
            }
            ContainsCheckPath();
        }

        public void AddProject(string name, string path)
        {
            if (!IsContainsName(name))
            {
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
                loaderService.UnloadAllAssemblies();
            }
            else { throw new InvalidOperationException("Проект с таким именем уже существует"); }
        }
        private void AddAssemblies(string path) 
        {
                foreach (string fileName in Directory.GetFiles(path))
                {
                    if (fileName.Split('.')[^1] == "dll") loaderService.AssemblyLoader(fileName);
                }
        }

        public void LoadAll(string name = "\\Save.xml")
        {
            if (File.Exists(GivePath(CurrentProjectName, true) + name))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(GivePath(CurrentProjectName, true) + name);
                var root = doc.DocumentElement;
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    Action<XmlNodeList> action;
                    if (pair.TryGetValue(root.ChildNodes[i].Name, out action))
                    {
                        action(root.ChildNodes[i].ChildNodes);
                    }
                }
            }
        }

        private void ChooseActive(XmlNodeList list)
        {
            foreach (XmlNode moduleNode in list)
            {
                string moduleName = moduleNode.Attributes["moduleName"].Value;
                string assemblyName = moduleNode.Attributes["assemblyName"].Value;
                bool status;
                if (moduleNode.InnerText == "true") status = true;
                else status = false;

                bool isContinue = false;
                IModulable module = repository.GetCollection<IMembershipFunction>().FirstOrDefault(t => t.GetType().Name == moduleName && assemblyName == t.GetType().Assembly.FullName);
                if (module != null) { 
                    module.Active = status;
                    continue;
                }
                module = repository.GetCollection<IObjectSet>().FirstOrDefault(t => t.GetType().Name == moduleName && assemblyName == t.GetType().Assembly.FullName);
                if (module != null)
                {
                    module.Active = status;
                    continue;
                }
                module = repository.GetCollection<ISimulator>().FirstOrDefault(t => t.GetType().Name == moduleName && assemblyName == t.GetType().Assembly.FullName);
                if (module != null)
                {
                    module.Active = status;
                    (module as ISimulator).SetController(defazificationService.DefazificationSimulator);
                    continue;
                }
            }
        }
        public void LoadLinguisticVariable(XmlNodeList list)
        {
            foreach (XmlNode xmlLinguistic in list)
            {
                string namefromNode = xmlLinguistic["name"].InnerText;
                bool inputfromNode = bool.Parse(xmlLinguistic["isInput"].InnerText);
                bool redactfromNode = bool.Parse(xmlLinguistic["isRedact"].InnerText);
                IObjectSet newSet = null;
                if (xmlLinguistic["baseSet"].InnerText != "Нет базового множества") {
                    foreach (var objectSet in repository.GetCollection<IObjectSet>())
                    {
                        if (objectSet.GetType().FullName + " " + objectSet.GetType().Assembly.FullName == xmlLinguistic["baseSet"].InnerText)
                        {
                            newSet = objectSet;
                            break;
                        }
                    }
                }
                var membershipFunctions = new List<(IMembershipFunction, Color)>();
                if (xmlLinguistic["func"].InnerText != "Нет термов")
                {
                    foreach (var function in repository.GetCollection<IMembershipFunction>())
                    {
                        foreach (XmlNode childnode in xmlLinguistic["func"].ChildNodes)
                        {
                            if (function.GetType().FullName + " " + function.GetType().Assembly.FullName == childnode.InnerText)
                            {
                                string r = childnode.Attributes["R"].Value;
                                string g = childnode.Attributes["G"].Value;
                                string b = childnode.Attributes["B"].Value;
                                if (r != null && g != null && b != null)
                                    membershipFunctions.Add((function, Color.FromArgb(int.Parse(r), int.Parse(g), int.Parse(b))));
                                else
                                    membershipFunctions.Add((function, Color.Black));
                            }
                        }
                    }
                }
                var linguistic = new LinguisticVariable(namefromNode, inputfromNode, redactfromNode, newSet, membershipFunctions);
                repository.GetCollection<LinguisticVariable>().Add(linguistic);
            }
        }
        public void OpenProjectfromName(string name)
        {
            if (ContainsCheckName(name))
            {
                if (IsContainsName(name))
                {
                    OpenProjectfromPath(GivePath(name, true));
                }
                else
                {
                    throw new InvalidOperationException("Проекта с таким именем не существует");
                }
            }
            else { throw new InvalidOperationException("Проекта с таким именем не существует"); }
        }
        public void OpenProjectfromPath(string path) 
        {
            ContainsCheckPath();
            if (IsContainsPath(path))
            {
                // открытие проекта
                loaderService.UnloadAllAssemblies();
                repository.ClearAll();
                CurrentProjectName = path.Split('\\')[^1];
                AddAssemblies(path); // подключение сборок
                LoadAll(); // загрузка сохранения
            }
            else
            {
                throw new InvalidOperationException("Проекта по указаному пути не существует");
            }
        }
        public void CopyProject(string name, string path, bool save)
        {
            if (ContainsCheckName(name))
            {
                string lastName = CurrentProjectName;
                SaveAll("\\SaveCopy.xml");
                AddProject(name, path);
                DirectoryInfo source = new DirectoryInfo(GivePath(lastName, true));
                DirectoryInfo destin = new DirectoryInfo(GivePath(name, true));
                foreach (var item in source.GetFiles()) { item.CopyTo(destin + "\\" + item.Name, true); }
                File.Delete(GivePath(lastName, true) + "\\SaveCopy.xml");
                if (save)
                {
                    if (File.Exists(GivePath(name, true) + "\\Save.xml")) File.Delete(GivePath(name, true) + "\\Save.xml");
                    File.Move(GivePath(name, true) + "\\SaveCopy.xml", GivePath(name, true) + "\\Save.xml");
                    OpenProjectfromName(name);
                }
                else
                {
                    if (File.Exists(GivePath(name, true) + "\\Save.xml"))
                    {
                        File.Move(GivePath(name, true) + "\\Save.xml", GivePath(name, true) + "\\Save1.xml");
                        File.Move(GivePath(name, true) + "\\SaveCopy.xml", GivePath(name, true) + "\\Save.xml");
                        File.Move(GivePath(name, true) + "\\Save1.xml", GivePath(name, true) + "\\SaveCopy.xml");
                    }
                    else { File.Move(GivePath(name, true) + "\\SaveCopy.xml", GivePath(name, true) + "\\Save.xml"); }
                }
            }
            else { throw new InvalidOperationException("Проекта с таким именем не существует"); }
        }
        public void DeleteProject(string name)
        {
            if (ContainsCheckName(name))
            {
                if (IsContainsName(name))
                {
                    DirectoryInfo directory = new DirectoryInfo(GivePath(name, true));
                    loaderService.UnloadAllAssemblies();
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
            else { throw new InvalidOperationException("Проекта с таким именем не существует"); }
        }
        public void DeleteOnlyInList(string name)
        {
            if (ContainsCheckName(name))
            {
                if (CurrentProjectName == name) { CurrentProjectName = null; }
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
            }
            else { throw new InvalidOperationException("Проекта с таким именем не существует"); }
        }
        public void RenameProject(string name)
        {
            if (ContainsCheckName(name)) { 
                string lastName = CurrentProjectName;
                CopyProject(name, GivePath(CurrentProjectName, false) + $"\\{name}", false);
                string currentName = CurrentProjectName;
                DeleteProject(lastName);
                CurrentProjectName = currentName;
                OpenProjectfromName(currentName);
                File.Delete(GivePath(name, true) + "\\Save.xml");
                if (File.Exists(GivePath(name, true) + "\\SaveCopy.xml"))
                {
                    File.Move(GivePath(name, true) + "\\SaveCopy.xml", GivePath(name, true) + "\\Save.xml");
                }
            }
            else { throw new InvalidOperationException("Проекта с таким именем не существует"); }
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
                    return true;
                }
            }
            return false;
        }

        public void ContainsCheckPath()
        {
            var directories = Directory.GetDirectories(pathPR);
            bool checker = false;
            foreach (var dirPath in directories)
            {
                Console.WriteLine(dirPath);
                try { AddProject(dirPath.Split('\\')[^1].Split('.')[0], dirPath);}
                catch (InvalidOperationException e) {
                    if (e.Message == "Проект с таким именем уже существует") continue;
                }
            }
        }

        public bool ContainsCheckName(string name)
        {
            try { GivePath(name, true); }
            catch (InvalidOperationException e) { DeleteProject(name); return false; }
            return true;
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

        public void SaveAll(string name = "\\Save.xml")
        {
            // открытие xml файла
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("saves");
            doc.AppendChild(root);
            XmlElement activeModules = doc.CreateElement("activeModules");
            XmlElement linguistic = doc.CreateElement("allLinguisticVariables");
            root.AppendChild(activeModules);
            root.AppendChild(linguistic);
            // методы сохранения
            SaveActiveModulesXML(activeModules);
            SaveAllLinguisticVariable(linguistic);
            // сохранение xml файла
            doc.Save(GivePath(CurrentProjectName, true) + name);
        }

        private void SaveActiveModulesXML(XmlElement activeModules)
        {
            var s = repository.GetCollection<IMembershipFunction>().Cast<IModulable>().
                Concat(repository.GetCollection<IObjectSet>().Cast<IModulable>()).
                Concat(repository.GetCollection<ISimulator>().Cast<IModulable>());
            foreach (IModulable element in s)
            {
                XmlElement module = activeModules.OwnerDocument.CreateElement("module");
                activeModules.AppendChild(module);
                string moduleName = element.GetType().Name;
                string assemblyName = element.GetType().Assembly.FullName;
                string active;
                if (element.Active) active = "true";
                else active = "false";

                XmlAttribute moduleNameXML = activeModules.OwnerDocument.CreateAttribute("moduleName");
                moduleNameXML.Value = moduleName;
                module.Attributes.Append(moduleNameXML);

                XmlAttribute assemblyNameXML = activeModules.OwnerDocument.CreateAttribute("assemblyName");
                assemblyNameXML.Value = assemblyName;
                module.Attributes.Append(assemblyNameXML);

                module.InnerText = active;
            }
        }
        
        public void SaveAllLinguisticVariable(XmlElement parentNode)
        {
            foreach (var linguisticVariable in repository.GetCollection<LinguisticVariable>()) {
                XmlElement linguisticNode = parentNode.OwnerDocument.CreateElement("LingiusticVariable");
                parentNode.AppendChild(linguisticNode);

                XmlElement nameNode = parentNode.OwnerDocument.CreateElement("name");
                nameNode.InnerText = linguisticVariable.name;
                linguisticNode.AppendChild(nameNode);

                XmlElement inputNode = parentNode.OwnerDocument.CreateElement("isInput");
                inputNode.InnerText = linguisticVariable.isInput.ToString();
                linguisticNode.AppendChild(inputNode);

                XmlElement redactNode = parentNode.OwnerDocument.CreateElement("isRedact");
                redactNode.InnerText = linguisticVariable.isRedact.ToString();
                linguisticNode.AppendChild(redactNode);
                XmlElement objectsetNode = parentNode.OwnerDocument.CreateElement("baseSet");
                if (linguisticVariable.baseSet != null)
                {
                    objectsetNode.InnerText = linguisticVariable.baseSet.GetType().FullName + " " + linguisticVariable.baseSet.GetType().Assembly.FullName;
                }
                else
                {
                    objectsetNode.InnerText = "Нет базового множества";
                }
                linguisticNode.AppendChild(objectsetNode);
                XmlElement funcNode = parentNode.OwnerDocument.CreateElement("func");
                if (linguisticVariable.func.Count != 0) {
                    foreach (var function in linguisticVariable.func)
                    {
                        XmlElement functionNode = parentNode.OwnerDocument.CreateElement("Onefunction");
                        functionNode.InnerText = function.Item1.GetType().FullName + " " + function.Item1.GetType().Assembly.FullName;
                        funcNode.AppendChild(functionNode);
                        XmlAttribute moduleNameXML = parentNode.OwnerDocument.CreateAttribute("R");
                        moduleNameXML.Value = function.Item2.R.ToString();
                        functionNode.Attributes.Append(moduleNameXML);
                        moduleNameXML = parentNode.OwnerDocument.CreateAttribute("G");
                        moduleNameXML.Value = function.Item2.G.ToString();
                        functionNode.Attributes.Append(moduleNameXML);
                        moduleNameXML = parentNode.OwnerDocument.CreateAttribute("B");
                        moduleNameXML.Value = function.Item2.B.ToString();
                        functionNode.Attributes.Append(moduleNameXML);
                    }
                }
                else
                {
                    funcNode.InnerText = "Нет термов";
                }
                linguisticNode.AppendChild(funcNode);
            }
        }
    }
}