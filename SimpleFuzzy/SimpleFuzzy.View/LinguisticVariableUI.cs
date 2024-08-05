using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SimpleFuzzy.Model;
using SimpleFuzzy.Abstract;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace SimpleFuzzy.View
{
    public partial class LinguisticVariableUI : UserControl
    { 
        public LinguisticVariableUI()
        {
            InitializeComponent();
            linguisticVariable = new LinguisticVariable(true);

            // Добавляем несколько примеров базовых множеств
            baseSets = new List<IObjectSet>
            {};

            InitializeControls();
        }

        private void AddTermButton_Click(object sender, EventArgs e)
        {
            if (linguisticVariable.BaseSet == null)
            {
                MessageBox.Show("Пожалуйста, выберите базовое множество перед добавлением терма.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IMembershipFunction newTerm = CreateSampleTerm();
            if (newTerm != null)
            {
                try
                {
                    linguisticVariable.AddTerm(newTerm);
                    UpdateTermsComboBox();
                    UpdateGraph();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show($"Ошибка при добавлении терма: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteTermButton_Click(object sender, EventArgs e)
        {
            if (termsComboBox == null || termsComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите терм для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            linguisticVariable.DeleteTerm((IMembershipFunction)termsComboBox.SelectedItem);
            UpdateTermsComboBox();
            UpdateGraph();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Здесь вызов метода сохранения
                MessageBox.Show("Изменения сохранены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (NotImplementedException) { MessageBox.Show("Функция сохранения еще не реализована", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            catch (Exception ex) { MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private IMembershipFunction CreateSampleTerm()
        {
            return null;
        }

        private void UpdateTermsComboBox()
        {
            if (termsComboBox != null)
            {
                var selectedItem = termsComboBox.SelectedItem;
                termsComboBox.DataSource = new BindingSource(linguisticVariable.func, null);
                if (selectedItem != null && linguisticVariable.func.Contains(selectedItem)) termsComboBox.SelectedItem = selectedItem;
            }
        }

        private List<object> ObjectSetToList(IObjectSet objectSet)
        {
            var list = new List<object>();
            objectSet.ToFirst();
            while (!objectSet.IsEnd())
            {
                list.Add(objectSet.Extraction());
                objectSet.MoveNext();
            }
            return list;
        }

        private void UpdateGraph()
        {
            if (linguisticVariable.BaseSet == null || linguisticVariable.func.Count == 0)
            {
                graphPictureBox.Image = null;
                return;
            }

            var plotModel = new PlotModel { Title = "Лингвистическая переменная" };

            var baseSetValues = ObjectSetToList(linguisticVariable.BaseSet);
            var data = linguisticVariable.Graphic();

            for (int i = 0; i < data.Count; i++) 
            {
                var series = new LineSeries
                {
                    Title = $"Терм {i + 1}",
                    Color = OxyColor.FromRgb((byte)GetColor(i).R, (byte)GetColor(i).G, (byte)GetColor(i).B)
                };

                for (int j = 0; j < data[i].Count; j++)
                {
                    series.Points.Add(new DataPoint(Convert.ToDouble(baseSetValues[j]), data[i][j]));
                }

                plotModel.Series.Add(series);
            }

            var plotView = new PlotView
            {
                Model = plotModel,
                Dock = DockStyle.Fill
            };

            graphPictureBox.Controls.Clear();
            graphPictureBox.Controls.Add(plotView);
        }

        private Color GetColor(int index)
        {
            Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple, Color.Brown };
            return colors[index % colors.Length];
        }
    }
}