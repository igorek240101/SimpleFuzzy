using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Threading;
using System.Windows.Forms;

namespace SimpleFuzzy.View
{
    partial class InferenceForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // InferenceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "InferenceForm";
            Size = new Size(941, 490);
            ResumeLayout(false);
        }

        #endregion
    }
}
