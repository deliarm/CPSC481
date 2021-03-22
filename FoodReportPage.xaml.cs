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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;

namespace WPFUserData
{
    /// <summary>
    /// Interaction logic for FoodReportPage.xaml
    /// </summary>
    public partial class FoodReportPage : Page
    {
        public FoodReportPage()
        {
            InitializeComponent();

            week = new LineSeries
            {
                DataLabels = true,
                Title = "Week",
                Values = new ChartValues<double> { 240, 239, 238, 237, 236, 235, 234 }
            };

            month = new LineSeries
            {
                DataLabels = true,
                Title = "Month",
                Values = new ChartValues<double> { 240, 240, 240 }
            };

            year = new LineSeries
            {
                DataLabels = true,
                Title = "Year",
                Values = new ChartValues<double> { 240, 230, 220, 230, 225, 220, 210, 205, 200, 225, 220, 210 }
            };



            WeekLabels = new[] { "M", "T", "W", "Th", "F", "Sa", "Su" };
            MonthLabels = new[] { "Mar.1", "Mar.2", "Mar.3" };
            YearLabels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };
            CurrentLabels = WeekLabels;


            Formatter = value => value.ToString("C");


            c1.Series = new SeriesCollection
            {

            };
            c1.Series.Add(week);

            c2.Series = new SeriesCollection
            {

            };
            c2.Series.Add(month);

            c3.Series = new SeriesCollection
            {

            };
            c3.Series.Add(year);

            DataContext = this;
        }
        public SeriesCollection SeriesCollection { get; set; }

        public string[] CurrentLabels { get; set; }
        public string[] TempLabels { get; set; }
        public string[] WeekLabels { get; set; }
        public string[] MonthLabels { get; set; }
        public string[] YearLabels { get; set; }


        public Func<double, string> Formatter { get; set; }
        public LineSeries week { get; set; }
        public LineSeries month { get; set; }
        public LineSeries year { get; set; }


        private void month_view(object sender, RoutedEventArgs e)
        {
            if (!IsUserVisible(c2, graph2))
            {
                graph1.Visibility = Visibility.Collapsed;
                graph2.Visibility = Visibility.Visible;
                graph3.Visibility = Visibility.Collapsed;

            }

        }
        private void week_view(object sender, RoutedEventArgs e)
        {
            if (!IsUserVisible(c1, graph1))
            {
                graph1.Visibility = Visibility.Visible;
                graph2.Visibility = Visibility.Collapsed;
                graph3.Visibility = Visibility.Collapsed;
            }
        }
        private void year_view(object sender, RoutedEventArgs e)
        {
            if (!IsUserVisible(c3, graph3))
            {
                graph1.Visibility = Visibility.Collapsed;
                graph2.Visibility = Visibility.Collapsed;
                graph3.Visibility = Visibility.Visible;
            }
        }

        private bool IsUserVisible(FrameworkElement element, FrameworkElement container)
        {
            if (!element.IsVisible)
                return false;

            Rect bounds = element.TransformToAncestor(container).TransformBounds(new Rect(0.0, 0.0, element.ActualWidth, element.ActualHeight));
            Rect rect = new Rect(0.0, 0.0, container.ActualWidth, container.ActualHeight);
            return rect.Contains(bounds);
        }
    }
}
