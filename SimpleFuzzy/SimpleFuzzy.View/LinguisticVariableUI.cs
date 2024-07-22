using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using SimpleFuzzy.Model;
using SimpleFuzzy.Abstract;

namespace LinguisticVariableUI
{
    public partial class LinguisticVariableForm : Form
    {
        private LinguisticVariable linguisticVariable;
        private List<IObjectSet> baseSets; // список доступных базовых множеств

        private TextBox nameTextBox;
        private ComboBox baseSetComboBox;
        private ComboBox termsComboBox;
        private Button addTermButton;
        private Button deleteTermButton;
        private Button saveButton;
        private PictureBox graphPictureBox;

        public LinguisticVariableForm()
        {
            InitializeComponent();
            linguisticVariable = new LinguisticVariable(true);

            // Добавляем несколько примеров базовых множеств
            baseSets = new List<IObjectSet>
            {
                new RangeSet(0, 10, 0.1),
                new RangeSet(0, 100, 1),
                new RangeSet(-50, 50, 0.5)
            };

            InitializeControls();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new Size(533, 365);
            Name = "LinguisticVariableForm";
            ResumeLayout(false);
        }

        private void InitializeControls()
        {
            SuspendLayout();

            // Поле для имени
            Label nameLabel = new Label
            {
                Text = "Имя лингвистической переменной:",
                Location = new Point(10, 10),
                AutoSize = true
            };
            nameTextBox = new TextBox
            {
                Location = new Point(10, 30),
                Size = new Size(200, 20)
            };
            nameTextBox.TextChanged += (sender, e) => linguisticVariable.Name = nameTextBox.Text;

            // Выпадающий список для базового множества
            Label baseSetLabel = new Label
            {
                Text = "Базовое множество:",
                Location = new Point(10, 60),
                AutoSize = true
            };
            baseSetComboBox = new ComboBox
            {
                Location = new Point(10, 80),
                Size = new Size(200, 20),
                DataSource = baseSets,
                DisplayMember = "Name"
            };
            baseSetComboBox.SelectedIndexChanged += (sender, e) =>
            {
                linguisticVariable.BaseSet = (IObjectSet)baseSetComboBox.SelectedItem;
                UpdateGraph();
            };

            // Выпадающий список для термов
            Label termsLabel = new Label
            {
                Text = "Термы:",
                Location = new Point(10, 110),
                AutoSize = true
            };
            termsComboBox = new ComboBox
            {
                Location = new Point(10, 130),
                Size = new Size(200, 20),
                DisplayMember = "Name"
            };
            UpdateTermsComboBox();

            // Кнопки для добавления и удаления терма
            addTermButton = new Button
            {
                Location = new Point(220, 130),
                Size = new Size(100, 30),
                Text = "Добавить терм"
            };
            addTermButton.Click += AddTermButton_Click;

            deleteTermButton = new Button
            {
                Location = new Point(330, 130),
                Size = new Size(100, 30),
                Text = "Удалить терм"
            };
            deleteTermButton.Click += DeleteTermButton_Click;

            // Кнопка для сохранения изменений
            saveButton = new Button
            {
                Location = new Point(10, 160),
                Size = new Size(100, 30),
                Text = "Сохранить"
            };
            saveButton.Click += SaveButton_Click;

            // Область для отображения графика
            Label graphLabel = new Label
            {
                Text = "График функций принадлежности:",
                Location = new Point(10, 190),
                AutoSize = true
            };
            graphPictureBox = new PictureBox
            {
                Location = new Point(10, 210),
                Size = new Size(430, 200),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Добавление элементов управления на форму
            this.Controls.AddRange(new Control[] {
                nameLabel, nameTextBox,
                baseSetLabel, baseSetComboBox,
                termsLabel, termsComboBox,
                addTermButton, deleteTermButton,
                saveButton,
                graphLabel, graphPictureBox
            });

            // Установка размера формы
            this.ClientSize = new Size(450, 420);
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
                linguisticVariable.Save();
                MessageBox.Show("Изменения сохранены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (NotImplementedException) { MessageBox.Show("Функция сохранения еще не реализована", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            catch (Exception ex) { MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private IMembershipFunction CreateSampleTerm()
        {
            using (var form = new TermForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    return form.Result;
                }
            }
            return null;
        }

        private void UpdateTermsComboBox()
        {
            if (termsComboBox != null)
            {
                termsComboBox.DataSource = null;
                termsComboBox.DataSource = linguisticVariable.func;
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
            if (linguisticVariable.BaseSet == null || linguisticVariable.func.Count == 0) { graphPictureBox.Image = null; return; }
            if (graphPictureBox.Width <= 0 || graphPictureBox.Height <= 0) { MessageBox.Show("Размеры PictureBox некорректны.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return;  }
            try
            {
                using (var bitmap = new Bitmap(graphPictureBox.Width, graphPictureBox.Height))
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.White);

                    var data = linguisticVariable.Graphic();
                    var baseSetValues = ObjectSetToList(linguisticVariable.BaseSet);
                    if (data.Length==0 || baseSetValues.Count==0) { MessageBox.Show("Данные для графика некорректны.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    for (int i = 0; i < data.Length; i++)
                    {
                        var color = GetColor(i);
                        for (int j = 1; j < data[i].Count; j++)
                        {
                            float x1 = (float)(Convert.ToDouble(baseSetValues[j - 1]) / Convert.ToDouble(baseSetValues[baseSetValues.Count - 1])) * graphPictureBox.Width;
                            float y1 = graphPictureBox.Height - (float)data[i][j - 1] * graphPictureBox.Height;
                            float x2 = (float)(Convert.ToDouble(baseSetValues[j]) / Convert.ToDouble(baseSetValues[baseSetValues.Count - 1])) * graphPictureBox.Width;
                            float y2 = graphPictureBox.Height - (float)data[i][j] * graphPictureBox.Height;

                            graphics.DrawLine(new Pen(color), x1, y1, x2, y2);
                        }
                    }
                     
                    graphPictureBox.Image = bitmap;
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка при объявлении графика: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private Color GetColor(int index)
        {
            Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple, Color.Brown };
            return colors[index % colors.Length];
        }
    }


    // ДАЛЕЕ ИДУТ ПРОСТЫЕ ПРИМЕРЫ РЕАЛИЗАЦИЙ МНОЖЕСТВА И ФУНКЦИИ ПРИНАДЛЕЖНОСТИ

    // Для примера, сделал банальную реализацию IObjectSet
    public class RangeSet : IObjectSet
    {
        private double current;
        private readonly double start;
        private readonly double end;
        private readonly double step;

        public RangeSet(double start, double end, double step)
        {
            this.start = start;
            this.end = end;
            this.step = step;
            this.current = start;
        }

        public object Extraction() => current;
        public void MoveNext() => current = Math.Min(current + step, end);
        public void ToFirst() => current = start;
        public bool IsEnd() => current >= end;
        public override string ToString() => $"Range [{start}, {end}] step {step}";
    }

    // пример на реализации TriangularMembershipFunction
    public class TriangularMembershipFunction : IMembershipFunction
    {
        public string Name { get; set; }
        private double a, b, c;

        public TriangularMembershipFunction(string name, double a, double b, double c)
        {
            Name = name;
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public Type InputType => typeof(double);

        public double MembershipFunction(object x)
        {
            double value = Convert.ToDouble(x);
            if (value <= a || value >= c) return 0;
            if (value == b) return 1;
            if (value > a && value < b) return (value - a) / (b - a);
            return (c - value) / (c - b);
        }
    }
}