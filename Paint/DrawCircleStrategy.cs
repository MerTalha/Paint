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
    public class DrawCircleStrategy : IDrawStrategy
    {
        private bool _canDraw = false;
        private Ellipse _ellipse = null;
        private Point _previous;

        private BrushSettings _brushSettings;

        public DrawCircleStrategy(BrushSettings settings)
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

            if (_ellipse is null)
            {
                _ellipse = new Ellipse();
                _ellipse.Stroke = _brushSettings.Color;
                _ellipse.StrokeThickness = _brushSettings.StrokeThickness;
                _ellipse.Width = 0;
                _ellipse.Height = 0;
                canvas.Children.Add(_ellipse);
            }

            _ellipse.Width = Math.Abs(point.X - _previous.X);
            _ellipse.Height = Math.Abs(point.Y - _previous.Y);

            if (point.X >= _previous.X)
            {
                Canvas.SetLeft(_ellipse, _previous.X);
            }
            else
            {
                Canvas.SetLeft(_ellipse, point.X);
            }

            if (point.Y >= _previous.Y)
            {
                Canvas.SetTop(_ellipse, _previous.Y);
            }
            else
            {
                Canvas.SetTop(_ellipse, point.Y);
            }
        }

        public void OnMouseUp(Canvas canvas, Point point)
        {
            _canDraw = false;
            _ellipse = null;
            _previous = point;
        }
    }
}
