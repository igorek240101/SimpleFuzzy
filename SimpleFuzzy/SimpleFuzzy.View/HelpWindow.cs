using System.Xml;


namespace SimpleFuzzy.View
{
    public partial class HelpWindow : Form
    {
        int currentTabIndex = 1;
        int currentHeight = 70;
        Dictionary<LinkLabel, string> labelsId = new Dictionary<LinkLabel, string>();
        public HelpWindow()
        {
            InitializeComponent();
        }

        public void ShowHelp(string windowId = "0")
        {
            SwitchWindow();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Directory.GetCurrentDirectory() + "\\HelpWindowSource.xml");
            XmlElement? xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    XmlNode? attr = xnode.Attributes.GetNamedItem("id");
                    if (windowId == attr?.Value)
                    {
                        foreach (XmlNode child in xnode.ChildNodes) {
                            if (child.Name == "HelpWindowSourceText")//текст
                            {
                                MakeTextBox(child.InnerText);
                            }
                            else if (child.Name == "HelpWindowSourceImage")//картинка
                            {
                                MakePictureBox(Directory.GetCurrentDirectory() + "\\" + child.InnerText);
                            }
                            else if (child.Name == "HelpWindowSourceLink")//ссылка
                            {
                                XmlNode? childInfoText = xnode.Attributes.GetNamedItem("text");
                                XmlNode? childInfoId = xnode.Attributes.GetNamedItem("id");
                                MakeLinkLabel(child.Attributes.GetNamedItem("LinkId").Value, child.InnerText);
                            }
                            AutoSize = true;
                        }
                    }
                }
            }
        }

        public void SwitchWindow()
        {
            currentTabIndex = 1;
            currentHeight = 70;
            List<Control> toDelete = new List<Control>();
            foreach (Control cnt in this.Controls)
            {
                if (cnt.TabIndex != 1)
                {
                    toDelete.Add(cnt);
                }
            }
            foreach (var cnt in toDelete)
            {
                this.Controls.Remove(cnt);
            }
        }

        public void MakeTextBox(string text)
        {
            if (text == null) return;
            Label txt = new Label();
            txt.Name = "textBox1";
            txt.Text = text;
            txt.TabIndex = currentTabIndex + 1;
            currentTabIndex++;
            txt.Location = new Point(treeView1.Location.X + treeView1.Width + 10, currentHeight);
            Controls.Add(txt);
            currentHeight += txt.Height + 10;
        }

        public void MakePictureBox(string picture)
        {
            if (picture == null) return;
            PictureBox pictureBox = new PictureBox();
            pictureBox.Name = "pictureBox1";
            pictureBox.TabIndex = currentTabIndex + 1;
            currentTabIndex++;
            pictureBox.Location = new Point(treeView1.Location.X + treeView1.Width + 10, currentHeight);
            pictureBox.Image = (Image)Bitmap.FromFile(picture);
            pictureBox.Size = new Size(400, 400);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(pictureBox);
            currentHeight += pictureBox.Height + 10;
        }

        public void MakeLinkLabel(string id, string text)
        {
            if (id == null || text == null) return;
            LinkLabel lbl = new LinkLabel();
            lbl.Name = "linkLabel1";
            lbl.Text = text;
            lbl.TabIndex = currentTabIndex + 1;
            currentTabIndex++;
            lbl.Location = new Point(treeView1.Location.X + treeView1.Width + 10, currentHeight);
            lbl.Click += lbl_SwitchPage;
            Controls.Add(lbl);
            labelsId[lbl] = id;
            currentHeight += lbl.Height + 10;
        }

        private void lbl_SwitchPage(object sender, EventArgs e)
        {
            SwitchWindow();
            treeView1.SelectedNode = null;
            ShowHelp(labelsId[(LinkLabel)sender]);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowHelp(e.Node.Text[1].ToString());
        }
    }
}
