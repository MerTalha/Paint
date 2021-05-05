using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Paint
{
    public partial class NewCanvasDialog : Window
    {
        public NewCanvasDialog()
        {
            InitializeComponent();
        }

        public int CanvasWidth
        {
            get
            {
                if (canvasWidth.Value.HasValue)
                    return canvasWidth.Value.Value;

                return 360;
            }
        }

        public int CanvasHeight
        {
            get
            {
                if (canvasHeight.Value.HasValue)
                    return canvasHeight.Value.Value;

                return 240;
            }
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
