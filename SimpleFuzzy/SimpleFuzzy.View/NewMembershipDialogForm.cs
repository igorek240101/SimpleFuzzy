using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFuzzy.View
{
    public partial class NewMembershipDialogForm : Form
    {
        IObjectSet ObjectSet { get; set; }
        FuzzyOperation FuzzyOperation { get; set; }
        IAssemblyLoaderService assemblyLoaderService;

        UserControl UserControl { get; set; }
        public NewMembershipDialogForm()
        {
            InitializeComponent();
        }

        public NewMembershipDialogForm(IObjectSet objectSet) : this()
        {
            assemblyLoaderService = AutofacIntegration.GetInstance<IAssemblyLoaderService>();
            ObjectSet = objectSet;
            GenerationMembershipUI generationMembershipUI = new GenerationMembershipUI(ObjectSet);
            generationMembershipUI.Location = new Point(0, 20);
            UserControl = generationMembershipUI;
            Controls.Add(generationMembershipUI);
        }

        public NewMembershipDialogForm(FuzzyOperation fuzzyOperation, IObjectSet objectSet) : this()
        {
            ObjectSet = objectSet;
            FuzzyOperation = fuzzyOperation;
            metroRadioButton2.Checked = true;
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Controls.Remove(UserControl);
            if (metroRadioButton1.Checked)
            {
                GenerationMembershipUI generationMembershipUI = new GenerationMembershipUI(ObjectSet);
                generationMembershipUI.Location = new Point(15, 40);
                UserControl = generationMembershipUI;
                Controls.Add(generationMembershipUI);
            }
            else
            {
                if (FuzzyOperation == null)
                {
                    FuzzyOperation = new FuzzyOperation();
                    assemblyLoaderService.UseAssembly += FuzzyOperation.UnloadHandler;
                }
                FuzzyOperationUI fuzzy = new FuzzyOperationUI(FuzzyOperation, ObjectSet, () => Close() );
                fuzzy.Location = new Point(15, 40);
                UserControl = fuzzy;
                Controls.Add(fuzzy);
            }
        }
    }
}
