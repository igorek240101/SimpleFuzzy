// CustomizedMenuItem.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;

namespace WindowsFormsUtils
{
    public class CustomizedMenuRenderer : ToolStripRenderer
    {
        ArrayList noHighlights = new ArrayList();

        public void addDisableHighlights(string menuItemName)
        {
            noHighlights.Add(menuItemName);
        }
        public void removeDisableHighlights(string menuItemName)
        {
            noHighlights.Remove(menuItemName);
        }


        protected override void OnRenderToolStripBackground(
         ToolStripRenderEventArgs e)
        {
            LinearGradientBrush brush = new LinearGradientBrush(e.AffectedBounds,
             Color.White, Color.Gray, 90f);
            e.Graphics.FillRectangle(brush, e.AffectedBounds);
            brush.Dispose();
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            bool showHighlight = true;

            showHighlight = !noHighlights.Contains(e.Item.Name);


            if (e.Item.Selected && showHighlight && e.Item.Enabled == true)
            {
                {
                    Rectangle rect = e.Item.ContentRectangle;
                    rect.X = e.Item.Padding.Left;
                    rect.Y = e.Item.Padding.Top;
                    rect.X -= 2;
                    rect.Y -= 5;
                    rect.Width -= 14;
                    rect.Height += 8;

                    LinearGradientBrush brush = new LinearGradientBrush(e.Item.Bounds,
             Color.Transparent, Color.LightBlue, 90);
                    e.Graphics.FillRectangle(brush, rect);

                    Pen outline = new Pen(Color.FromArgb(128, 128, 255), 1);
                    e.Graphics.DrawRectangle(outline, rect);
                }
            }
            else
            {
                if (e.Item.BackColor == Color.LightBlue)
                {
                    {
                        Rectangle rect = e.Item.ContentRectangle;
                        rect.X = e.Item.Padding.Left;
                        rect.Y = e.Item.Padding.Top;
                        rect.X -= 2;
                        rect.Y -= 5;
                        rect.Width -= 14;
                        rect.Height += 8;

                        LinearGradientBrush brush = new LinearGradientBrush(e.Item.Bounds,
                 Color.LightBlue, Color.LightBlue, 90);
                        e.Graphics.FillRectangle(brush, rect);

                        Pen outline = new Pen(Color.FromArgb(128, 128, 255), 1);
                        e.Graphics.DrawRectangle(outline, rect);
                    }
                }
            }
        }
    }
}