using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Paint
{
    public class BrushSettings
    {
        public SolidColorBrush Color { get; set; }
        public double StrokeThickness { get; set; }

        public BrushSettings()
        {
            Color = Brushes.Black;
            StrokeThickness = 1;
        }
    }
}
