using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Paint
{
    public interface IDrawStrategy
    {
        void OnMouseDown(Canvas canvas, Point point);
        void OnMouseMove(Canvas canvas, Point point);
        void OnMouseUp(Canvas canvas, Point point);
    }
}
