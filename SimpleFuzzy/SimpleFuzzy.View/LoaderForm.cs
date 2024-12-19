using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;

namespace SimpleFuzzy.View
{
    public partial class LoaderForm : UserControl
    {
        public IAssemblyLoaderService moduleLoaderService;
        public IRepositoryService repositoryService;
        public IProjectListService projectListService;
        private IDefazificationService defazificationService;
        Dictionary<string, IModulable> modules = new Dictionary<string, IModulable>();
        Dictionary<ListViewItem, string> LoadedAssembies = new Dictionary<ListViewItem, string>();
        public LoaderForm()
        {
            InitializeComponent();
            dllListView.Columns.AddRange(new ColumnHeader[] { FileName, CloseButton });
            ListViewExtender extender = new ListViewExtender(dllListView);
            ListViewButtonColumn buttonAction = new ListViewButtonColumn(1);
            buttonAction.Click += OnButtonActionClick;
            buttonAction.FixedWidth = true;
            extender.AddColumn(buttonAction);
            moduleLoaderService = AutofacIntegration.GetInstance<IAssemblyLoaderService>();
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            projectListService = AutofacIntegration.GetInstance<IProjectListService>();
            defazificationService = AutofacIntegration.GetInstance<IDefazificationService>();
            RefreshDllList(repositoryService.GetCollection<AssemblyContextModel>());
            TreeViewShow();

            moduleLoaderService.UseAssembly += AssemblyHandler;
        }

        public void AssemblyHandler(object sender, EventArgs e)
        {
            modules.Clear();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "DLL files (*.dll)|*.dll";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePathTextBox.Text = openFileDialog.FileName;
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            string filePath = filePathTextBox.Text;
            if (string.IsNullOrWhiteSpace(filePath))
            {
                messageTextBox.Text = "Пожалуйста, укажите путь к файлу.";
                return;
            }

            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("Указанный файл не существует.", filePath);
                }

