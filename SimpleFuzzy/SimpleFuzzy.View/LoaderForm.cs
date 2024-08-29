using System.Linq;
using SimpleFuzzy.Abstract;
using System.Runtime.Loader;
using SimpleFuzzy.Model;

namespace SimpleFuzzy.View
{
    public partial class LoaderForm : UserControl
    {
        public IAssemblyLoaderService moduleLoaderService;
        public IRepositoryService repositoryService;
        public IProjectListService projectListService;
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
                moduleLoaderService.AssemblyLoader(filePath);
                foreach (var assemblyLoadContext in repositoryService.GetCollection<AssemblyContextModel>())
                {
                    if (assemblyLoadContext.AssemblyName == filePath)
                    {
                        messageTextBox.Text = assemblyLoadContext.AssemblyName;
                    }
                }
                File.Copy(filePath, Directory.GetCurrentDirectory() + "\\Projects\\" + projectListService.CurrentProjectName + "\\" + filePath.Split('\\')[^1]);
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
            catch (Exception ex)
            {
                messageTextBox.Text = $"Неизвестная ошибка: {ex.Message}";
            }
        }

        private void TreeViewShow()
        {
            foreach (TreeNode node in treeView1.Nodes) { node.Nodes.Clear(); }
            modules.Clear();
            List<IMembershipFunction> list1 = repositoryService.GetCollection<IMembershipFunction>();
            for (int i = 0; i < list1.Count; i++)
            {

                if (list1.Count(v => v.Name == list1[i].Name) > 1)
                {
                    treeView1.Nodes[0].Nodes.Add(list1[i].Name + " - " + list1[i].GetType().Name + " - " + list1[i].GetType().Assembly.Location);
                    modules.Add(list1[i].Name + " - " + list1[i].GetType().Name + " - " + list1[i].GetType().Assembly.Location, list1[i]);
                }
                else
                {
                    treeView1.Nodes[0].Nodes.Add(list1[i].Name);
                    modules.Add(list1[i].Name, list1[i]);
                }
                treeView1.Nodes[0].Nodes[^1].Checked = list1[i].Active;
                treeView1.Nodes[0].Nodes[^1].ToolTipText = list1[i].GetType().Assembly.Location;
            }
            treeView1.Nodes[0].Checked = list1.Any(t => t.Active);

            List<IObjectSet> list2 = repositoryService.GetCollection<IObjectSet>();
            for (int i = 0; i < list2.Count; i++)
            {
                if (list2.Count(v => v.Name == list2[i].Name) > 1)
                {
                    treeView1.Nodes[1].Nodes.Add(list2[i].Name + " - " + list2[i].GetType().Name + " - " + list2[i].GetType().Assembly.Location);
                    modules.Add(list2[i].Name + " - " + list2[i].GetType().Name + " - " + list2[i].GetType().Assembly.Location, list2[i]);
                }
                else
                {
                    treeView1.Nodes[1].Nodes.Add(list2[i].Name);
                    modules.Add(list2[i].Name, list2[i]);
                }
                treeView1.Nodes[1].Nodes[^1].Checked = list2[i].Active;
                treeView1.Nodes[1].Nodes[^1].ToolTipText = list2[i].GetType().Assembly.Location;
            }
            treeView1.Nodes[1].Checked = list2.Any(t => t.Active);

            List<ISimulator> list3 = repositoryService.GetCollection<ISimulator>();
            for (int i = 0; i < list3.Count; i++)
            {
                if (list3.Count(v => v.Name == list3[i].Name) > 1)
                {
                    treeView1.Nodes[2].Nodes.Add(list3[i].Name + " - " + list3[i].GetType().Name + " - " + list3[i].GetType().Assembly.Location);
                    modules.Add(list3[i].Name + " - " + list3[i].GetType().Name + " - " + list3[i].GetType().Assembly.Location, list3[i]);
                }
                else
                {
                    treeView1.Nodes[2].Nodes.Add(list3[i].Name);
                    modules.Add(list3[i].Name, list3[i]);
                }
                treeView1.Nodes[2].Nodes[^1].Checked = list3[i].Active;
                treeView1.Nodes[2].Nodes[^1].ToolTipText = list3[i].GetType().Assembly.Location;
            }
            treeView1.ExpandAll();
        }

