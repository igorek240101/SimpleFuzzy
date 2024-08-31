using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFuzzy.View
{
    public partial class ButtonTable : DataGridView
    {
        List<Button> buttons = new List<Button>();
        public ButtonTable()
        {
            DoubleBuffered = true;
            Scroll += Handler;
            ColumnHeadersHeightChanged += Handler;
            ColumnWidthChanged += Handler;
        }
        public void ButtonsClear()
        {
            foreach (var button in buttons) 
            {
                Controls.Remove(button);
            }
            buttons.Clear();
        }
        public void AddColumn(DataGridViewComboBoxColumn column)
        {
            Columns.Insert(ColumnCount - 2, column);
            buttons.Add(new Button());
            //buttons.Insert(0, new Button());
            Controls.Add(buttons[^1]);
            buttons[^1].Text = "X";
            buttons[^1].BackColor = Color.Transparent;
            buttons[^1].FlatStyle = FlatStyle.Flat;

            buttons[^1].Click += DeleteColumn;
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Size = new Size(25, 25);
                buttons[i].Location = new Point(GetCellDisplayRectangle(i + 1, 0, false).X, 0);
            }
        }

        private void DeleteColumn(object sender, EventArgs e)
        {
            for (int i = 0; i < buttons.Count; i++ ) 
            {
                if (buttons[i] == sender)
                {
                    Columns.RemoveAt(i + 1);
                    Controls.Remove(buttons[i]);
                    buttons.RemoveAt(i);
                }
            }
            Handler(sender, e);
        }

        private void Handler(object sender, EventArgs e)
        {
            for (int i = 0; i < buttons.Count; i++) 
            {
                buttons[i].Size = new Size(25, 25);
                Point point = new Point(GetCellDisplayRectangle(i + 1, 0, false).X, 0);
                if (point.X < 55) { buttons[i].Visible = false; }
                else
                {
                    buttons[i].Visible = true;
                    buttons[i].Location = point;
                }
            }
        }
    }
}