                if (Path.GetExtension(filePath).ToLower() != ".dll")
                {
                    throw new FileFormatException("Файл должен иметь расширение .dll");
                }
                foreach (var assemblyLoadContext in repositoryService.GetCollection<AssemblyContextModel>())
                {
                    if (FileCompare(assemblyLoadContext.AssemblyName, filePath))
                    {
                        throw new FileLoadException("Загружаемый dll файл уже есть в домене приложения");
                    }
                }
                string newPath = Directory.GetCurrentDirectory() + "\\Projects\\" +
                    projectListService.CurrentProjectName + "\\" + filePath.Split('\\')[^1];
                File.Copy(filePath, newPath);
                moduleLoaderService.AssemblyLoader(newPath);
                foreach (var assemblyLoadContext in repositoryService.GetCollection<AssemblyContextModel>())
                {
                    if (assemblyLoadContext.AssemblyName == newPath)
                    {
                        messageTextBox.Text = assemblyLoadContext.AssemblyName;
                    }
                }
                RefreshDllList(repositoryService.GetCollection<AssemblyContextModel>());
                TreeViewShow();
            }
            catch (FileNotFoundException ex)
            {
                messageTextBox.Text = $"Ошибка: Файл не найден. {ex.Message}";
            }
            catch (FileFormatException ex)
            {
                messageTextBox.Text = $"Ошибка: Неверный формат файла. {ex.Message}";
            }
            catch (FileLoadException ex)
            {
                messageTextBox.Text = $"Ошибка: Загрузка файла невозможна. {ex.Message}";
            }
            catch (Exception ex)
            {
                messageTextBox.Text = $"Неизвестная ошибка: {ex.Message}";
            }
        }

        private bool FileCompare(string file1, string file2)
        {
            int file1byte;
            int file2byte;

            if (file1.Split('\\')[^1] != file2.Split('\\')[^1])
            {
                return false;
            }
            FileStream fs1 = File.OpenRead(file1);
            FileStream fs2 = File.OpenRead(file2);
            if (fs1.Length != fs2.Length)
            {
                fs1.Close();
                fs2.Close();
                return false;
            }
            do
            {
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1 || file2byte != -1));
            fs1.Close();
            fs2.Close();
            return ((file1byte - file2byte) == 0);
        }

        private void TreeViewShow()
        {
            RadioTree radioTree = new RadioTree();
            groupBoxModules.Controls.Add(radioTree);
            radioTree.Location = treeView1.Location;
            radioTree.Size = treeView1.Size;
            groupBoxModules.Controls.Remove(treeView1);
            treeView1 = radioTree;
            treeView1.BaseSetCheckedChange += BaseSetCheck;
            treeView1.TermCheckedChange += TermCheck;
            treeView1.SimulatorCheckedChange += SimulatorCheck;
            modules.Clear();
            List<IMembershipFunction> list1 = repositoryService.GetCollection<IMembershipFunction>();
            for (int i = 0; i < list1.Count; i++)
            {
                string name;
                if (list1.Count(v => v.Name == list1[i].Name) > 1)
                    name = list1[i].Name + " - " + list1[i].GetType().Name + " - " + list1[i].GetType().Assembly.Location;
                else
                    name = list1[i].Name;
                modules.Add(name, list1[i]);
                treeView1.AddTerm(name, list1[i].Active, list1[i].GetType().Assembly.Location);
            }

            List<IObjectSet> list2 = repositoryService.GetCollection<IObjectSet>();
            for (int i = 0; i < list2.Count; i++)
            {
                string name;
                if (list2.Count(v => v.Name == list2[i].Name) > 1)
                    name = list2[i].Name + " - " + list2[i].GetType().Name + " - " + list2[i].GetType().Assembly.Location;
                else
                    name = list2[i].Name;
                modules.Add(name, list2[i]);
                treeView1.AddSet(name, list2[i].Active, list2[i].GetType().Assembly.Location);
            }

            List<ISimulator> list3 = repositoryService.GetCollection<ISimulator>();
            for (int i = 0; i < list3.Count; i++)
            {
                string name;
                if (list3.Count(v => v.Name == list3[i].Name) > 1)
                    name = list3[i].Name + " - " + list3[i].GetType().Name + " - " + list3[i].GetType().Assembly.Location;
                else
                    name = list3[i].Name;
                modules.Add(name, list3[i]);
                treeView1.AddSimualtor(name, list3[i].Active, list3[i].GetType().Assembly.Location);
            }
            treeView1.ExpandAll();
        }

        private void BaseSetCheck(object sender, EventArgs e)
            => modules[(sender as CheckBox).Text].Active = (sender as CheckBox).Checked;

        private void TermCheck(object sender, EventArgs e)
            => modules[(sender as CheckBox).Text].Active = (sender as CheckBox).Checked;

        private void SimulatorCheck(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            modules[radio.Text].Active = radio.Checked;
            if (radio.Checked)
            {
                LoadSimulationVariable(modules[radio.Text] as ISimulator);
                if (Parent is MainWindow parent)
                {
                    parent.isContainSimulator = true;
                    parent.EnableSimulationsButton(true);
                }
            }
            else
            {
                UnloadSimulationVariable(modules[radio.Text] as ISimulator);
                if (Parent is MainWindow parent)
                {
                    parent.isContainSimulator = false;
                    parent.EnableSimulationsButton(false);
                }
            }
        }

        private void LoadSimulationVariable(ISimulator simulator)
        {
            foreach (var variable in simulator.GetLinguisticVariables())
            {
                var list = repositoryService.GetCollection<LinguisticVariable>();
                list.Add(new LinguisticVariable(
                    variable.Name,
                    variable.IsInput,
                    false,
                    repositoryService.GetCollection<IObjectSet>().FirstOrDefault(t => t.GetType() == variable.BaseSet),
                    new List<(IMembershipFunction, Color)>()));
                list[^1].ListRules = new SetRule(list[^1]);
            }
            simulator.SetController(defazificationService.DefazificationSimulator);
        }

        private void UnloadSimulationVariable(ISimulator simulator)
        {
            foreach (var variable in simulator.GetLinguisticVariables())
            {
                repositoryService.GetCollection<LinguisticVariable>().RemoveAll(t =>
                    t.Name == variable.Name &&
                    t.IsInput == variable.IsInput &&
                    t.baseSet.GetType() == variable.BaseSet &&
                    !t.isRedact);
            }
        }
        //----------------------------------------------------------------------------------------


        public void RefreshDllList(List<AssemblyContextModel> dllList)
        {
            dllListView.Items.Clear();
            foreach (var dll in dllList)
            {
                string s = dll.AssemblyName;
                ListViewItem item = dllListView.Items.Add(s.Split('\\')[^1]);
                LoadedAssembies.Add(dllListView.Items[^1], s);
                string dllInfo = dll.AssemblyName + "\n" + "\n";
                item.SubItems.Add("X");
                FileName.Width = -1;
                //--------------------------------------------------------------------------------------
                s = "";
                s += repositoryService.GetCollection<IObjectSet>().
                        Where(t => t.GetType().Assembly.Location == dll.AssemblyName).AsQueryable().
                        Aggregate("Базовые множества:\n", (x, y) => x + "    " + y.Name + "\n");
                if (s != "Базовые множества:\n") dllInfo += s;
                s = "";
                s += repositoryService.GetCollection<IMembershipFunction>().
                        Where(t => t.GetType().Assembly.Location == dll.AssemblyName).AsQueryable().
                        Aggregate("Термы:\n", (x, y) => x + "    " + y.Name + "\n");
                if (s != "Термы:\n") dllInfo += s;
                s = "";
                s += repositoryService.GetCollection<ISimulator>().
                        Where(t => t.GetType().Assembly.Location == dll.AssemblyName).AsQueryable().
                        Aggregate("Симуляции:\n", (x, y) => x + "    " + y.Name + "\n");
                if (s != "Симуляции:\n") dllInfo += s;
                //----------------------------------------------------------------------------------
                item.ToolTipText = dllInfo;
            }
        }
        //----------------------------------------------------------------------------------------
        private void OnButtonActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            const string message = "Удалить выбранный файл?";
            const string caption = "Удаление элемента";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                moduleLoaderService.UnloadAssembly(LoadedAssembies[e.Item]);
                try { File.Delete(projectListService.GivePath(projectListService.CurrentProjectName, true) + "\\" + e.Item.Text); }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}, Пожалуйста, сообщите об этой ошибки разработчикам", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dllListView.Items.Remove(e.Item);
                TreeViewShow();
            }
        }
    }
}