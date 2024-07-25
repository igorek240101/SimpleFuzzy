using SimpleFuzzy.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimpleFuzzy.View
{
    public partial class ConfirmOpen : UserControl
    {
        ProjectList projectList;
        MainWindow window;
        public ConfirmOpen()
        {
            InitializeComponent();
            label1.Text = "Введите имя проекта";
            button1.Text = "Открыть проводник";
            button2.Text = "Отмена";
            listBox1.ScrollAlwaysVisible = true;
        }
        public ConfirmOpen(MainWindow mainWindow, ProjectList project) : this()
        {
            window = mainWindow;
            projectList = project;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.SelectedPath = Directory.GetCurrentDirectory() + "\\Projects";
            if (dialog.ShowDialog() == DialogResult.Cancel) { return; }
            try
            {
                string path = dialog.SelectedPath;
                string[] list = projectList.GiveList();
                bool isContains = false;
                for (int i = 1; i < list.Length; i++)
                {
                    if (path == list[i])
                    {
                        isContains = true;
                        projectList.currentProjectName = list[i - 1]; // Устанавливаем имя текущего проекта
                    }
                }
                if (!isContains) { throw new InvalidOperationException("Проекта по этому адресу не существует"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            window.OpenButtons(sender, e);
            window.Locked(sender, e);
            window.Controls.Remove(this);
            // дальше по выбранной папке открывается проект
        }

        private void button2_Click(object sender, EventArgs e)
        {
            window.OpenButtons(sender, e);
            window.Locked(sender, e);
            window.Controls.Remove(this);
        }

        private void ConfirmOpen_Load(object sender, EventArgs e)
        {
            window.BlockButtons(sender, e);
            label2.Visible = false;
            string[] list = projectList.GiveList();
            for (int i = 0; i < list.Length; i += 3) { listBox1.Items.Add(list[i]); }
            if (listBox1.Items.Count == 0)
            {
                label2.Text = "Проектов пока нет, перейдите к созданию проекта";
                label2.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (listBox1 == null) { return; }
            label2.Visible = false;
            string[] list = projectList.GiveList();
            bool isEmpty = true;
            listBox1.Items.Clear();
            for (int i = 0; i < list.Length; i += 3)
            {
                bool isContain = true;
                for (int j = 0; j < textBox1.Text.Length && j < list[i].Length; j++)
                {
                    if (list[i][j] != textBox1.Text[j])
                    {
                        isContain = false;
                        break;
                    }
                }
                if (isContain && textBox1.Text.Length <= list[i].Length)
                {
                    listBox1.Items.Add(list[i]);
                    isEmpty = false;
                }
            }
            if (isEmpty)
            {
                label2.Text = "Файлов с таким именем не найдено...";
                label2.Visible = true;
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            {
                if (listBox1.SelectedItem != null)
                {
                    projectList.currentProjectName = listBox1.SelectedItem.ToString(); // Устанавливаем имя текущего проекта
                    window.OpenButtons(sender, e);
                    window.Locked(sender, e);
                    window.Controls.Remove(this);
                    // запуск проекта
                }
            }
        }
    }
}
