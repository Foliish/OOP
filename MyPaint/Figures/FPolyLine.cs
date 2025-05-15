using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLib;

namespace MyPaint.Figures
{
    public class FPolyLine : IFigure
    {
        public Point[] points { get; set; }
        public Color bColor { get; set; }
        public Color lColor { get; set; }
        public int lWidth { get; set; }
        private int iPoints = 0;
        public FPolyLine()
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
            if (iPoints == points.Length)
            {
                Point[] pointst = new Point[iPoints + 1];
                Array.Copy(points, pointst, iPoints);
                points = pointst;
            }
            points[iPoints] = point;
        }
        public void Paint(object sender, BufferedGraphics e, SolidBrush brush, Pen pen)
        {
            pen.Color = lColor;
            pen.Width = lWidth;
            for (int i = 0; i < points.Length - 1; i++)
                e.Graphics.DrawLine(pen, points[i], points[i + 1]);
        }
        public void ToIconVersion()
        {
            points = new Point[3];
            points[0].X = lWidth + 1;
            points[0].Y = lWidth + 1;
            points[1].X = 50 - lWidth - 1;
            points[1].Y = 50 - lWidth - 1;
            points[2].X = 50 - lWidth - 1;
            points[2].Y = lWidth + 1;
        }
    }
}
