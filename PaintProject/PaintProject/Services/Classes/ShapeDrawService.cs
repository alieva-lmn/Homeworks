using PaintProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintProject.Services.Classes
{
    public class ShapeDrawService : IShapeDrawService
    {
        public Rectangle AddRectangle(Point position, DrawingAttributes inkDrawingAttributes)
        {
            Rectangle rectangle = new Rectangle
            {
                Width = 100,
                Height = 50,
                Stroke = new SolidColorBrush(inkDrawingAttributes.Color),
                StrokeThickness = 2
            };

            InkCanvas.SetLeft(rectangle, position.X);
            InkCanvas.SetTop(rectangle, position.Y);

            return rectangle;
        }

        public Ellipse AddCircle(Point position, DrawingAttributes inkDrawingAttributes)
        {
            Ellipse circle = new Ellipse
            {
                Width = 50,
                Height = 50,
                Stroke = new SolidColorBrush(inkDrawingAttributes.Color),
                StrokeThickness = 2
            };

            InkCanvas.SetLeft(circle, position.X);
            InkCanvas.SetTop(circle, position.Y);

            return circle;
        }

        public Line AddLine(Point startPoint, Point endPoint, DrawingAttributes inkDrawingAttributes)
        {
            Line line = new Line
            {
                X1 = startPoint.X,
                Y1 = startPoint.Y,
                X2 = endPoint.X,
                Y2 = endPoint.Y,
                Stroke = new SolidColorBrush(inkDrawingAttributes.Color),
                StrokeThickness = 2
            };

            return line;
        }
    }
}
