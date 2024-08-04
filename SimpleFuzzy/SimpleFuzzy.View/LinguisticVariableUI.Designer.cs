using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SimpleFuzzy.Abstract;
using SimpleFuzzy.Model;

namespace SimpleFuzzy.View
{
    public partial class LinguisticVariableUI : UserControl
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

        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new System.Drawing.Size(533, 365);
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

            ResumeLayout(false);
        }
    }
}