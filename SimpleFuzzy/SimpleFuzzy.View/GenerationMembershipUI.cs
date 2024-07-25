using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SimpleFuzzy.Service;
using NCalc;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;
using OxyPlot.Legends;

namespace SimpleFuzzy.View
{
    public partial class GenerationMembershipUI : UserControl
    {
        private List<(TextBox Condition, TextBox Value)> conditionControls = new List<(TextBox, TextBox)>();
        private GenerationMembershipFunction generator = new GenerationMembershipFunction();
 
        public GenerationMembershipUI()
        {
            InitializeComponent();
            InitializeTypeComboBox();
            InitializeBaseSetComboBox();

            plotView.Dock = DockStyle.Fill;
            splitContainer.Panel2.Controls.Clear();
            splitContainer.Panel2.Controls.Add(plotView);

            plotView.Model = new PlotModel{};
        }


        private void InitializeTypeComboBox()
        {
            comboBoxType.Items.AddRange(new object[] { "int", "double", "float", "string" });
            comboBoxType.SelectedIndex = 0;
        }

        private void InitializeBaseSetComboBox()
        {
            comboBoxBaseSet.Items.Add("[-10, 10]");
            comboBoxBaseSet.Items.Add("[-1.0, 1.0]");
            comboBoxBaseSet.Items.Add("[\"a\", \"b\", \"c\", \"d\", \"e\"]");
            comboBoxBaseSet.SelectedIndex = 0;
        }

        private void buttonAddCondition_Click(object sender, EventArgs e) => AddConditionRow();

        private void AddConditionRow()
        {
            int y = conditionControls.Count * 30;

            var conditionTextBox = new TextBox
            {
                Location = new Point(10, y),
                Size = new Size(110, 20),
                PlaceholderText = "Состояние"
            };

            var valueTextBox = new TextBox
            {
                Location = new Point(130, y),
                Size = new Size(110, 20),
                PlaceholderText = "Значение"
            };

            var removeButton = new Button
            {
                Location = new Point(250, y),
                Size = new Size(80, 27),
                Text = "Удалить"
            };
            removeButton.Click += (sender, e) => RemoveConditionRow((Button)sender);

            panelConditions.Controls.Add(conditionTextBox);
            panelConditions.Controls.Add(valueTextBox);
            panelConditions.Controls.Add(removeButton);

            conditionControls.Add((conditionTextBox, valueTextBox));
        }

        private void RemoveConditionRow(Button sender)
        {
            int index = sender.Location.Y / 30;
            if (index < conditionControls.Count)
            {
                panelConditions.Controls.Remove(conditionControls[index].Condition);
                panelConditions.Controls.Remove(conditionControls[index].Value);
                panelConditions.Controls.Remove(sender);
                conditionControls.RemoveAt(index);

                // Перестановка оставшихся условий
                for (int i = index; i < conditionControls.Count; i++)
                {
                    conditionControls[i].Condition.Location = new Point(10, i * 30);
                    conditionControls[i].Value.Location = new Point(170, i * 30);
                    var removeBtn = panelConditions.Controls.Find("removeButton" + (i + 1), true)[0];
                    removeBtn.Location = new Point(330, i * 30);
                }
            }
        }

        private void buttonGenerateCode_Click(object sender, EventArgs e)
        {
            generator.ClearConditions();
            foreach (var control in conditionControls)
            {
                generator.AddCondition(control.Condition.Text, control.Value.Text);
            }

            Type selectedType = Type.GetType($"System.{comboBoxType.SelectedItem}");
            string generatedCode = generator.GenerateCode(selectedType);

            textBoxGeneratedCode.Text = generatedCode;
        }

        private void buttonVisualize_Click(object sender, EventArgs e)
        {
            VisualizeFunction();
            plotView.InvalidatePlot(true);
            plotView.Refresh();
        }
        private void VisualizeFunction()
        {
            try
            {
                var plotModel = new PlotModel { Title = "Функция принадлежности" };
                plotModel.Axes.Clear();
                plotModel.Series.Clear();

                var lineSeries = new LineSeries { Title = "Функция", StrokeThickness = 2, Color = OxyColors.Blue };
                var intersectionSeries = new ScatterSeries { Title = "Пересечения", MarkerType = MarkerType.Circle, MarkerSize = 4, MarkerFill = OxyColors.Red };

                var baseSet = ParseBaseSet(comboBoxBaseSet.SelectedItem.ToString());
                double min = baseSet.Item1;
                double max = baseSet.Item2;

                double yMin = double.MaxValue;
                double yMax = double.MinValue;

                // Увеличим количество точек для более гладкого графика
                int pointCount = 1000;
                double step = (max - min) / pointCount;

                for (int i = 0; i <= pointCount; i++)
                {
                    double x = min + i * step;
                    double y = EvaluateFunction(x, out bool overlap);
                    lineSeries.Points.Add(new OxyPlot.DataPoint(x, y));

                    yMin = Math.Min(yMin, y);
                    yMax = Math.Max(yMax, y);

                    if (overlap)
                    {
                        intersectionSeries.Points.Add(new ScatterPoint(x, y));
                    }
                }

                plotModel.Series.Add(lineSeries);
                plotModel.Series.Add(intersectionSeries);

                // Настройка осей
                plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = min, Maximum = max, Title = "X" });
                plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = Math.Max(0, yMin - 0.1), Maximum = yMax + 0.1, Title = "Y" });

                // Добавление легенды
                plotModel.Legends.Add(new OxyPlot.Legends.Legend
                {
                    LegendPosition = LegendPosition.TopRight,
                    LegendPlacement = LegendPlacement.Inside
                });

                plotView.Model = plotModel;
                plotView.InvalidatePlot(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при визуализации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private (double, double) ParseBaseSet(string baseSetString)
        {
            // Простой парсинг, предполагает правильный формат
            var values = baseSetString.Trim('[', ']').Split(',');
            return (double.Parse(values[0]), double.Parse(values[1]));
        }

        private double EvaluateFunction(double x, out bool overlap)
        {
            overlap = false;
            double result = 0;
            bool foundTrue = false;

            foreach (var control in conditionControls)
            {
                string condition = control.Condition.Text.Replace("value", x.ToString());
                if (EvaluateCondition(condition))
                {
                    string value = control.Value.Text.Replace("value", x.ToString());
                    double newResult = EvaluateExpression(value);

                    if (foundTrue) { overlap = true; }
                    else
                    {
                        result = newResult;
                        foundTrue = true;
                    }
                }
            }

            return result;
        }

        // Для обработки более сложных выражений, импортируем NCalc
        private bool EvaluateCondition(string condition)
        {
            try
            {
                var e = new NCalc.Expression(condition);
                return (bool)e.Evaluate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при оценке условия: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private double EvaluateExpression(string expression)
        {
            try
            {
                var e = new NCalc.Expression(expression);
                return Convert.ToDouble(e.Evaluate());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при оценке выражения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}
