using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Shapes;

namespace PaintProject.Services.Interfaces
{
    public interface IShapeDrawService
    {
        public Rectangle AddRectangle(Point position, DrawingAttributes inkDrawingAttributes);
        public Ellipse AddCircle(Point position, DrawingAttributes inkDrawingAttributes);
        public Line AddLine(Point startPoint, Point endPoint, DrawingAttributes inkDrawingAttributes);
    }
}
