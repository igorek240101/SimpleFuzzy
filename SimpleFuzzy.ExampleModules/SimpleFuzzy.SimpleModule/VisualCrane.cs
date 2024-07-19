using SimpleFuzzy.SimpleModule;
using SimpleFuzzy.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace SimpleFuzzy.View
{
    public partial class VisualCrane : Form
    {
        private SimpleFuzzy.SimpleModule.CraneSimulator simulator;
        private bool isSimulationRunning = false;

        public VisualCrane()
        {
            InitializeComponent();
            SetupSimulator();
            SetupControls();
        }

        // Изменения значений
        private void forceTrackBar_ValueChanged(object sender, EventArgs e) => simulator.ApplyForce(forceTrackBar.Value / 10.0);
        private void numBeamSize_ValueChanged(object sender, EventArgs e)
        {
            simulator.SetBeamSize((double)numBeamSize.Value);
            numInitialPosition.Maximum = numBeamSize.Value;
            numPlatformPosition.Maximum = Math.Min(numBeamSize.Value * 0.525M, numBeamSize.Value - 1);
            if (numPlatformPosition.Value > numPlatformPosition.Maximum) numPlatformPosition.Value = numPlatformPosition.Maximum;

            simulator.crane.Invalidate();
        }
        private void numPlatformPosition_ValueChanged(object sender, EventArgs e)
        {
            simulator.platformPosition = (double)numPlatformPosition.Value;
            simulator.crane.Invalidate();
        }

        private void SetupSimulator()
        {
            simulator = new CraneSimulator();
            var VisualCrane = new SimpleFuzzy.SimpleModule.VisualCrane { craneSimulator = simulator };
            simulator.GetVisualObject().Dock = DockStyle.Fill;
            cranePanel.Controls.Add(simulator.GetVisualObject());
            VisualCrane.Dock = DockStyle.Fill;
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
            simulator.Start();
            isSimulationRunning = true;
            DisableControls();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            simulator.Pause();
            isSimulationRunning = false;
            EnableControls();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
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
