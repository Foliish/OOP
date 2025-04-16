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
        void ConfirmPoint();
        void AddPoint(Point point);
        void Paint(object sender, BufferedGraphics e, SolidBrush brush, Pen pen);
        void ToIconVersion();
    }
}
