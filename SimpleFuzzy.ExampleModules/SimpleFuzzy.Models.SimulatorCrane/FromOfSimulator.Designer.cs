namespace SimpleFuzzy.Models.SimulatorCrane
{
    partial class FromOfSimulator
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel cranePanel;
        public System.Windows.Forms.NumericUpDown numMassPendulum;
        public System.Windows.Forms.NumericUpDown numMassCart;
        public System.Windows.Forms.NumericUpDown numLengthPendulum;
        public System.Windows.Forms.NumericUpDown numDampingCart;
        public System.Windows.Forms.NumericUpDown numDampingPendulum;
        public System.Windows.Forms.NumericUpDown numInitialPosition;
        public System.Windows.Forms.NumericUpDown numInitialAngle;
        public System.Windows.Forms.NumericUpDown numBeamSize;
        public System.Windows.Forms.NumericUpDown numPlatformPosition;
        private System.Windows.Forms.Label lblInitialParams;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnReset;
        public System.Windows.Forms.TrackBar forceTrackBar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            forceTrackBar = new TrackBar();
            cranePanel = new Panel();
            numMassPendulum = new NumericUpDown();
            numMassCart = new NumericUpDown();
            numLengthPendulum = new NumericUpDown();
            numDampingCart = new NumericUpDown();
            numDampingPendulum = new NumericUpDown();
            numInitialAngle = new NumericUpDown();
            numInitialPosition = new NumericUpDown();
            numBeamSize = new NumericUpDown();
            numPlatformPosition = new NumericUpDown();
            btnStart = new Button();
            btnPause = new Button();
            btnReset = new Button();
            lblInitialParams = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)forceTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMassPendulum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMassCart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLengthPendulum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDampingCart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDampingPendulum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numInitialAngle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numInitialPosition).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBeamSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPlatformPosition).BeginInit();
            SuspendLayout();
            // 
            // forceTrackBar
            // 
            forceTrackBar.Location = new Point(625, 241);
            forceTrackBar.Maximum = 100;
            forceTrackBar.Minimum = -100;
            forceTrackBar.Name = "forceTrackBar";
            forceTrackBar.Size = new Size(150, 45);
            forceTrackBar.TabIndex = 0;
            forceTrackBar.TickFrequency = 10;
            forceTrackBar.Value = 8;
            forceTrackBar.ValueChanged += forceTrackBar_ValueChanged;
            // 
            // cranePanel
            // 
            cranePanel.BorderStyle = BorderStyle.FixedSingle;
            cranePanel.Location = new Point(12, 12);
            cranePanel.Name = "cranePanel";
            cranePanel.Size = new Size(600, 400);
            cranePanel.TabIndex = 0;
            // 
            // numMassPendulum
            // 
            numMassPendulum.DecimalPlaces = 2;
            numMassPendulum.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numMassPendulum.Location = new Point(629, 53);
            numMassPendulum.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numMassPendulum.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numMassPendulum.Name = "numMassPendulum";
            numMassPendulum.Size = new Size(105, 23);
            numMassPendulum.TabIndex = 1;
            numMassPendulum.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // numMassCart
            // 
            numMassCart.DecimalPlaces = 2;
            numMassCart.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numMassCart.Location = new Point(629, 100);
            numMassCart.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numMassCart.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            numMassCart.Name = "numMassCart";
            numMassCart.Size = new Size(105, 23);
            numMassCart.TabIndex = 2;
            numMassCart.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // numLengthPendulum
            // 
            numLengthPendulum.DecimalPlaces = 2;
            numLengthPendulum.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numLengthPendulum.Location = new Point(629, 147);
            numLengthPendulum.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            numLengthPendulum.Name = "numLengthPendulum";
            numLengthPendulum.Size = new Size(105, 23);
            numLengthPendulum.TabIndex = 3;
            numLengthPendulum.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // numDampingCart
            // 
            numDampingCart.DecimalPlaces = 4;
            numDampingCart.Increment = new decimal(new int[] { 1, 0, 0, 262144 });
            numDampingCart.Location = new Point(788, 100);
            numDampingCart.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numDampingCart.Name = "numDampingCart";
            numDampingCart.Size = new Size(105, 23);
            numDampingCart.TabIndex = 4;
            numDampingCart.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // numDampingPendulum
            // 
            numDampingPendulum.DecimalPlaces = 4;
            numDampingPendulum.Increment = new decimal(new int[] { 1, 0, 0, 262144 });
            numDampingPendulum.Location = new Point(788, 53);
            numDampingPendulum.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numDampingPendulum.Name = "numDampingPendulum";
            numDampingPendulum.Size = new Size(105, 23);
            numDampingPendulum.TabIndex = 5;
            numDampingPendulum.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // numInitialAngle
            // 
            numInitialAngle.DecimalPlaces = 2;
            numInitialAngle.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numInitialAngle.Location = new Point(788, 147);
            numInitialAngle.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
            numInitialAngle.Minimum = new decimal(new int[] { 90, 0, 0, int.MinValue });
            numInitialAngle.Name = "numInitialAngle";
            numInitialAngle.Size = new Size(105, 23);
            numInitialAngle.TabIndex = 7;
            // 
            // numInitialPosition
            // 
            numInitialPosition.DecimalPlaces = 2;
            numInitialPosition.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numInitialPosition.Location = new Point(629, 194);
            numInitialPosition.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numInitialPosition.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            numInitialPosition.Name = "numInitialPosition";
            numInitialPosition.Size = new Size(105, 23);
            numInitialPosition.TabIndex = 6;
            // 
            // numBeamSize
            // 
            numBeamSize.DecimalPlaces = 2;
            numBeamSize.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numBeamSize.Location = new Point(788, 194);
            numBeamSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numBeamSize.Name = "numBeamSize";
            numBeamSize.Size = new Size(105, 23);
            numBeamSize.TabIndex = 8;
            numBeamSize.Value = new decimal(new int[] { 30, 0, 0, 0 });
            numBeamSize.ValueChanged += numBeamSize_ValueChanged;
            // 
            // numPlatformPosition
            // 
            numPlatformPosition.DecimalPlaces = 2;
            numPlatformPosition.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numPlatformPosition.Location = new Point(788, 241);
            numPlatformPosition.Name = "numPlatformPosition";
            numPlatformPosition.Size = new Size(105, 23);
            numPlatformPosition.TabIndex = 9;
            numPlatformPosition.ValueChanged += numPlatformPosition_ValueChanged;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(625, 308);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(150, 30);
            btnStart.TabIndex = 6;
            btnStart.Text = "Старт";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(625, 343);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(150, 30);
            btnPause.TabIndex = 7;
            btnPause.Text = "Пауза";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(625, 379);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(150, 30);
            btnReset.TabIndex = 8;
            btnReset.Text = "Сброс";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // lblInitialParams
            // 
            lblInitialParams.Location = new Point(626, 12);
            lblInitialParams.Name = "lblInitialParams";
            lblInitialParams.Size = new Size(148, 20);
            lblInitialParams.TabIndex = 0;
            lblInitialParams.Text = "Параметры:";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(799, 308);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(107, 19);
            radioButton1.TabIndex = 10;
            radioButton1.TabStop = true;
            radioButton1.Text = "Ручной режим";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(799, 343);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(158, 19);
            radioButton2.TabIndex = 11;
            radioButton2.Text = "Автоматический режим";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // FromOfSimulator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(numPlatformPosition);
            Controls.Add(lblInitialParams);
            Controls.Add(numInitialPosition);
            Controls.Add(numInitialAngle);
            Controls.Add(forceTrackBar);
            Controls.Add(cranePanel);
            Controls.Add(numMassPendulum);
            Controls.Add(numMassCart);
            Controls.Add(numLengthPendulum);
            Controls.Add(numDampingCart);
            Controls.Add(numDampingPendulum);
            Controls.Add(numBeamSize);
            Controls.Add(btnStart);
            Controls.Add(btnPause);
            Controls.Add(btnReset);
            Name = "FromOfSimulator";
            Size = new Size(981, 433);
            ((System.ComponentModel.ISupportInitialize)forceTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMassPendulum).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMassCart).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLengthPendulum).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDampingCart).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDampingPendulum).EndInit();
            ((System.ComponentModel.ISupportInitialize)numInitialAngle).EndInit();
            ((System.ComponentModel.ISupportInitialize)numInitialPosition).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBeamSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPlatformPosition).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private RadioButton radioButton1;
        private RadioButton radioButton2;
    }
}
