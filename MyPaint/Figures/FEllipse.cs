using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLib;

namespace MyPaint.Figures
{
    public class FEllipse : IFigure
    {
        public Point[] points { get; set; }
        public Color bColor { get; set; }
        public Color lColor { get; set; }
        public int lWidth { get; set; }
        private int iPoints = 0;
        public FEllipse()
        {
            points = new Point[2];
        }
        public bool ConfirmFigure()
        {
            return (iPoints == points.Length);
        }
        public void ConfirmPoint()
        {
            iPoints++;
        }
        public void AddPoint(Point point)
        {
            if (iPoints < points.Length)
                points[iPoints] = point;
            if (iPoints == points.Length)
            {
                if (points[0].X > points[1].X)
                {
                    int temp = points[0].X;
                    points[0].X = points[1].X;
                    points[1].X = temp;
                }
                if (points[0].Y > points[1].Y)
                {
                    int temp = points[0].Y;
                    points[0].Y = points[1].Y;
                    points[1].Y = temp;
                }
            }
        }
        public void Paint(object sender, BufferedGraphics e, SolidBrush brush, Pen pen)
        {
            brush.Color = bColor;
            pen.Color = lColor;
            pen.Width = lWidth;
            e.Graphics.FillEllipse(brush, Math.Min(points[0].X, points[1].X), Math.Min(points[0].Y, points[1].Y), Math.Abs(points[1].X - points[0].X), Math.Abs(points[1].Y - points[0].Y));
            e.Graphics.DrawEllipse(pen, Math.Min(points[0].X, points[1].X), Math.Min(points[0].Y, points[1].Y), Math.Abs(points[1].X - points[0].X), Math.Abs(points[1].Y - points[0].Y));
        }
        public void ToIconVersion()
        {
            points[0].X = lWidth + 1;
            points[1].X = 50 - lWidth - 1;
            points[0].Y = lWidth + 1;
            points[1].Y = 50 - lWidth - 1;
        }
    }
}
