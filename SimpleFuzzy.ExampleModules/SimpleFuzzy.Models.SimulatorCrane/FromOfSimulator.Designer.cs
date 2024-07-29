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
            this.forceTrackBar = new System.Windows.Forms.TrackBar();
            this.cranePanel = new System.Windows.Forms.Panel();
            this.numMassPendulum = new System.Windows.Forms.NumericUpDown();
            this.numMassCart = new System.Windows.Forms.NumericUpDown();
            this.numLengthPendulum = new System.Windows.Forms.NumericUpDown();
            this.numDampingCart = new System.Windows.Forms.NumericUpDown();
            this.numDampingPendulum = new System.Windows.Forms.NumericUpDown();
            this.numInitialAngle = new System.Windows.Forms.NumericUpDown();
            this.numInitialPosition = new System.Windows.Forms.NumericUpDown();
            this.numBeamSize = new System.Windows.Forms.NumericUpDown();
            this.numPlatformPosition = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblInitialParams = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.forceTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMassPendulum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMassCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLengthPendulum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDampingCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDampingPendulum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeamSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlatformPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // forceTrackBar
            // 
            this.forceTrackBar.Location = new System.Drawing.Point(714, 266);
            this.forceTrackBar.Maximum = 100;
            this.forceTrackBar.Minimum = -100;
            this.forceTrackBar.Name = "forceTrackBar";
            this.forceTrackBar.Size = new System.Drawing.Size(171, 56);
            this.forceTrackBar.TabIndex = 0;
            this.forceTrackBar.TickFrequency = 10;
            this.forceTrackBar.Value = 8;
            this.forceTrackBar.ValueChanged += new System.EventHandler(this.forceTrackBar_ValueChanged);
            // 
            // cranePanel
            // 
            this.cranePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cranePanel.Location = new System.Drawing.Point(14, 13);
            this.cranePanel.Name = "cranePanel";
            this.cranePanel.Size = new System.Drawing.Size(685, 427);
            this.cranePanel.TabIndex = 0;
            // 
            // numMassPendulum
            // 
            this.numMassPendulum.DecimalPlaces = 2;
            this.numMassPendulum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numMassPendulum.Location = new System.Drawing.Point(719, 57);
            this.numMassPendulum.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numMassPendulum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numMassPendulum.Name = "numMassPendulum";
            this.numMassPendulum.Size = new System.Drawing.Size(120, 22);
            this.numMassPendulum.TabIndex = 1;
            this.numMassPendulum.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numMassCart
            // 
            this.numMassCart.DecimalPlaces = 2;
            this.numMassCart.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numMassCart.Location = new System.Drawing.Point(719, 107);
            this.numMassCart.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numMassCart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numMassCart.Name = "numMassCart";
            this.numMassCart.Size = new System.Drawing.Size(120, 22);
            this.numMassCart.TabIndex = 2;
            this.numMassCart.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numLengthPendulum
            // 
            this.numLengthPendulum.DecimalPlaces = 2;
            this.numLengthPendulum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numLengthPendulum.Location = new System.Drawing.Point(719, 157);
            this.numLengthPendulum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numLengthPendulum.Name = "numLengthPendulum";
            this.numLengthPendulum.Size = new System.Drawing.Size(120, 22);
            this.numLengthPendulum.TabIndex = 3;
            this.numLengthPendulum.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numDampingCart
            // 
            this.numDampingCart.DecimalPlaces = 4;
            this.numDampingCart.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numDampingCart.Location = new System.Drawing.Point(900, 107);
            this.numDampingCart.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDampingCart.Name = "numDampingCart";
            this.numDampingCart.Size = new System.Drawing.Size(120, 22);
            this.numDampingCart.TabIndex = 4;
            this.numDampingCart.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numDampingPendulum
            // 
            this.numDampingPendulum.DecimalPlaces = 4;
            this.numDampingPendulum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numDampingPendulum.Location = new System.Drawing.Point(900, 57);
            this.numDampingPendulum.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDampingPendulum.Name = "numDampingPendulum";
            this.numDampingPendulum.Size = new System.Drawing.Size(120, 22);
            this.numDampingPendulum.TabIndex = 5;
            this.numDampingPendulum.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numInitialAngle
            // 
            this.numInitialAngle.DecimalPlaces = 2;
            this.numInitialAngle.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numInitialAngle.Location = new System.Drawing.Point(900, 157);
            this.numInitialAngle.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numInitialAngle.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.numInitialAngle.Name = "numInitialAngle";
            this.numInitialAngle.Size = new System.Drawing.Size(120, 22);
            this.numInitialAngle.TabIndex = 7;
            // 
            // numInitialPosition
            // 
            this.numInitialPosition.DecimalPlaces = 2;
            this.numInitialPosition.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numInitialPosition.Location = new System.Drawing.Point(719, 207);
            this.numInitialPosition.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numInitialPosition.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numInitialPosition.Name = "numInitialPosition";
            this.numInitialPosition.Size = new System.Drawing.Size(120, 22);
            this.numInitialPosition.TabIndex = 6;
            // 
            // numBeamSize
            // 
            this.numBeamSize.DecimalPlaces = 2;
            this.numBeamSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numBeamSize.Location = new System.Drawing.Point(900, 207);
            this.numBeamSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBeamSize.Name = "numBeamSize";
            this.numBeamSize.Size = new System.Drawing.Size(120, 22);
            this.numBeamSize.TabIndex = 8;
            this.numBeamSize.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numBeamSize.ValueChanged += new System.EventHandler(this.numBeamSize_ValueChanged);
            // 
            // numPlatformPosition
            // 
            this.numPlatformPosition.DecimalPlaces = 2;
            this.numPlatformPosition.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numPlatformPosition.Location = new System.Drawing.Point(900, 257);
            this.numPlatformPosition.Name = "numPlatformPosition";
            this.numPlatformPosition.Size = new System.Drawing.Size(120, 22);
            this.numPlatformPosition.TabIndex = 9;
            this.numPlatformPosition.ValueChanged += new System.EventHandler(this.numPlatformPosition_ValueChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(714, 328);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(171, 32);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(714, 366);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(171, 32);
            this.btnPause.TabIndex = 7;
            this.btnPause.Text = "Пауза";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(714, 404);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(171, 32);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblInitialParams
            // 
            this.lblInitialParams.Location = new System.Drawing.Point(716, 13);
            this.lblInitialParams.Name = "lblInitialParams";
            this.lblInitialParams.Size = new System.Drawing.Size(169, 21);
            this.lblInitialParams.TabIndex = 0;
            this.lblInitialParams.Text = "Параметры:";
            // 
            // VisualCrane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 462);
            this.Controls.Add(this.numPlatformPosition);
            this.Controls.Add(this.lblInitialParams);
            this.Controls.Add(this.numInitialPosition);
            this.Controls.Add(this.numInitialAngle);
            this.Controls.Add(this.forceTrackBar);
            this.Controls.Add(this.cranePanel);
            this.Controls.Add(this.numMassPendulum);
            this.Controls.Add(this.numMassCart);
            this.Controls.Add(this.numLengthPendulum);
            this.Controls.Add(this.numDampingCart);
            this.Controls.Add(this.numDampingPendulum);
            this.Controls.Add(this.numBeamSize);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnReset);
            this.Name = "VisualCrane";
            this.Text = "Симулятор крана";
            ((System.ComponentModel.ISupportInitialize)(this.forceTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMassPendulum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMassCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLengthPendulum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDampingCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDampingPendulum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeamSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlatformPosition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
