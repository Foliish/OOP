using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint
{
    public partial class Form : System.Windows.Forms.Form
    {
        FigureManager figureManager = new FigureManager();
        private const int maxMoveCount = 3;
        private int moveCount = 0;
        public Form()
        {
            InitializeComponent();
            UpdateIco();
            panPain.MouseWheel += PanPain_MouseWheel;
        }
        private void PanPain_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                if (figureManager.RemoveFigure(figureManager.figCount - 1) != null)
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

        private void panPain_DoubleClick(object sender, EventArgs e)
        {
            figureManager.DeChoose();
        }

        private void panIcon_Paint(object sender, PaintEventArgs e)
        {
            BufferedGraphics bufferedGraphics = BufferedGraphicsManager.Current.Allocate(e.Graphics, e.ClipRectangle);
            bufferedGraphics.Graphics.Clear(Color.White);
            figureManager.DrawIcon(sender, bufferedGraphics);
            bufferedGraphics.Render();
            bufferedGraphics.Dispose();
        }
        private void UpdateIco()
        {
            figureManager.SetNewDrawingParams(clrDialogBack.Color, clrDialogLine.Color, (int)edLWidth.Value);
            panIcon.Invalidate();
        }
        private void panIcon_Click(object sender, EventArgs e)
        {
            figureManager.NextFigure();
            UpdateIco();
        }

        private void btnSetBColor_Click(object sender, EventArgs e)
        {
            if (clrDialogBack.ShowDialog() == DialogResult.OK)
                UpdateIco();
        }

        private void btnSetLColor_Click(object sender, EventArgs e)
        {
            if (clrDialogLine.ShowDialog() == DialogResult.OK)
                UpdateIco();
        }

        private void edLWidth_Click(object sender, EventArgs e)
        {
            UpdateIco();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveDialog.ShowDialog() == DialogResult.OK)
                figureManager.Serialize(saveDialog.FileName);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
                try
                {
                    figureManager.DeSerialize(openDialog.FileName);
                    panPain.Invalidate();
                }
                catch 
                {
                    MessageBox.Show("шот не то");
                }
        }

        private void panPain_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
                if (figureManager.choosedFig.Figure != null)
                {
                    figureManager.GetPoint(point);
                    figureManager.ConfirmPoint();
                }
                else
                {
                    figureManager.NewFigure(new object[0]);
                    figureManager.GetPoint(point);
                    figureManager.ConfirmPoint();
                }
            else if (e.Button == MouseButtons.Middle)
                figureManager.ReturnAllCache();

            panPain.Invalidate();
        }

        private void panPain_MouseMove(object sender, MouseEventArgs e)
        {
            moveCount = (moveCount + 1) % maxMoveCount;
            if (moveCount ==0 && figureManager.choosedFig.Figure != null)
            {
                Point point = new Point(e.X, e.Y);
                figureManager.GetPoint(point);
                panPain.Invalidate();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                figureManager.NewPlug(openDialog.FileName);
            }
        }
    }
}
