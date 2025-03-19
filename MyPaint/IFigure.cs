using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyPaint
{
    public interface IFigure
    {
        Point[] points { get;}
        Color bColor { get; set; }
        Color lColor { get; set; }
        int lWidth { get; set; }
        bool ConfirmFigure();
        void AddPoint(Point point);
        void Paint(object sender, BufferedGraphics e, SolidBrush brush, Pen pen);
    }

    public class FRectangle : IFigure
    {
        public Point[] points { get; } = new Point[2];
        public Color bColor { get; set; }
        public Color lColor { get; set; }
        public int lWidth { get; set; }
        private int iPoints = 0;
        public FRectangle(Color b, Color l, int lW)
        {
            bColor = b;
            lColor = l;
            lWidth = lW;
        }
        public bool ConfirmFigure()
        {
            if (iPoints == points.Length)
                return true;
            return false;
        }
        public void AddPoint(Point point)
        {
            if (iPoints < points.Length)
                points[iPoints++] = point;

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
            e.Graphics.FillRectangle(brush, points[0].X, points[0].Y, points[1].X - points[0].X, points[1].Y - points[0].Y);
            e.Graphics.DrawRectangle(pen, points[0].X, points[0].Y, points[1].X - points[0].X, points[1].Y - points[0].Y);
        }
    }

    public class FLine : IFigure
    {
        public Point[] points { get; } = new Point[2];
        public Color bColor { get; set; }
        public Color lColor { get; set; }
        public int lWidth { get; set; }
        private int iPoints = 0;
        public FLine(Color b, Color l, int lW)
        {
            bColor = b;
            lColor = l;
            lWidth = lW;
        }
        public bool ConfirmFigure()
        {
            if (iPoints == points.Length)
                return true;
            return false;
        }
        public void AddPoint(Point point)
        {
            if (iPoints < points.Length)
                points[iPoints++] = point;
        }
        public void Paint(object sender, BufferedGraphics e, SolidBrush brush, Pen pen)
        {
            pen.Color = lColor;
            pen.Width = lWidth;
            e.Graphics.DrawLine(pen, points[0], points[1]);
        }
    }

    public class FEllipse : IFigure
    {
        public Point[] points { get; } = new Point[2];
        public Color bColor { get; set; }
        public Color lColor { get; set; }
        public int lWidth { get; set; }
        private int iPoints = 0;
        public FEllipse(Color b, Color l, int lW)
        {
            bColor = b;
            lColor = l;
            lWidth = lW;
        }
        public bool ConfirmFigure()
        {
            if (iPoints == points.Length)
                return true;
            return false;
        }
        public void AddPoint(Point point)
        {
            if (iPoints < points.Length)
                points[iPoints++] = point;
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
            e.Graphics.FillEllipse(brush, points[0].X, points[0].Y, points[1].X - points[0].X, points[1].Y - points[0].Y);
            e.Graphics.DrawEllipse(pen, points[0].X, points[0].Y, points[1].X - points[0].X, points[1].Y - points[0].Y);
        }
    }

    public class FBrokenLine : IFigure
    {
        public Point[] points { get; private set; } = new Point[2];
        public Color bColor { get; set; }
        public Color lColor { get; set; }
        public int lWidth { get; set; }
        private int iPoints = 0;
        public FBrokenLine(Color b, Color l, int lW)
        {
            bColor = b;
            lColor = l;
            lWidth = lW;
        }
        public bool ConfirmFigure()
        {
            if (iPoints == points.Length)
                return true;
            return false;
        }
        public void AddPoint(Point point)
        {
            if (iPoints == points.Length)
            {
                Point[] pointst = new Point[iPoints+1];
                Array.Copy(points, pointst, iPoints);
                points = pointst;
            }
            points[iPoints++] = point;
        }
        public void Paint(object sender, BufferedGraphics e, SolidBrush brush, Pen pen)
        {
            pen.Color = lColor;
            pen.Width = lWidth;
            for (int i = 0; i < points.Length-1; i++) 
                e.Graphics.DrawLine(pen, points[i], points[i+1]);
        }
    }
    public class FPolygon : IFigure
    {
        public Point[] points { get; private set; } = new Point[2];
        public Color bColor { get; set; }
        public Color lColor { get; set; }
        public int lWidth { get; set; }
        private int iPoints = 0;
        public FPolygon(Color b, Color l, int lW)
        {
            bColor = b;
            lColor = l;
            lWidth = lW;
        }
        public bool ConfirmFigure()
        {
            if (iPoints == points.Length)
                return true;
            return false;
        }
        public void AddPoint(Point point)
        {
            if (iPoints == points.Length)
            {
                Point[] pointst = new Point[iPoints + 1];
                Array.Copy(points, pointst, iPoints);
                points = pointst;
            }
            points[iPoints++] = point;
        }
        public void Paint(object sender, BufferedGraphics e, SolidBrush brush, Pen pen)
        {
            brush.Color = bColor;
            pen.Color = lColor;
            pen.Width = lWidth;
            e.Graphics.FillPolygon(brush, points);
            e.Graphics.DrawPolygon(pen, points);
        }
    }
}
