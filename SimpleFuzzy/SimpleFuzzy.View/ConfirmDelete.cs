using SimpleFuzzy.Abstract;


namespace SimpleFuzzy.View
{
    public partial class ConfirmDelete : UserControl
    {
        IProjectListService projectList;
        public ConfirmDelete()
        {
            InitializeComponent();
            projectList = AutofacIntegration.GetInstance<IProjectListService>();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try { projectList.DeleteProject(projectList.CurrentProjectName); }
            catch 
            {
                MessageBox.Show("Пожалуйста, сообщите об этой проблеме разработчикам", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Parent is MainWindow parent)
            {
                parent.ChangeNameOfProject();
                parent.Locked();
                parent.ColorDelete();
            }
            Parent.Controls.Remove(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Parent is MainWindow parent && parent.lastControlEnum != null)
            {
                parent.SwichUserControl(parent.lastControlEnum, parent.lastButton);
            }
            else { Parent.Controls.Remove(this); }
        }
    }
}
