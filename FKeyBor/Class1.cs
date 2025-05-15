using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLib;


namespace FKeyBor
{
    public class Ffjvhjv : IFigure 
    {
        public Point[] points { get; set; }
        public Color bColor { get; set; }
        public Color lColor { get; set; }
        public int lWidth { get; set; }
        private int iPoints = 0;
        private static int highPoints = 4;
        public Ffjvhjv()
        {
            points = new Point[highPoints];
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
            if (iPoints + 1 < points.Length)
                for (int i = iPoints; i < highPoints; i++)
                    points[i] = point;
            else
            {
                double A = (points[0].Y - points[1].Y) / (points[0].X - points[1].X);
                double C = points[2].Y - A * points[2].X;
                double B = -1;

                double x0 = point.X;
                double y0 = point.Y;
                double denominator = A * A + B * B;

                points[3].X = (int)((B * B * x0 - A * B * y0 - A * C) / denominator);
                points[3].Y = (int)((A * A * y0 - A * B * x0 - B * C) / denominator);

            }
        }
        public void Paint(object sender, BufferedGraphics e, SolidBrush brush, Pen pen)
        {
            brush.Color = bColor;
            pen.Color = lColor;
            pen.Width = lWidth;
            e.Graphics.FillPolygon(brush, points);
            e.Graphics.DrawPolygon(pen, points);
        }
        public void ToIconVersion()
        {
            points[0].X = lWidth + 7;
            points[1].X = 50 - lWidth - 7;
            points[0].Y = lWidth + 1;
            points[1].Y = lWidth + 1;

            points[3].X = lWidth + 1;
            points[2].X = 50 - lWidth - 1;
            points[3].Y = 50-lWidth - 1;
            points[2].Y = 50-lWidth - 1;
        }
    }
}

