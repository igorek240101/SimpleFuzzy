using System;
using System.IO;
using System.Windows.Forms;
using SimpleFuzzy.Service;
// Из-за возможной несовместимости Metroframework и .NET 6.0,
// пришлось переделать приложение под WinForms

namespace SimpleFuzzy.View
{
    public partial class LoaderForm : UserControl
    {
        private readonly SimpleFuzzy.Service.AssemblyLoaderService assemblyLoaderService;

        public LoaderForm()
        {
            InitializeComponent();
            assemblyLoaderService = new SimpleFuzzy.Service.AssemblyLoaderService();
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

                string assemblyName = assemblyLoaderService.GetInfo(filePath);
                messageTextBox.Text = $"Модуль успешно загружен: {assemblyName}";
            }
            catch (FileNotFoundException ex)
            {
                messageTextBox.Text = $"Ошибка: Файл не найден. {ex.Message}";
            }
            catch (BadImageFormatException ex)
            {
                messageTextBox.Text = $"Ошибка: Неверный формат файла. {ex.Message}";
            }
            catch (Exception ex)
            {
                messageTextBox.Text = $"Ошибка при загрузке модуля: {ex.Message}";
            }
        }
    }
}