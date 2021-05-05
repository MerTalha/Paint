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
    public class DrawByHandStrategy : IDrawStrategy
    {
        private bool _canDraw = false;
        private Point _previous;

        private BrushSettings _brushSettings;

        public DrawByHandStrategy(BrushSettings settings)
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
            if (_canDraw == true)
            {
                var line = new Line();
                line.Stroke = _brushSettings.Color;
                line.StrokeThickness = _brushSettings.StrokeThickness;
                line.StrokeEndLineCap = PenLineCap.Round;
                line.StrokeStartLineCap = PenLineCap.Round;

                line.X1 = _previous.X;
                line.Y1 = _previous.Y;
                line.X2 = point.X;
                line.Y2 = point.Y;

                _previous = point;

                canvas.Children.Add(line);
            }
        }

        public void OnMouseUp(Canvas canvas, Point point)
        {
            _previous = point;
            _canDraw = false;
        }
    }
}
