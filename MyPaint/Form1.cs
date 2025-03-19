using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint
{
    public partial class Form : System.Windows.Forms.Form
    {
        FigureManager figureManager = new FigureManager();
        public Form()
        {
            InitializeComponent();
            panPain.MouseWheel += PanPain_MouseWheel;
        }

        private void PanPain_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                if (figureManager.RemoveFigure(figureManager.figCount - 1)!=null)
                    panPain.Invalidate();
            }
            else if (e.Delta > 0)
            {
                if (figureManager.RedoFigure())
                    panPain.Invalidate();
            }
        }

        private void panPaint_Paint(object sender, PaintEventArgs e)
        {
            BufferedGraphics bufferedGraphics = BufferedGraphicsManager.Current.Allocate(e.Graphics, e.ClipRectangle);
            bufferedGraphics.Graphics.Clear(Color.White);
            figureManager.ViewFigures(sender,bufferedGraphics);
            bufferedGraphics.Render();
            bufferedGraphics.Dispose();
        }

        private void panPain_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Right)
            {
                figureManager.NextFigure();
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (figureManager.choosedFig.Figure != null)
                    figureManager.GetPoint(point);
                else
                {
                    Object[] pars = { Color.Cyan, Color.Black, 2 };
                    figureManager.NewFigure(pars);
                    figureManager.GetPoint(point);
                }
            }
            panPain.Invalidate();
        }

        private void panPain_DoubleClick(object sender, EventArgs e)
        {
            figureManager.DeChoose();
        }
    }
}
