using MetroFramework.Forms;
using MetroFramework;
using MetroFramework.Controls;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Service;
using System.Runtime.Loader;
using System.Reflection;

namespace SimpleFuzzy.View
{
    public partial class LoaderForm : MetroUserControl
    {
        private IAssemblyLoaderService moduleLoaderService;
        public LoaderForm()
        {
            InitializeComponent();
            moduleLoaderService = AutofacIntegration.GetInstance<IAssemblyLoaderService>();
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

                string assemblyName = moduleLoaderService.GetInfo(filePath);
                TreeViewShow();
                messageTextBox.Text = $"Модуль успешно загружен: {assemblyName}";
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
            var treeinfo = moduleLoaderService.AddElements(moduleLoaderService.AssemblyContextList);
            for (int i = 0; i < treeinfo.Item1.Count; i++) { treeView1.Nodes[0].Nodes.Add(treeinfo.Item1[i].Name); }
            for (int i = 0; i < treeinfo.Item2.Count; i++) { treeView1.Nodes[1].Nodes.Add(treeinfo.Item2[i].Name); }
            for (int i = 0; i < treeinfo.Item3.Count; i++) { treeView1.Nodes[2].Nodes.Add(treeinfo.Item3[i].Name); }
            if (treeView1.Nodes[2].Nodes.Count > 0 && Parent is MainWindow parent) parent.isContainSimulator = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) 
            {
                if (Parent is MainWindow parent)
                {
                    parent.isDisableSimulator = false;
                }
            }
            else
            {
                if (Parent is MainWindow parent)
                {
                    parent.isDisableSimulator = true;
                }
            }
        }
    }
}