        private void ParentChecked(TreeViewEventArgs e)
        {
            // Костыль для отключения симуляции
            if (e.Node == treeView1.Nodes[2] && e.Node.Checked)
            {
                e.Node.Checked = false;
                return;
            }

            // Общий случай включения всех детей
            foreach (TreeNode node in treeView1.Nodes)
            {
                if (node == e.Node)
                {
                    if (e.Node == treeView1.Nodes[2])
                    {
                        return;
                    }
                    foreach (TreeNode child in node.Nodes)
                    {
                        child.Checked = e.Node.Checked;
                        modules[child.Text].Active = e.Node.Checked;
                    }
                    return;
                }
            }

        }

        private void ChildChecked(TreeViewEventArgs e)
        {
            foreach (TreeNode node in treeView1.Nodes[2].Nodes)
            {
                if (node == e.Node)
                 {
                    if (e.Node.Checked)
                    {
                        if (Parent is MainWindow parent)
                        {
                            parent.isContainSimulator = true;
                            parent.EnableSimulationsButton(true);
                        }
                        if (repositoryService.GetCollection<ISimulator>().Any(v => v.Active) && !modules[e.Node.Text].Active)
                        {
                            DialogResult result = MessageBox.Show(
                            "Изменить симуляцию?",
                            "Симуляцию можно загрузить только одну",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.None,
                            MessageBoxDefaultButton.Button1);

                            if (result == DialogResult.Yes)
                            {
                                foreach (TreeNode node1 in treeView1.Nodes[2].Nodes)
                                {
                                    if (node1.Checked) 
                                    {
                                        node1.Checked = false;
                                        modules[node1.Text].Active = false;
                                        UnloadSimulationVariable(modules[node1.Text] as ISimulator);
                                    }
                                }
                                node.Checked = true;
                                modules[node.Text].Active = true;
                            }
                            else { node.Checked = false; }
                            return;
                        }
                    }
                    else
                    {
                        if (Parent is MainWindow parent)
                        {
                            parent.isContainSimulator = false;
                            UnloadSimulationVariable(modules[node.Text] as ISimulator);
                            parent.EnableSimulationsButton(false);
                        }
                    }
                }
            }
            modules[e.Node.Text].Active = e.Node.Checked;
            if (modules[e.Node.Text] is ISimulator sim && e.Node.Checked)
                LoadSimulationVariable(sim);

            if (e.Node.Parent != treeView1.Nodes[2])
            {
                if (e.Node.Parent.Nodes.OfType<TreeNode>().Any(t => t.Checked) && !e.Node.Parent.Checked)
                {
                    e.Node.Parent.Checked = true;
                }
                else if (e.Node.Parent.Nodes.OfType<TreeNode>().All(t => !t.Checked) && e.Node.Parent.Checked)
                {
                    e.Node.Parent.Checked = false;
                }
            }
        }

        private void LoadSimulationVariable(ISimulator simulator)
        {
            foreach(var variable in simulator.GetLinguisticVariables())
            {
                repositoryService.GetCollection<LinguisticVariable>().Add(new LinguisticVariable(
                    variable.Name, 
                    variable.IsInput, 
                    false, 
                    repositoryService.GetCollection<IObjectSet>().FirstOrDefault(t => t.GetType() == variable.BaseSet),
                    new List<(IMembershipFunction, Color)>()));
            }
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

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByKeyboard || e.Action == TreeViewAction.ByMouse)
            {
                if (e.Node == treeView1.Nodes[0] || e.Node == treeView1.Nodes[1] || e.Node == treeView1.Nodes[2])
                {

                    ParentChecked(e);
                }
                else
                {
                    ChildChecked(e);
                }
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
            const string message = "Вы уверенны, что хотите удалить выбранный файл?";
            const string caption = "Удаление элемента";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                moduleLoaderService.UnloadAssembly(LoadedAssembies[e.Item]);
                try { File.Delete(projectListService.GivePath(projectListService.CurrentProjectName, true) + "\\" + e.Item.Text); }
                catch (Exception ex)
                {
                    MessageBox.Show("Разработчики уже решают эту проблему)" + ex.Message, "Ошибка удаления");
                    return;
                }
                dllListView.Items.Remove(e.Item);
                TreeViewShow();
            }
        }
    }
}