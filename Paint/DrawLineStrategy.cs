using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint
{
    public class DrawLineStrategy : IDrawStrategy
    {
        private bool _canDraw = false;

        private Line _line = null;
        private Point _previous;

        private BrushSettings _brushSettings;

        public DrawLineStrategy(BrushSettings settings)
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

            if (_line is null)
            {
                _line = new Line();
                _line.Stroke = _brushSettings.Color;
                _line.StrokeStartLineCap = PenLineCap.Round;
                _line.StrokeEndLineCap = PenLineCap.Round;
                _line.StrokeThickness = 0;

                canvas.Children.Add(_line);
            }

            _line.X1 = _previous.X;
            _line.Y1 = _previous.Y;
            _line.X2 = point.X;
            _line.Y2 = point.Y;
            _line.StrokeThickness = _brushSettings.StrokeThickness;
        }

        public void OnMouseUp(Canvas canvas, Point point)
        {
            _canDraw = false;
            _line = null;
            _previous = point;
        }
    }
}
