﻿using MetroFramework.Forms;
using MetroFramework;
using MetroFramework.Controls;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Service;
using System.Runtime.Loader;
using System.Runtime.InteropServices;
using WindowsFormsApplication1;

namespace SimpleFuzzy.View
{
    public partial class LoaderForm : MetroUserControl
    {
        public IAssemblyLoaderService moduleLoaderService;
        public IRepositoryService repositoryService;
        Dictionary<string, IModulable> modules = new Dictionary<string, IModulable>(); 
        public LoaderForm()
        {
            InitializeComponent();
            moduleLoaderService = AutofacIntegration.GetInstance<IAssemblyLoaderService>();
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
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
                    treeView1.Nodes[0].Nodes.Add(list1[i].Name + " - " +  list1[i].GetType().Assembly.Location);
                    modules.Add(list1[i].Name + " - " + list1[i].GetType().Assembly.Location, list1[i]);
                }
                else
                {
                    treeView1.Nodes[0].Nodes.Add(list1[i].Name);
                    modules.Add(list1[i].Name, list1[i]);
                }
                treeView1.Nodes[0].Nodes[^1].Checked = list1[i].Active;
                treeView1.Nodes[0].Nodes[^1].ToolTipText = list1[i].GetType().Assembly.Location;
            }
            List<IObjectSet> list2 = repositoryService.GetCollection<IObjectSet>();
            for (int i = 0; i < list2.Count; i++) 
            {
                if (list2.Count(v => v.Name == list2[i].Name) > 1)
                {
                    treeView1.Nodes[1].Nodes.Add(list2[i].Name + " - " + list2[i].GetType().Assembly.Location);
                    modules.Add(list2[i].Name + " - " + list2[i].GetType().Assembly.Location, list2[i]);
                }
                else
                {
                    treeView1.Nodes[1].Nodes.Add(list2[i].Name);
                    modules.Add(list2[i].Name, list2[i]);
                }
                treeView1.Nodes[1].Nodes[^1].Checked = list2[i].Active;
                treeView1.Nodes[1].Nodes[^1].ToolTipText = list2[i].GetType().Assembly.Location;
            }
            List<ISimulator> list3 = repositoryService.GetCollection<ISimulator>();
            for (int i = 0; i < list3.Count; i++) 
            {
                if (list3.Count(v => v.Name == list3[i].Name) > 1)
                {
                    treeView1.Nodes[2].Nodes.Add(list3[i].Name + " - " + list3[i].GetType().Assembly.Location);
                    modules.Add(list3[i].Name + " - " + list3[i].GetType().Assembly.Location, list3[i]);
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
            if (treeView1.Nodes[2].Nodes.Count > 0 && Parent is MainWindow parent) parent.isContainSimulator = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (Parent is MainWindow parent)
                {
                    parent.isDisableSimulator = true;
                }
            }
            else
            {
                if (Parent is MainWindow parent)
                {
                    parent.isDisableSimulator = false;
                }
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node == treeView1.Nodes[2] && e.Node.Checked) 
            {
                e.Node.Checked = false;
                return;
            }
            foreach (TreeNode node in treeView1.Nodes)
            {
                if (node == e.Node) 
                {
                    foreach(TreeNode child in node.Nodes) { child.Checked = e.Node.Checked; }
                    return;
                }
            }
            modules[e.Node.Text].Active = e.Node.Checked;
            if (repositoryService.GetCollection<ISimulator>().Any(v => v.Active)) { }
            else { }
        }
        //----------------------------------------------------------------------------------------


        public void CreateDllList(AssemblyLoadContext dll)
        {
            InitializeComponent();
            dllListView.FullRowSelect = true;
            dllListView.Scrollable = true;
            ListViewExtender extender = new ListViewExtender(dllListView);
            ListViewButtonColumn buttonAction = new ListViewButtonColumn(1);
            buttonAction.Click += OnButtonActionClick;
            buttonAction.FixedWidth = true;
            extender.AddColumn(buttonAction);
            ListViewItem item = dllListView.Items.Add(dll.Name);
            item.SubItems.Add("X");

            string dllInfo = "Полное имя файла:\n" + dll.GetType().Assembly.Location + "\n" + "\n";

            Type[] array = dll.Assemblies.ElementAt(0).GetTypes();
            //--------------------------------------------------------------------------------------
            dllInfo += "Термы:\n";
            List<IMembershipFunction> MembershipList = repositoryService.GetCollection<IMembershipFunction>();
            foreach (Type type in array) {
                foreach (var type2 in MembershipList) {
                    if(type == type2.GetType())
                    {
                        dllInfo += "    " + type2.Name + "\n";
                    }
                }
            }
            //----------------------------------------------------------------------------------
            dllInfo += "Симуляции:\n";
            List<ISimulator> SimulationshipList = repositoryService.GetCollection<ISimulator>();
            foreach (Type type in array)
            {
                foreach (var type2 in SimulationshipList)
                {
                    if (type == type2.GetType())
                    {
                        dllInfo += "    " + type2.Name + "\n";
                    }
                }
            }
            //-----------------------------------------------------------------------------------
            dllInfo += "Базовые множества:\n";
            List<IObjectSet> ObjectSetList = repositoryService.GetCollection<IObjectSet>();
            foreach (Type type in array)
            {
                foreach (var type2 in ObjectSetList)
                {
                    if (type == type2.GetType())
                    {
                        dllInfo += "    " + type2.Name + "\n";
                    }
                }
            }
            //----------------------------------------------------------------------------------
            item.ToolTipText = dllInfo;
        }
        //----------------------------------------------------------------------------------------
        private void OnButtonActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            const string message = "Вы уверенны, что хотите удалить выбранный файл?";
            const string caption = "Удаление элемента";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question); if (result == DialogResult.No)
                if (result == DialogResult.No)
                {
                    CloseMessageBox();
                }
                else if (result == DialogResult.Yes)
                {
                    dllListView.Items.Remove(sender as ListViewItem);
                    CloseMessageBox();
                }
        }

        //----------------------------------------------------------------------------------------
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.Dll")]
        static extern int PostMessage(IntPtr hWnd, UInt32 msg, int wParam, int lParam);

        const UInt32 WM_CLOSE = 0x0010;

        Thread thread;
        void CloseMessageBox()
        {
            IntPtr hWnd = FindWindowByCaption(IntPtr.Zero, "Удаление элемента");
            if (hWnd != IntPtr.Zero)
                PostMessage(hWnd, WM_CLOSE, 0, 0);

            if (thread.IsAlive)
                thread.Abort();
        }
    }
}