using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Paint
{
    public class DrawSquareStrategy : IDrawStrategy
    {
        private bool _canDraw = false;
        private Rectangle _rectangle = null;
        private Point _previous;

        private BrushSettings _brushSettings;

        public DrawSquareStrategy(BrushSettings settings)
        {
            _brushSettings = settings;
        }

        public void OnMouseDown(Canvas canvas, Point point)
        {
            _previous = point;
            _canDraw = true;
        }

        public void OnMouseMove(Canvas canvas, Point point)
        {
            if (_canDraw == false)
                return;

            if (_rectangle is null)
            {
                _rectangle = new Rectangle();
                _rectangle.Stroke = _brushSettings.Color;
                _rectangle.StrokeThickness = _brushSettings.StrokeThickness;
                _rectangle.Width = 0;
                _rectangle.Height = 0;
                canvas.Children.Add(_rectangle);
            }

            _rectangle.Width = Math.Abs(point.X - _previous.X);
            _rectangle.Height = Math.Abs(point.Y - _previous.Y);

            if (point.X >= _previous.X)
            {
                Canvas.SetLeft(_rectangle, _previous.X);
            }
            else
            {
                Canvas.SetLeft(_rectangle, point.X);
            }

            if (point.Y >= _previous.Y)
            {
                Canvas.SetTop(_rectangle, _previous.Y);
            }
            else
            {
                Canvas.SetTop(_rectangle, point.Y);
            }
        }

        public void OnMouseUp(Canvas canvas, Point point)
        {
            _canDraw = false;
            _rectangle = null;
            _previous = point;
        }
    }
}
