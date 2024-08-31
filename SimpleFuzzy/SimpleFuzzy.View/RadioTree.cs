namespace SimpleFuzzy.View
{
    internal class RadioTree : TreeView
    {
        public event EventHandler BaseSetCheckedChange;
        public event EventHandler TermCheckedChange;
        public event EventHandler SimulatorCheckedChange;
        TreeNode BaseSet { get; set; }
        CheckBox BaseSetCheck { get; set; }
        TreeNode Term { get; set; }
        CheckBox TermCheck { get; set; }
        TreeNode Simulator { get; set; }
        Label SimulatorText { get; set; }

        ToolTip toolTip = new ToolTip();
        bool activeCheck = true;

        Dictionary<CheckBox, TreeNode> baseSets = new Dictionary<CheckBox, TreeNode>();
        Dictionary<CheckBox, TreeNode> terms = new Dictionary<CheckBox, TreeNode>();
        Dictionary<RadioButton, TreeNode> simulators = new Dictionary<RadioButton, TreeNode>();
        public RadioTree()
        {
            AfterExpand += Expand;
            AfterCollapse += Collapse;
            DrawNode += Draw;
            DrawMode = TreeViewDrawMode.OwnerDrawText;
            BaseSet = new TreeNode();
            BaseSetCheck = new CheckBox();
            BaseSetCheck.CheckedChanged += BaseSetCheckedChanged;
            BaseSetCheck.Text = "Базовые множества";
            Nodes.Add(BaseSet);
            BaseSetCheck.AutoSize = true;
            BaseSetCheck.Size = new Size(BaseSetCheck.Width, 20);
            Controls.Add(BaseSetCheck);

            Term = new TreeNode();
            TermCheck = new CheckBox();
            TermCheck.CheckedChanged += TermCheckedChanged;
            TermCheck.Text = "Функции принадлежности";
            Nodes.Add(Term);
            TermCheck.AutoSize = true;
            TermCheck.Size = new Size(TermCheck.Width, 20);
            Controls.Add(TermCheck);

            Simulator = new TreeNode();
            SimulatorText = new Label();
            SimulatorText.Text = "Симуляции";
            Nodes.Add(Simulator);
            SimulatorText.AutoSize = true;
            SimulatorText.Size = new Size(SimulatorText.Width, 20);
            Controls.Add(SimulatorText);
        }

        private void Draw(object sender, EventArgs e)
        {
            BaseSetCheck.Location = new Point(BaseSet.Bounds.X, BaseSet.Bounds.Y);
            TermCheck.Location = new Point(Term.Bounds.X, Term.Bounds.Y);
            SimulatorText.Location = new Point(Simulator.Bounds.X, Simulator.Bounds.Y);
            foreach (var value in baseSets) value.Key.Location = new Point(value.Value.Bounds.X, value.Value.Bounds.Y);
            foreach (var value in terms) value.Key.Location = new Point(value.Value.Bounds.X, value.Value.Bounds.Y);
            foreach (var value in simulators) value.Key.Location = new Point(value.Value.Bounds.X, value.Value.Bounds.Y);
        }

        private void Expand(object sender, TreeViewEventArgs e)
        {
            if (e.Node == BaseSet) foreach (var value in baseSets) value.Key.Visible = true;
            if (e.Node == Term) foreach (var value in terms) value.Key.Visible = true;
            if (e.Node == Simulator) foreach (var value in simulators) value.Key.Visible = true;
        }

        private void Collapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node == BaseSet) foreach (var value in baseSets) value.Key.Visible = false;
            if (e.Node == Term) foreach (var value in terms) value.Key.Visible = false;
            if (e.Node == Simulator) foreach (var value in simulators) value.Key.Visible = false;
        }

        private void BaseSetCheckedChanged(object sender, EventArgs e)
        {
            activeCheck = false;
            if (BaseSetCheck.CheckState != CheckState.Indeterminate)
                foreach (var value in baseSets) value.Key.Checked = BaseSetCheck.Checked;
            activeCheck = true;
        }

        private void TermCheckedChanged(object sender, EventArgs e)
        {
            activeCheck = false;
            if (BaseSetCheck.CheckState != CheckState.Indeterminate)
                foreach (var value in terms) value.Key.Checked = TermCheck.Checked;
            activeCheck = true;
        }

        private void BaseSetsCheckedChanged(object sender, EventArgs e)
        {
            if (baseSets.All(t => t.Key.Checked)) BaseSetCheck.CheckState = CheckState.Checked;
            else if (baseSets.All(t => !t.Key.Checked)) BaseSetCheck.CheckState = CheckState.Unchecked;
            else if (activeCheck) BaseSetCheck.CheckState = CheckState.Indeterminate;
            if (BaseSetCheckedChange != null) BaseSetCheckedChange(sender, e);
        }

        private void TermsCheckedChanged(object sender, EventArgs e)
        {
            if (terms.All(t => t.Key.Checked)) TermCheck.CheckState = CheckState.Checked;
            else if (terms.All(t => !t.Key.Checked)) TermCheck.CheckState = CheckState.Unchecked;
            else if (activeCheck) TermCheck.CheckState = CheckState.Indeterminate;
            if (TermCheckedChange != null) TermCheckedChange.Invoke(sender, e);
        }

        private void SimulatorClick(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (!radio.Checked)
            {
                var checkedRadio = simulators.FirstOrDefault(x => x.Key.Checked);
                if (checkedRadio.Key != null) checkedRadio.Key.Checked = false;
                radio.Checked = true;
            }
            else
            {
                radio.Checked = false;
            }
        }

        public void AddSet(string name, bool active, string toolTip)
        {
            TreeNode node = new TreeNode();
            node.ToolTipText = toolTip;
            CheckBox check = new CheckBox();
            check.Text = name;
            baseSets.Add(check, node);
            this.toolTip.SetToolTip(check, toolTip);
            check.CheckedChanged += BaseSetsCheckedChanged;
            check.Checked = active;
            BaseSet.Nodes.Add(node);
            check.AutoSize = true;
            check.Size = new Size(check.Width, 20);
            Controls.Add(check);
        }

        public void AddTerm(string name, bool active, string toolTip)
        {
            TreeNode node = new TreeNode();
            node.ToolTipText = toolTip;
            CheckBox check = new CheckBox();
            check.Text = name;
            terms.Add(check, node);
            this.toolTip.SetToolTip(check, toolTip);
            check.CheckedChanged += TermsCheckedChanged;
            check.Checked = active;
            Term.Nodes.Add(node);
            check.AutoSize = true;
            check.Size = new Size(check.Width, 20);
            Controls.Add(check);
        }

        public void AddSimualtor(string name, bool active, string toolTip)
        {
            TreeNode node = new TreeNode();
            node.ToolTipText = toolTip;
            RadioButton check = new RadioButton();
            this.toolTip.SetToolTip(check, toolTip);
            check.AutoCheck = false;
            check.Checked = active;
            check.Click += SimulatorClick;
            check.CheckedChanged += (x, y) => { if (SimulatorCheckedChange != null) SimulatorCheckedChange.Invoke(x, y); };
            check.Text = name;
            Simulator.Nodes.Add(node);
            check.AutoSize = true;
            check.Size = new Size(check.Width, 20);
            Controls.Add(check);
            simulators.Add(check, node);
        }
    }
}
