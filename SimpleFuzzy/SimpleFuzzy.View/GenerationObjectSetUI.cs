using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.View
{
    public partial class GenerationObjectSetUI : Form
    {
        IGenerationObjectSetService service;
        ICompileService serviceCompile;
        IProjectListService projectListService;
        IAssemblyLoaderService assemblyLoaderService;
        public GenerationObjectSetUI()
        {
            service = AutofacIntegration.GetInstance<IGenerationObjectSetService>();
            serviceCompile = AutofacIntegration.GetInstance<ICompileService>();
            projectListService = AutofacIntegration.GetInstance<IProjectListService>();
            assemblyLoaderService = AutofacIntegration.GetInstance<IAssemblyLoaderService>();
            InitializeComponent();
        }

        private void ValidateInput(object sender, EventArgs e)
        {
            bool isValid = false;
            string errorMessage = "";
            if (numericUpDown2.Value == 0) errorMessage = "Шаг не может быть равен нулю.";
            else if (Math.Sign(numericUpDown3.Value - numericUpDown1.Value) != Math.Sign(numericUpDown2.Value)) errorMessage = "Направление шага не соответствует начальному и конечному значению.";
            else if (string.IsNullOrWhiteSpace(nameTextBox.Text)) errorMessage = "Имя не может быть пустым";
            else isValid = true;
            btnGenerate.Enabled = isValid;
            lblError.Text = errorMessage;
            lblError.AutoSize = true;
            lblError.MaximumSize = new Size(lblError.Parent.ClientSize.Width - 20, 0);
        }

        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            double first = (double)numericUpDown1.Value;
            double step = (double)numericUpDown2.Value;
            double last = (double)numericUpDown3.Value;

            try
            {
                string generatedCode = service.ReturnObjectSet(first, step, last, nameTextBox.Text);
                string dllName = $"BaseSet-{DateTime.Now.Ticks}";
                var compile = serviceCompile.Compile(generatedCode);
                serviceCompile.Save($"{projectListService.GivePath(projectListService.CurrentProjectName, true)}\\{dllName}.dll", compile.Item1);
                assemblyLoaderService.AssemblyLoader($"{projectListService.GivePath(projectListService.CurrentProjectName, true)}\\{dllName}.dll");
                Close();
            }
            catch (InvalidOperationException ex) { MessageBox.Show(ex.Message, "Ошибка при создании множества", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
