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
using System.Globalization;

namespace WPFUserData
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public User user { get; set; }
        public ProfilePage()
        {
            InitializeComponent();
            this.DataContext = this;

            //-------------Profile binding-------//
            user = User.getInstance();
            
            ageVal.Text = user.Info.Age + "";
            sexVal.Text = Enum.GetName(typeof(BiologicalSex), user.Info.Sex) ;

            weightVal.Text = user.Info.Weight.Number + "" + user.Info.Weight.Unit;

            heightVal.Text = user.Info.Height.Number + "" + user.Info.Height.Unit;

            activityLvlVal.Text = user.Info.ActivityLevel;

            stepGoalVal.Text = user.Goal.Steps + "";

            weightGoalVal.Text = user.Goal.Weight.Number + "" + user.Info.Weight.Unit;

            //-----------------------------------//

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
            for (int i = -21; i <= 0; i += 7)
                monthdays.Add(DateTime.Today.AddDays(i).ToString("MMM d", culture));
            MonthLabels = monthdays.ToArray();

            List<string> y = new List<string>();
            for (int i = -12; i < 0; i++)
                y.Add(DateTime.Today.AddMonths(i).ToString("MMM", culture));
            YearLabels = y.ToArray();


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

        private void updateProfileClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("UpdateInfoPage.xaml", UriKind.Relative));

        }

        private double getweightbydate(DateTime d)
        {
            double weight = 0;
            foreach(Weight w in user.WeightHistory)
            {
                if (w.Date == d.Date)
                    return w.Number;
            }
            return weight;
        }

        private ChartValues<double> getweekvalues()
        {
            ChartValues<double> chart = new ChartValues<double>();

            for (int i = -6; i <= 0; i++)
                chart.Add(getweightbydate(DateTime.Today.AddDays(i)));

            return chart;
        }

        private ChartValues<double> getmonthvalues()
        {
            ChartValues<double> chart = new ChartValues<double>();
            double average = 0;

            for (int i = -27; i <= 0; i++)
            {
                average += getweightbydate(DateTime.Today.AddDays(i));
                if (i % 7 == 0)
                {
                    chart.Add(Math.Round(average / 7));
                    average = 0;
                }
            }

            return chart;
        }

        private ChartValues<double> getyearvalues()
        {
            ChartValues<double> chart = new ChartValues<double>();
            double average = 0;
            int dayoff = DateTime.Today.Day;

            for (int i = -364-dayoff; i <= 0; i++)
            {
                average += getweightbydate(DateTime.Today.AddDays(i));
                if (DateTime.Today.AddDays(i).Month != DateTime.Today.AddDays(i + 1).Month)
                {
                    int daysinmonth = DateTime.DaysInMonth(DateTime.Today.AddDays(i).Year, DateTime.Today.AddDays(i).Month);
                    average /= daysinmonth;
                    chart.Add(Math.Round(average));
                    average = 0;
                }
            }
            return chart;
        }
    }
}
