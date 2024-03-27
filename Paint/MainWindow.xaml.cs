using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Paint
{
    public partial class MainWindow : Window
    {
        IDrawStrategy strategy = null;
        private Dictionary<ToggleButton, IDrawStrategy> buttonToStrategy;

        BrushSettings settings = new BrushSettings();

        public MainWindow()
        {
            InitializeComponent();
            BindStrategiesToButtons();
        }

        private void BindStrategiesToButtons()
        {
            buttonToStrategy = new Dictionary<ToggleButton, IDrawStrategy>();

            buttonToStrategy.Add(buttonHand, new DrawByHandStrategy(settings));
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            strategy?.OnMouseDown(canvas, e.GetPosition(canvas));
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            strategy?.OnMouseMove(canvas, e.GetPosition(canvas));
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            strategy?.OnMouseUp(canvas, e.GetPosition(canvas));
        }

        private void ButtonInstrument_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as ToggleButton;

            foreach (var key in buttonToStrategy.Keys)
                key.IsChecked = button == key;

            strategy = buttonToStrategy[button];
        }

        private void ButtonInstrument_Unchecked(object sender, RoutedEventArgs e)
        {
            strategy = null;
        }

        private void ThicknessSpin_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            settings.StrokeThickness = Convert.ToDouble(e.NewValue);
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (e.NewValue != null)
                settings.Color = new SolidColorBrush(e.NewValue.Value);
            else
                settings.Color = Brushes.Black;
        }


    }
}
