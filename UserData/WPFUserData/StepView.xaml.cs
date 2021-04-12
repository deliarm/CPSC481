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
using WPFUserData.Model;

namespace WPFUserData
{

    public partial class StepView : Page
    {
        public User user = User.getInstance();
        public StepView()
        {
            InitializeComponent();

            day = new LineSeries
            {
                DataLabels = true,
                Title = "day",
                Values = new ChartValues<double> { 598, 1199, 2001, 3343, 3412, 3668, 4714 }
            };

            week = new ColumnSeries
            {
                DataLabels = true,
                Title = "week",
                Values = new ChartValues<double> { 3106, 3796, 3848, 4365, 4678, 3997, 3267 }
            };

            month = new ColumnSeries
            {
                DataLabels = true,
                Title = "month",
                Values = new ChartValues<double> { 4411, 4585, 4386, 4752, 4997, 4888, 4242 }
            };


            DayLabels = new[] { "12:00PM", "1:00PM", "2:00PM", "3:00PM", " 4:00PM", "5:00PM", "6:00PM", };
            WeekLabels = new[] { "M", "T", "W", "Th", "F", "Sa", "Su" };
            MonthLabels = new[] { "Oct", "Nov", "Dec", "Jan", "Feb", "Mar", "Apr" };
            CurrentLabels = DayLabels;
            Tcal.Text = user.Info.CurrSteps.ToString();
            Cgoal.Text = user.Goal.Steps.ToString();
            Rcal.Text = (user.Goal.Steps - user.Info.CurrSteps).ToString;

            Formatter = value => value.ToString("C");


            c1.Series = new SeriesCollection
            {

            };
            c1.Series.Add(day);

            c2.Series = new SeriesCollection
            {

            };
            c2.Series.Add(week);

            c3.Series = new SeriesCollection
            {

            };
            c3.Series.Add(month);

            DataContext = this;

        }

        public SeriesCollection SeriesCollection { get; set; }

        public string[] CurrentLabels { get; set; }
        public string[] TempLabels { get; set; }
        public string[] DayLabels { get; set; }
        public string[] WeekLabels { get; set; }
        public string[] MonthLabels { get; set; }


        public Func<double, string> Formatter { get; set; }
        public LineSeries day { get; set; }
        public ColumnSeries week { get; set; }
        public ColumnSeries month { get; set; }


        private void week_view(object sender, RoutedEventArgs e)
        {
            if (!IsUserVisible(c2, graph2))
            {
                graph1.Visibility = Visibility.Hidden;
                graph2.Visibility = Visibility.Visible;
                graph3.Visibility = Visibility.Hidden;

            }

        }
        private void day_view(object sender, RoutedEventArgs e)
        {
            if (!IsUserVisible(c1, graph1))
            {
                graph1.Visibility = Visibility.Visible;
                graph2.Visibility = Visibility.Hidden;
                graph3.Visibility = Visibility.Hidden;
            }
        }
        private void month_view(object sender, RoutedEventArgs e)
        {
            if (!IsUserVisible(c3, graph3))
            {
                graph1.Visibility = Visibility.Hidden;
                graph2.Visibility = Visibility.Hidden;
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

        private void CartesianChart_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TabBar_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }






}
