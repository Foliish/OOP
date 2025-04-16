using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint.FigureManagers
{
    public class FigureCache
    {
        private Stack<IFigure> figureCache = new Stack<IFigure>();
        public void CacheFigure(IFigure figure)
        {
            figureCache.Push(figure);
        }
        public void Clear()
        {
            figureCache.Clear();
        }
        public IFigure GetFigure()
        {
            return figureCache.Pop();
        }
        public ICollection<IFigure> GetAll()
        {
            ICollection<IFigure> res = figureCache.ToArray();
            Clear();
            return res;
        }
        public bool IsEmpty()
        {
            return (figureCache.Count == 0);
        }
    }
}
