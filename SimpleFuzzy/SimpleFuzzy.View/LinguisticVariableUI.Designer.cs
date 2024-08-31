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

        private TextBox nameTextBox;
        private Button addTermButton;
        private PictureBox graphPictureBox;
        private ListView termsListView;
        private ColumnHeader CloseButton;
        private ColumnHeader TermName;
        private ColumnHeader TermColor;
        private Label SetProperty;
        private Label HeightLabel;
        private NumericUpDown NumericUpDown1;
        private TrackBar trackBar;
        private Label ObjectSetLabel;
        private Label FazificationDescription;

        private void InitializeComponent()
        {
            TermName = new ColumnHeader();
            CloseButton = new ColumnHeader();
            TermColor = new ColumnHeader();
            nameLabel = new Label();
            nameTextBox = new TextBox();
            baseSetLabel = new Label();
            termsLabel = new Label();
            addTermButton = new Button();
            graphLabel = new Label();
            graphPictureBox = new PictureBox();
            termsListView = new ListView();
            HeightLabel = new Label();
            NumericUpDown1 = new NumericUpDown();
            SetProperty = new Label();
            trackBar = new TrackBar();
            ObjectSetLabel = new Label();
            FazificationDescription = new Label();
            GenerateMembershipFunction = new Button();
            GenerateBaseSet = new Button();
            baseSetComboBox = new ComboBox();
            termsComboBox = new ComboBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)graphPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar).BeginInit();
            SuspendLayout();
            // 
            // TermName
            // 
            TermName.Text = "Термы";
            // 
            // CloseButton
            // 
            CloseButton.Text = "";
            // 
            // TermColor
            // 
            TermColor.Text = "";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(0, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(258, 20);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Имя лингвистической переменной:";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(0, 24);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(200, 27);
            nameTextBox.TabIndex = 1;
            nameTextBox.LostFocus += NameChangedHandler;
            // 
            // baseSetLabel
            // 
            baseSetLabel.AutoSize = true;
            baseSetLabel.Location = new Point(0, 75);
            baseSetLabel.Name = "baseSetLabel";
            baseSetLabel.Size = new Size(152, 20);
            baseSetLabel.TabIndex = 2;
            baseSetLabel.Text = "Базовое множество:";
            // 
            // termsLabel
            // 
            termsLabel.AutoSize = true;
            termsLabel.Location = new Point(0, 119);
            termsLabel.Name = "termsLabel";
            termsLabel.Size = new Size(59, 20);
            termsLabel.TabIndex = 4;
            termsLabel.Text = "Термы:";
            // 
            // addTermButton
            // 
            addTermButton.Location = new Point(0, 166);
            addTermButton.Name = "addTermButton";
            addTermButton.Size = new Size(200, 33);
            addTermButton.TabIndex = 6;
            addTermButton.Text = "Добавить терм";
            addTermButton.Click += AddTermButton_Click;
            // 
            // graphLabel
            // 
            graphLabel.Location = new Point(0, 0);
            graphLabel.Name = "graphLabel";
            graphLabel.Size = new Size(100, 23);
            graphLabel.TabIndex = 7;
            // 
            // graphPictureBox
            // 
            graphPictureBox.Location = new Point(260, 3);
            graphPictureBox.Name = "graphPictureBox";
            graphPictureBox.Size = new Size(430, 221);
            graphPictureBox.TabIndex = 8;
            graphPictureBox.TabStop = false;
            // 
            // termsListView
            // 
            termsListView.Columns.AddRange(new ColumnHeader[] { TermName, TermColor, CloseButton });
            termsListView.FullRowSelect = true;
            termsListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            termsListView.Location = new Point(0, 204);
            termsListView.Margin = new Padding(3, 2, 3, 2);
            termsListView.Name = "termsListView";
            termsListView.Size = new Size(200, 253);
            termsListView.TabIndex = 1;
            termsListView.UseCompatibleStateImageBehavior = false;
            termsListView.View = System.Windows.Forms.View.Details;
            termsListView.SelectedIndexChanged += termView_SelectedIndexChanged;
            termsListView.MouseDoubleClick += termsListView_MouseDoubleClick;
            termsListView.MouseLeave += termsListView_MouseLeave;
            termsListView.MouseMove += termsListView_MouseMove;
            // 
            // HeightLabel
            // 
            HeightLabel.Location = new Point(260, 322);
            HeightLabel.Name = "HeightLabel";
            HeightLabel.Size = new Size(70, 20);
            HeightLabel.TabIndex = 10;
            HeightLabel.Text = "Высота сечения: ";
            HeightLabel.Visible = false;
            // 
            // NumericUpDown1
            // 
            NumericUpDown1.DecimalPlaces = 2;
            NumericUpDown1.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            NumericUpDown1.Location = new Point(336, 320);
            NumericUpDown1.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericUpDown1.Name = "NumericUpDown1";
            NumericUpDown1.Size = new Size(150, 27);
            NumericUpDown1.TabIndex = 11;
            NumericUpDown1.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            NumericUpDown1.Visible = false;
            NumericUpDown1.ValueChanged += termView_SelectedIndexChanged;
            // 
            // SetProperty
            // 
            SetProperty.Location = new Point(260, 350);
            SetProperty.Name = "SetProperty";
            SetProperty.Size = new Size(430, 100);
            SetProperty.TabIndex = 9;
            // 
            // trackBar
            // 
            trackBar.Location = new Point(260, 230);
            trackBar.Maximum = 100;
            trackBar.Name = "trackBar";
            trackBar.Size = new Size(215, 56);
            trackBar.TabIndex = 12;
            trackBar.Value = 50;
            trackBar.ValueChanged += FazificationObjectChaged;
            // 
            // ObjectSetLabel
            // 
            ObjectSetLabel.Location = new Point(481, 230);
            ObjectSetLabel.Name = "ObjectSetLabel";
            ObjectSetLabel.Size = new Size(115, 30);
            ObjectSetLabel.TabIndex = 13;
            // 
            // FazificationDescription
            // 
            FazificationDescription.Location = new Point(260, 289);
            FazificationDescription.Name = "FazificationDescription";
            FazificationDescription.Size = new Size(430, 22);
            FazificationDescription.TabIndex = 14;
            // 
            // GenerateMembershipFunction
            // 
            GenerateMembershipFunction.Location = new Point(206, 137);
            GenerateMembershipFunction.Name = "GenerateMembershipFunction";
            GenerateMembershipFunction.Size = new Size(38, 23);
            GenerateMembershipFunction.TabIndex = 15;
            GenerateMembershipFunction.Text = "+";
            GenerateMembershipFunction.Click += GenerateMembershipFunction_Click;
            // 
            // GenerateBaseSet
            // 
            GenerateBaseSet.Location = new Point(206, 93);
            GenerateBaseSet.Name = "GenerateBaseSet";
            GenerateBaseSet.Size = new Size(38, 23);
            GenerateBaseSet.TabIndex = 16;
            GenerateBaseSet.Text = "+";
            GenerateBaseSet.Click += GenerateBaseSet_Click;
            // 
            // baseSetComboBox
            // 
            baseSetComboBox.FormattingEnabled = true;
            baseSetComboBox.Location = new Point(3, 93);
            baseSetComboBox.Name = "baseSetComboBox";
            baseSetComboBox.Size = new Size(197, 28);
            baseSetComboBox.TabIndex = 17;
            baseSetComboBox.SelectedIndexChanged += BaseSetChange;
            // 
            // termsComboBox
            // 
            termsComboBox.FormattingEnabled = true;
            termsComboBox.Location = new Point(3, 137);
            termsComboBox.Name = "termsComboBox";
            termsComboBox.Size = new Size(197, 28);
            termsComboBox.TabIndex = 18;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(3, 53);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(88, 24);
            radioButton1.TabIndex = 19;
            radioButton1.TabStop = true;
            radioButton1.Text = "Входная";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(88, 53);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(99, 24);
            radioButton2.TabIndex = 20;
            radioButton2.TabStop = true;
            radioButton2.Text = "Выходная";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // LinguisticVariableUI
            // 
            AutoSize = true;
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(termsComboBox);
            Controls.Add(baseSetComboBox);
            Controls.Add(GenerateBaseSet);
            Controls.Add(GenerateMembershipFunction);
            Controls.Add(nameLabel);
            Controls.Add(nameTextBox);
            Controls.Add(baseSetLabel);
            Controls.Add(termsLabel);
            Controls.Add(addTermButton);
            Controls.Add(graphLabel);
            Controls.Add(graphPictureBox);
            Controls.Add(termsListView);
            Controls.Add(SetProperty);
            Controls.Add(HeightLabel);
            Controls.Add(NumericUpDown1);
            Controls.Add(trackBar);
            Controls.Add(ObjectSetLabel);
            Controls.Add(FazificationDescription);
            Name = "LinguisticVariableUI";
            Size = new Size(1002, 465);
            ((System.ComponentModel.ISupportInitialize)graphPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label nameLabel;
        private Label baseSetLabel;
        private Label termsLabel;
        private Label graphLabel;
        private Button GenerateMembershipFunction;
        private Button GenerateBaseSet;
        private ComboBox baseSetComboBox;
        private ComboBox termsComboBox;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
    }
}