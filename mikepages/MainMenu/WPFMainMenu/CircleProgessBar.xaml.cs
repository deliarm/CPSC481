using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFMainMenu
{
    /// <summary>
    /// Interaction logic for CircleProgessBar.xaml
    /// </summary>
    public partial class CircleProgessBar : UserControl
    {
        public CircleProgessBar()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty IndicatorBrushProperty =
            DependencyProperty.Register("IndicatorBrush", typeof(Brush), typeof(CircleProgessBar));
        public Brush IndicatorBrush
        {
            get { return (Brush)GetValue(IndicatorBrushProperty); }
            set { this.SetValue(IndicatorBrushProperty, value); }
        }

        public Brush BackgroundBrush
        {
            get { return (Brush)GetValue(BackgroundBrushProperty); }
            set { this.SetValue(BackgroundBrushProperty, value); }
        }

        public static readonly DependencyProperty BackgroundBrushProperty =
            DependencyProperty.Register("BackgroundBrush", typeof(Brush), typeof(CircleProgessBar));

        public int Thickness
        {
            get { return (int)GetValue(ThicknessProperty); }
            set { SetValue(ThicknessProperty, value); }
        }

        public static readonly DependencyProperty ThicknessProperty =
            DependencyProperty.Register("Thickness", typeof(int), typeof(CircleProgessBar));

        public int AThickness
        {
            get { return (int)GetValue(AThicknessProperty); }
            set { SetValue(AThicknessProperty, value); }
        }

        public static readonly DependencyProperty AThicknessProperty =
            DependencyProperty.Register("AThickness", typeof(int), typeof(CircleProgessBar));

        public int PercentFontSize
        {
            get { return (int)GetValue(PercentFontSizeProperty); }
            set { SetValue(PercentFontSizeProperty, value); }
        }

        public static readonly DependencyProperty PercentFontSizeProperty =
            DependencyProperty.Register("PercentFontSize", typeof(int), typeof(CircleProgessBar));

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(CircleProgessBar));
    }

    [ValueConversion(typeof(int),typeof(double))]
    public class ValuetoAngleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)(((int)value * 0.01) * 360);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)((double)value * 360) * 100;
        }
    }

    [ValueConversion(typeof(int), typeof(double))]
    public class ValuetoTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return String.Format("{0}{1}", value.ToString(), "%");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }


}

