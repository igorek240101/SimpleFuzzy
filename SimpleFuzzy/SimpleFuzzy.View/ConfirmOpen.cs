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
        ProjectListService projectList;
        SimpleFuzzy window;
        public ConfirmOpen(SimpleFuzzy mainWindow, ProjectListService project)
        {
            InitializeComponent();
            window = mainWindow;
            projectList = project;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string path = projectList.OpenExplorer(Directory.GetCurrentDirectory() + "\\Projects");
            if (path == "") { return; }
            try
            {
                if (projectList.IsContainsPath(path))
                {
                    // дальше по выбранной папке открывается проект
                    button2_Click(sender, e);
                }
                else { throw new InvalidOperationException("Проекта по этому адресу не существует"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
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
            if (listBox1.SelectedItem != null)
            {
                projectList.currentProjectName = listBox1.SelectedItem.ToString(); // Устанавливаем имя текущего проекта
                button2_Click(sender, e);
                // запуск проекта
            }
        }
    }
}
