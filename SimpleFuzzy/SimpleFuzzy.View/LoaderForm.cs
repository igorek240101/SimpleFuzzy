using MetroFramework.Forms;
using MetroFramework;
using MetroFramework.Controls;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Service;

namespace SimpleFuzzy.View
{
    public partial class LoaderForm : MetroUserControl
    {
        private IAssemblyLoaderService moduleLoaderService;
        private MainWindow mainWindow; // Ссылка на MainWindow
        public LoaderForm(MainWindow mainWindow)
        {
            InitializeComponent();
            moduleLoaderService = AutofacIntegration.GetInstance<IAssemblyLoaderService>();
            this.mainWindow = mainWindow;

            checkBox1.Checked = mainWindow.SimulationEnabled;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            mainWindow.SimulationEnabled = checkBox1.Checked;
            mainWindow.UpdateSimulationStatus(checkBox1.Checked);
        }
    }
}