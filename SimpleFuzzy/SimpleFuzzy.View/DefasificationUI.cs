using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot;
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
using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.View
{
    public partial class DefasificationUI : UserControl
    {
        private LinguisticVariable linguisticVariable;
        public DefasificationUI()
        {
            InitializeComponent();
        }
        public DefasificationUI(LinguisticVariable linguisticVariable)
        {
            this.linguisticVariable = linguisticVariable;
            InitializeComponent();
            UpdateGraph();
        }

        private void UpdateGraph()
        {
            if (linguisticVariable.BaseSet == null)
            {
                graphPictureBox.Controls.Clear();
                label1.Visible = false;
                ResultDef.Visible = false;
                return;
            }
            label1.Visible = true;
            ResultDef.Visible = true;
            var plotModel = new PlotModel { Title = "Лингвистическая переменная" };

            var baseSetValues = ObjectSetToList(linguisticVariable.BaseSet);
            var data = linguisticVariable.Graphic();

            LineSeries[] lineSeries = new LineSeries[linguisticVariable.CountFunc];
            for (int i = 0; i < lineSeries.Length; i++)
            {
                Color color = linguisticVariable.GetColor(linguisticVariable[i]);
                lineSeries[i] = new LineSeries
                {
                    Title = linguisticVariable[i].Name,
                    Color = OxyColor.FromRgb(color.R, color.G, color.B)
                };
            }

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < linguisticVariable.CountFunc; j++)
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

            var plotView = new PlotView
            {
                Model = plotModel,
                Dock = DockStyle.Fill
            };

            graphPictureBox.Controls.Clear();
            graphPictureBox.Controls.Add(plotView);
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
    }
}
