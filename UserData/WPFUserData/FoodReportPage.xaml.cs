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
using System.Globalization;
using WPFUserData.Model;

namespace WPFUserData
{
    /// <summary>
    /// Interaction logic for FoodReportPage.xaml
    /// </summary>
    public partial class FoodReportPage : Page
    {
        public User user = User.getInstance();
        public FoodReportPage()
        {
            InitializeComponent();

            week = new LineSeries
            {
                DataLabels = true,
                Title = "Week",
                Values = getweekvalues()
            };

            month = new LineSeries
            {
                DataLabels = true,
                Title = "Month",
                Values = getmonthvalues()
            };

            year = new LineSeries
            {
                DataLabels = true,
                Title = "Year",
                Values = getyearvalues()
            };


            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            
            List<string> da = new List<string>();
            for (int i = -6; i <= 0; i++)
                da.Add(DateTime.Today.AddDays(i).ToString("MMM d", culture));
            WeekLabels = da.ToArray();

            List<string> monthdays = new List<string>();
            for (int i = -21; i <= 0; i+=7)
                monthdays.Add(DateTime.Today.AddDays(i).ToString("MMM d", culture));
            MonthLabels = monthdays.ToArray();

            List<string> y = new List<string>();
            for (int i = -12; i < 0; i++)
                y.Add(DateTime.Today.AddMonths(i).ToString("MMM", culture));
            YearLabels = y.ToArray();
           
            CurrentLabels = WeekLabels;
            Average.Text = Math.Round(averageCal("")).ToString();
            Protein.Content = "30%";
            Fat.Content = "25%";
            Carb.Content = "45%";
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

        private ChartValues<double> getweekvalues()
        {
            ChartValues<double> chart = new ChartValues<double>();

            for (int i = -6; i <= 0; i++)
                chart.Add(user.Info.CalorieIntakeToday(DateTime.Today.AddDays(i)));
            
            return chart;
        }

        private ChartValues<double> getmonthvalues()
        {
            ChartValues<double> chart = new ChartValues<double>();
            int average = 0;

            for (int i = -27; i <= 0; i++)
            {
                average += user.Info.CalorieIntakeToday(DateTime.Today.AddDays(i));
                if(i%7==0)
                {
                    chart.Add(average/7);
                    average = 0;
                }
            }

            return chart;
        }

        private ChartValues<double> getyearvalues()
        {
            ChartValues<double> chart = new ChartValues<double>();
            int average = 0;
            int dayoff = DateTime.Today.Day;

            for(int i= -364-dayoff; i<=0; i++)
            {
                average += user.Info.CalorieIntakeToday(DateTime.Today.AddDays(i));
                if(DateTime.Today.AddDays(i).Month != DateTime.Today.AddDays(i+1).Month)
                {
                    int daysinmonth = DateTime.DaysInMonth(DateTime.Today.AddDays(i).Year, DateTime.Today.AddDays(i).Month);
                    average /= daysinmonth;
                    chart.Add(average);
                    average = 0;
                }
            }
            return chart;
        }

        private double averageCal(string graphtype)
        {
            double avg = 0;
            ChartValues<double> chart = new ChartValues<double>();
            if(graphtype=="year")
            {
                chart = getyearvalues();
                foreach(double v in chart)
                {
                    avg += v;
                }
                return avg/12;
            }
            if (graphtype == "month")
            {
                chart = getmonthvalues();
                foreach (double v in chart)
                {
                    avg += v;
                }
                return avg / 4;
            }
            chart = getweekvalues();
            foreach (double v in chart)
            {
                avg += v;
            }
            return avg / 7;
        }

        private void month_view(object sender, RoutedEventArgs e)
        {
            
            if (!IsUserVisible(c2, graph2))
            {
                Protein.Content = "25%";
                Fat.Content = "40%";
                Carb.Content = "35%";
                Average.Text = Math.Round(averageCal("month")).ToString();
                graph1.Visibility = Visibility.Collapsed;
                graph2.Visibility = Visibility.Visible;
                graph3.Visibility = Visibility.Collapsed;

            }

        }
        private void week_view(object sender, RoutedEventArgs e)
        {
            
            if (!IsUserVisible(c1, graph1))
            {
                Protein.Content = "30%";
                Fat.Content = "25%";
                Carb.Content = "45%";
                Average.Text = Math.Round(averageCal("")).ToString();
                graph1.Visibility = Visibility.Visible;
                graph2.Visibility = Visibility.Collapsed;
                graph3.Visibility = Visibility.Collapsed;
            }
        }
        private void year_view(object sender, RoutedEventArgs e)
        {
            if (!IsUserVisible(c3, graph3))
            {
                Protein.Content = "40%";
                Fat.Content = "35%";
                Carb.Content = "25%";
                Average.Text = Math.Round(averageCal("year")).ToString();
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
