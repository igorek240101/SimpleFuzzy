using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;
using System.Drawing;

namespace SimpleFuzzy.View
{
    public partial class DefasificationForm : UserControl
    {
        IRepositoryService repositoryService;
        IDefazificationService defazificationService;
        Rule.Inference Inference { get; set; } = Rule.Inference.Prod;
        IDefazificationService.Methods Method { get; set; }
        List<(LinguisticVariable, PictureBox, TrackBar, Label, LineSeries)> inputs = new List<(LinguisticVariable, PictureBox, TrackBar, Label, LineSeries)>();
        LinguisticVariable output;
        LineSeries outputLine;
        List<AreaSeries> allArea = new List<AreaSeries>();
        public DefasificationForm()
        {
            InitializeComponent();
            repositoryService = AutofacIntegration.GetInstance<IRepositoryService>();
            defazificationService = AutofacIntegration.GetInstance<IDefazificationService>();
            textBox1.Visible = false;
            FillComboBox();
        }

        private void FillComboBox()
        {
            for (int i = 0; i < repositoryService.GetCollection<LinguisticVariable>().Count; i++)
            {
                if (!repositoryService.GetCollection<LinguisticVariable>()[i].isInput)
                    OutputVariables.Items.Add(repositoryService.GetCollection<LinguisticVariable>()[i].Name);
            }
        }

