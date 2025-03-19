using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint
{
    public class ChoosedFigure
    {
        public IFigure Figure;
        public bool registred;
    }
    public class FigureManager
    {
        public const int figuresH = 20;
        private IFigure[] figures = new IFigure[figuresH];
        public int figInd { get; set; } =0;
        public ChoosedFigure choosedFig { get; private set; } = new ChoosedFigure();
        public int figCount { get; private set; } = 0;
        private Type[] figTypes;
        private SolidBrush brush = new SolidBrush(Color.White);
        private Pen pen = new Pen(Color.Black);
        private Stack<IFigure> figureCache = new Stack<IFigure>();
        public FigureManager() 
        {
            choosedFig.Figure = null;
            choosedFig.registred = false;
            Assembly assembly = Assembly.GetExecutingAssembly();
            figTypes = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IFigure))).ToArray();
        }
        public void RegFigure(IFigure figure)
        {
            if (figCount>=figures.Length)
                Array.Resize(ref figures, figures.Length+figuresH);
            figures[figCount++] = figure;
        }
        public IFigure NewFigure(Object[] pars)
        {
            Type[] parTypes = new Type[pars.Length];
            for (int i = 0; i< pars.Length; i++)
                parTypes[i] = pars[i].GetType();

            ConstructorInfo constructor = figTypes[figInd].GetConstructor(parTypes);
            if (constructor != null)
            {
                IFigure figure = (IFigure)constructor.Invoke(pars);
                if (figure.ConfirmFigure())
                {
                    RegFigure(figure);
                    choosedFig.registred = true;
                }
                else
                    choosedFig.registred=false;

                choosedFig.Figure = figure;
                return figure;
            }
            else
                return null;
        }
        public IFigure RemoveFigure(int ind) 
        {
            if (figCount > 0 && figCount <= figures.Length)
            {
                IFigure res = figures[ind];
                for (int i = ind; i < figCount - 1; i++)
                    figures[i] = figures[i + 1];
                figures[figCount-- - 1] = null;
                choosedFig.Figure = null;

                figureCache.Push(res);
                return res;
            }
            else
            {
                figCount = 0;
                return null;
            }
        }
        public void ViewFigures(object o,BufferedGraphics e)
        {
            for (int i = 0;i < figures.Length; i++) 
                if (figures[i] != null)
                    figures[i].Paint(o,e,brush,pen);
        }
        public void GetPoint(Point p)
        {
            if (choosedFig.Figure != null)
            {
                choosedFig.Figure.AddPoint(p);
                if (choosedFig.Figure.ConfirmFigure() && !choosedFig.registred)
                {
                    RegFigure(choosedFig.Figure);
                    choosedFig.registred = true;
                }
            }
        }
        public IFigure ChooseFigure(Point point)
        {
            for(int i = figures.Length-1; i >= 0; i--)
                if (figures[i] != null)
                {
                    Rectangle minRect = MinRect(figures[i]);
                    if (point.X >= minRect.Left && point.X <= minRect.Right && point.Y >= minRect.Top && point.Y <= minRect.Bottom)
                    {
                        choosedFig.Figure = figures[i];
                        choosedFig.registred= true;
                        return choosedFig.Figure;
                    }
                }
            return choosedFig.Figure;
        }
        private Rectangle MinRect(IFigure figure)
        {
            int minX = 10000, minY = 10000, maxX = 0, maxY = 0;

            for (int i = 0; i < figure.points.Length; i++)
                if (figure.points[i].X != 0)
                { 
                    minX = Math.Min(minX, figure.points[i].X);
                    minY = Math.Min(minY, figure.points[i].Y);
                    maxX = Math.Max(maxX, figure.points[i].X);
                    maxY = Math.Max(maxY, figure.points[i].Y);
                }

            return new Rectangle(minX, minY, maxX - minX, maxY - minY);
        }
        public void DeChoose()
        {
            choosedFig.Figure = null;
        }
        public void NextFigure()
        {
            figInd = (figInd+1) % figures.Length;
        }
        public bool RedoFigure()
        {
            if (figureCache.Count > 0)
            {
                RegFigure(figureCache.Pop());
                return true;
            }
            return false;
        }
    }
}
