﻿using SimpleFuzzy.Abstract;


namespace SimpleFuzzy.Models.SimulatorCrane
{
    public partial class FromOfSimulator : UserControl
    {
        private CraneSimulator simulator;
        private System.Windows.Forms.Timer timer;
        private bool isSimulationRunning = false;

        public FromOfSimulator()
        {
            InitializeComponent();
            SetupSimulator();
            SetupControls();

            timer = new System.Windows.Forms.Timer { Interval = 16 }; // ~60 FPS
            timer.Tick += (s, e) => simulator.Step();
        }        

        private void SetupSimulator()
        {
            simulator = new CraneSimulator();
            simulator.StateChanged += OnSimulatorStateChanged;

            timer = new System.Windows.Forms.Timer { Interval = 16 }; // ~60 FPS
            timer.Tick += (s, e) => simulator.Step();
        }

        // Изменения значений
        private void forceTrackBar_ValueChanged(object sender, EventArgs e) => simulator.ApplyForce(forceTrackBar.Value / 10.0);
        private void numBeamSize_ValueChanged(object sender, EventArgs e)
        {
            simulator.SetBeamSize((double)numBeamSize.Value);
            numInitialPosition.Maximum = numBeamSize.Value;
            numPlatformPosition.Maximum = Math.Min(numBeamSize.Value * 0.525M, numBeamSize.Value - 1);
            if (numPlatformPosition.Value > numPlatformPosition.Maximum) numPlatformPosition.Value = numPlatformPosition.Maximum;

            Invalidate();
        }
        private void numPlatformPosition_ValueChanged(object sender, EventArgs e)
        {
            simulator.platformPosition = (double)numPlatformPosition.Value;
            Invalidate();
        }

        private void UpdateVisuals()
        {
            numPlatformPosition.Value = (decimal)simulator.platformPosition;
            numInitialPosition.Value = (decimal)simulator.x;
            numInitialAngle.Value = (decimal)(simulator.y * 180 / Math.PI);
            forceTrackBar.Value = (int)(simulator.f * 10);

            Invalidate();
        }

        private void CheckCargoLoading()
        {
            double containerBottom = simulator.y + simulator.l * Math.Cos(simulator.y);
            double platformHeight = 0.5;

            if (Math.Abs(containerBottom - platformHeight) < 0.1 &&
                simulator.x >= simulator.platformPosition &&
                simulator.x <= simulator.platformPosition + 5 &&
                Math.Abs(simulator.y) < 0.1 &&
                Math.Abs(simulator.GetNormalizedPosition()) < 0.1)
            {
                MessageBox.Show("Груз успешно установлен на платформу!", "Успешная загрузка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                simulator.Reset();
            }
        }


        private void OnSimulatorStateChanged(object sender, EventArgs e)
        {
            if (e is SimulatorEventArgs args)
            {
                if (args.IsEmergency) MessageBox.Show(args.Message, "Аварийная ситуация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (!string.IsNullOrEmpty(args.Message)) MessageBox.Show(args.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UpdateVisuals();
            CheckCargoLoading();
        }

        private void SetupControls()
        {
            // Настройка стилей для элементов управления
            foreach (Control control in Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.Font = new Font("Roboto", 10F);
                }
                else if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = Color.FromArgb(52, 152, 219);
                    button.ForeColor = Color.White;
                    button.Font = new Font("Roboto", 10F, FontStyle.Bold);
                    button.Cursor = Cursors.Hand;
                }
            }

            // Добавление подписей к текстовым полям
            AddLabel("Масса маятника (кг):", numMassPendulum);
            AddLabel("Масса каретки (кг):", numMassCart);
            AddLabel("Длина маятника (м):", numLengthPendulum);
            AddLabel("Коэф. торможения каретки:", numDampingCart);
            AddLabel("Коэф. затухания колебаний:", numDampingPendulum);
            AddLabel("Начальная позиция:", numInitialPosition);
            AddLabel("Начальный угол:", numInitialAngle);
            AddLabel("Размер балки (м):", numBeamSize);
            AddLabel("Передвижение каретки:", forceTrackBar);
            AddLabel("Позиция платформы:", numPlatformPosition);

            // Настройка обработчиков событий
            numMassPendulum.ValueChanged += UpdateSimulatorParameters;
            numMassCart.ValueChanged += UpdateSimulatorParameters;
            numLengthPendulum.ValueChanged += UpdateSimulatorParameters;
            numDampingCart.ValueChanged += UpdateSimulatorParameters;
            numDampingPendulum.ValueChanged += UpdateSimulatorParameters;
            numInitialPosition.ValueChanged += UpdateSimulatorParameters;
            numInitialAngle.ValueChanged += UpdateSimulatorParameters;
            numBeamSize.ValueChanged += numBeamSize_ValueChanged;
            numPlatformPosition.ValueChanged += UpdateSimulatorParameters;

            // Установка начальных значений
            SetInitialValues();
        }

        private void AddLabel(string text, Control control)
        {
            Label label = new Label
            {
                Text = text,
                AutoSize = true,
                Location = new Point(control.Left, control.Top - 20)
            };
            Controls.Add(label);
        }

        private void SetInitialValues()
        {
            numMassPendulum.Value = (decimal)simulator.m;
            numMassCart.Value = (decimal)simulator.M;
            numLengthPendulum.Value = (decimal)simulator.l;
            numDampingCart.Value = (decimal)simulator.k1;
            numDampingPendulum.Value = (decimal)simulator.k2;
            numInitialPosition.Value = 0;
            numInitialAngle.Value = (decimal)(simulator.y * 180 / Math.PI);
            numBeamSize.Value = 20;


            numPlatformPosition.Value = 0;
            numPlatformPosition.Minimum = 0;
            numPlatformPosition.Maximum = numBeamSize.Value * 0.525M;
            numInitialPosition.Minimum = 0;
            numInitialPosition.Maximum = numBeamSize.Value;
        }

        private void UpdateSimulatorParameters(object sender, EventArgs e)
        {
            if (!isSimulationRunning)
            {
                simulator.m = (double)numMassPendulum.Value;
                simulator.M = (double)numMassCart.Value;
                simulator.l = (double)numLengthPendulum.Value;
                simulator.k1 = (double)numDampingCart.Value;
                simulator.k2 = (double)numDampingPendulum.Value;
                simulator.x = (double)numInitialPosition.Value;
                simulator.y = (double)numInitialAngle.Value * Math.PI / 180;
                simulator.platformPosition = (double)numPlatformPosition.Value;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Start();
            isSimulationRunning = true;
            DisableControls();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer.Stop();
            isSimulationRunning = false;
            EnableControls();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer.Stop(); 
            simulator.Reset();
            isSimulationRunning = false;
            EnableControls();
            SetInitialValues();
            forceTrackBar.Value = 0;
        }

        private void DisableControls()
        {
            numMassPendulum.Enabled = false;
            numMassCart.Enabled = false;
            numLengthPendulum.Enabled = false;
            numDampingCart.Enabled = false;
            numDampingPendulum.Enabled = false;
            numInitialPosition.Enabled = false;
            numInitialAngle.Enabled = false;
            numBeamSize.Enabled = false;
            numPlatformPosition.Enabled = false;
        }

        private void EnableControls()
        {
            numMassPendulum.Enabled = true;
            numMassCart.Enabled = true;
            numLengthPendulum.Enabled = true;
            numDampingCart.Enabled = true;
            numDampingPendulum.Enabled = true;
            numInitialPosition.Enabled = true;
            numInitialAngle.Enabled = true;
            numBeamSize.Enabled = true;
            numPlatformPosition.Enabled = true;
        }
    }
}