        private void OutputVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var variable in inputs)
            {
                Controls.Remove(variable.Item2);
                Controls.Remove(variable.Item3);
                Controls.Remove(variable.Item4);
            }
            inputs.Clear();
            output = repositoryService.GetCollection<LinguisticVariable>()
                .FirstOrDefault(t => t.Name == (string)OutputVariables.SelectedItem);
            pictureBox1.Controls.Clear();
            textBox1.Text = "";
            textBox1.Visible = false;
            pictureBox2.Visible = false;
            if (output.ListRules != null)
            {
                textBox1.Visible = true;
                outputLine = new LineSeries() { Color = OxyColor.FromRgb(0, 0, 0) };
                pictureBox1.Controls.Add(DrawInput(output));
                var newInput = output.ListRules.inputVariables;
                for (int i = 0; i < newInput.Count; i++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Size = new Size(287, 193);
                    pictureBox.Location = new Point(15, 197 + i * 250);
                    pictureBox.Controls.Add(DrawInput(newInput[i]));
                    Controls.Add(pictureBox);
                    TrackBar trackBar = new TrackBar();
                    trackBar.Size = new Size(148, 45);
                    trackBar.Location = new Point(15, 396 + i * 250);
                    trackBar.ValueChanged += InputChanged;
                    trackBar.Maximum = newInput[i].BaseSet.Count - 1;
                    Controls.Add(trackBar);
                    Label label = new Label();
                    label.Text = newInput[i].Name;
                    label.Location = new Point(169, 405 + i * 250);
                    Controls.Add(label);
                    inputs.Add((newInput[i], pictureBox, trackBar, label, new LineSeries() { Color = OxyColor.FromRgb(0, 0, 0) }));
                }
                textBox1.Visible = true;
                if (newInput.Count != 1)
                    pictureBox2.Visible = false;
                else
                {
                    pictureBox2.Visible = true;
                    List<ActiveRule> activeRules;
                    List<PointF> points = new List<PointF>();
                    for (int i = 0; i < newInput[0].BaseSet.Count; i++)
                        points.Add(new PointF(float.Parse(newInput[0].BaseSet[i].ToString()),
                            float.Parse(defazificationService.Defazification(output,
                            new List<object> { newInput[0].BaseSet[i] },
                            Method, Inference, out activeRules).ToString())));
                    DrawOutput(points);
                }
            }
        }

        private PlotView DrawInput(LinguisticVariable variable)
        {
            if (variable.BaseSet == null)
            {
                return null;
            }

            var plotModel = new PlotModel { Title = variable.Name };

            var baseSetValues = variable.ObjectSetToList();
            var data = variable.Graphic();

            LineSeries[] lineSeries = new LineSeries[variable.CountFunc];
            for (int i = 0; i < lineSeries.Length; i++)
            {
                Color color = variable.GetColor(variable[i]);
                lineSeries[i] = new LineSeries
                {
                    Title = variable[i].Name,
                    Color = OxyColor.FromRgb(color.R, color.G, color.B)
                };
            }

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < variable.CountFunc; j++)
                {
                    lineSeries[j].Points.Add(new DataPoint(Convert.ToDouble(baseSetValues[i]), data[i].Item2[j]));
                }
            }

            foreach (var value in lineSeries)
            {
                plotModel.Series.Add(value);
            }

            ScatterSeries series = new ScatterSeries();
            series.Points.Add(new ScatterPoint(Convert.ToDouble(baseSetValues[0]), 0, 0));
            series.Points.Add(new ScatterPoint(Convert.ToDouble(baseSetValues[^1]), 0, 0));
            plotModel.Series.Add(series);

            return new PlotView
            {
                Model = plotModel,
                Dock = DockStyle.Fill
            };
        }

        private void DrawOutput(List<PointF> list)
        {
            if (pictureBox2.Visible)
            {
                pictureBox2.Controls.Clear();
                PlotView plotView = new PlotView() { Dock = DockStyle.Fill };
                PlotModel plotModel = new PlotModel() { Title = "График передаточных характерестики" };
                LineSeries series = new LineSeries();
                foreach (PointF point in list)
                {
                    series.Points.Add(new DataPoint(point.X, point.Y));
                }
                plotModel.Series.Add(series);
                plotView.Model = plotModel;
                pictureBox2.Controls.Add(plotView);
            }
        }

        private void DrawX(double x, LineSeries series, PlotView plot)
        {
            if (!plot.Model.Series.Contains(series))
                plot.Model.Series.Add(series);
            series.Points.Clear();
            series.Points.Add(new DataPoint(x, 0));
            series.Points.Add(new DataPoint(x, 1));
            plot.InvalidatePlot(true);
        }

        private void DrawRule(IMembershipFunction function, double active)
        {
            var pic = pictureBox1.Controls[0] as PlotView;
            Color color = output.GetColor(function);
            AreaSeries areaSeries = new AreaSeries() {  
            Fill = OxyColor.FromArgb(128, color.R, color.G, color.B), Color = OxyColor.FromArgb(128, color.R, color.G, color.B) };
            for (int i = 0; i < output.BaseSet.Count; i++)
            {
                var input = output.BaseSet[i];
                if (Inference == Rule.Inference.Prod)
                    areaSeries.Points.Add(new DataPoint(double.Parse(input.ToString()), function.MembershipFunction(input) * active));
                else
                    areaSeries.Points.Add(new DataPoint(double.Parse(input.ToString()), Math.Min(function.MembershipFunction(input), active)));
            }
            pic.Model.Series.Add(areaSeries);
            allArea.Add(areaSeries);
            pic.InvalidatePlot(true);
        }

        private void InputChanged(object sender, EventArgs e)
        {
            var variable = inputs.FirstOrDefault(t => t.Item3 == sender);
            if (variable.Item1 != null)
            {
                List<ActiveRule> activeRules;
                variable.Item4.Text = variable.Item1.BaseSet[variable.Item3.Value].ToString();
                DrawX(Convert.ToDouble(variable.Item1.BaseSet[variable.Item3.Value]), variable.Item5, variable.Item2.Controls[0] as PlotView);
                object defazification = defazificationService.Defazification(output, inputs.ConvertAll(x => x.Item1.BaseSet[x.Item3.Value]), Method, Inference, out activeRules).ToString();
                DrawX(Convert.ToDouble(defazification), outputLine, pictureBox1.Controls[0] as PlotView);
                textBox1.Text = defazification.ToString();
                foreach (var oldArea in allArea)
                    (pictureBox1.Controls[0] as PlotView).Model.Series.Remove(oldArea);
                allArea.Clear();
                foreach (ActiveRule rule in activeRules) DrawRule(rule.function, rule.values);
            }
        }

        private void MaxProd_CheckedChanged(object sender, EventArgs e)
        { 
            Inference = MaxProd.Checked ? Rule.Inference.Prod : Rule.Inference.Min;
            if (inputs.Count > 0)
            {
                List<PointF> points = new List<PointF>();
                List<ActiveRule> activeRules;
                for (int i = 0; i < inputs[0].Item1.BaseSet.Count; i++)
                    points.Add(new PointF(float.Parse(inputs[0].Item1.BaseSet[i].ToString()),
                        float.Parse(defazificationService.Defazification(output,
                        new List<object> { inputs[0].Item1.BaseSet[i] },
                        Method, Inference, out activeRules).ToString())));
                DrawOutput(points);
            }
        }

        private void MaximumMethod_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                if (sender == MaximumMethod)
                    Method = IDefazificationService.Methods.Max;
                else if (sender == MethodAverageMax)
                    Method = IDefazificationService.Methods.AvgMax;
                else if (sender == MetodLeftLineDef)
                    Method = IDefazificationService.Methods.LinarLeft;
                else if (sender == MethodRightLineDef)
                    Method = IDefazificationService.Methods.LinarRight;
                else if (sender == MethodSenterGravity)
                    Method = IDefazificationService.Methods.CenterOfWight;
                if (inputs.Count > 0)
                {
                    List<PointF> points = new List<PointF>();
                    List<ActiveRule> activeRules;
                    for (int i = 0; i < inputs[0].Item1.BaseSet.Count; i++)
                        points.Add(new PointF(float.Parse(inputs[0].Item1.BaseSet[i].ToString()),
                            float.Parse(defazificationService.Defazification(output,
                            new List<object> { inputs[0].Item1.BaseSet[i] },
                            Method, Inference, out activeRules).ToString())));
                    DrawOutput(points);
                }
            }
        }
    }
}
