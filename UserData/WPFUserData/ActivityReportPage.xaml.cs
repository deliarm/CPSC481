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
    /// Interaction logic for ActivityReportPage.xaml
    /// </summary>
    public partial class ActivityReportPage : Page
    {
        User user = User.getInstance();
        public ActivityReportPage()
        {
            InitializeComponent();

            week = new LineSeries
            {
                DataLabels = true,
                Title = "Week",
                Values = getweekvalues(ActivityType.Walk)
            };

            month = new LineSeries
            {
                DataLabels = true,
                Title = "Month",
                Values = getmonthvalues(ActivityType.Walk)
            };

            year = new LineSeries
            {
                DataLabels = true,
                Title = "Year",
                Values = getyearvalues(ActivityType.Walk)
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

            setBottomData(ActivityType.Walk, 6);

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

        private ChartValues<double> getweekvalues(ActivityType activity)
        {
            ChartValues<double> values = new ChartValues<double>();
            double num = 0;
            
            for(int j= -6;j<=0;j++)
            {
                List<Activity> act = new List<Activity>();
                act.AddRange(Activity.getActivitiesByDate(DateTime.Today.AddDays(j)));
                foreach(Activity a in act)
                {
                    if (a.Type == activity)
                        num += a.Distance.Number;
                }
                values.Add(num);
                num = 0;
                act.Clear();
            }

            setBottomData(activity, 6);

            return values;
        }

        private ChartValues<double> getmonthvalues(ActivityType activity)
        {
            ChartValues<double> values = new ChartValues<double>();
            double num = 0;

            for (int i = -27; i <= 0; i++)
            {
                List<Activity> act = new List<Activity>();
                act.AddRange(Activity.getActivitiesByDate(DateTime.Today.AddDays(i)));
                foreach (Activity a in act)
                {
                    if (a.Type == activity)
                        num += a.Distance.Number;
                }
                if(i%7==0)
                {
                    values.Add(num);
                    num = 0;
                }
                act.Clear();
            }

            setBottomData(activity, 27);
            return values;
        }

        private ChartValues<double> getyearvalues(ActivityType activity)
        {
            ChartValues<double> values = new ChartValues<double>();
            double num = 0;
            int dayoff = DateTime.Today.Day;
           
            for (int i = -364-dayoff; i <= 0; i++)
            {
                List<Activity> act = new List<Activity>();
                act.AddRange(Activity.getActivitiesByDate(DateTime.Today.AddDays(i)));
                foreach (Activity a in act)
                {
                    if (a.Type == activity)
                        num += a.Distance.Number;
                            
                }
                if (DateTime.Today.AddDays(i).Month != DateTime.Today.AddDays(i + 1).Month)
                {
                    values.Add(num);
                    num = 0;
                }
                act.Clear();
            }

            setBottomData(activity, 364);

            return values;
        }

        private void setBottomData (ActivityType activity, int j)
        {
            
            double best = 0;
            double latest = 0;
            double average = 0;
            string unit = "";
            int count = 0;

            for (int i = -j; i <= 0; i++)
            {
                List<Activity> act = new List<Activity>();
                act.AddRange(Activity.getActivitiesByDate(DateTime.Today.AddDays(i)));
                foreach (Activity a in act)
                {
                    if (a.Type == activity)
                    {
                        count++;
                        average += a.Distance.Number;
                        latest = a.Distance.Number;
                        unit = a.Distance.Unit;
                        if (best < a.Distance.Number)
                            best = a.Distance.Number;
                    }
                }
                act.Clear();
            }

            average /= count;
            Latest.Text = latest.ToString() + " " + unit;
            Average.Text = average.ToString("N2") + " " + unit;
            Best.Text = best.ToString() + " " + unit;
        }

        private void ActivitySelectChange (object sender, SelectionChangedEventArgs e)
        {
            if (!this.IsLoaded)
                return;

            if (IsUserVisible(c1, graph1))
            {
                if (aSelect.SelectedIndex == 0)
                {
                    week.Values = getweekvalues(ActivityType.Walk);
                }
                else if (aSelect.SelectedIndex == 1)
                {
                    week.Values = getweekvalues(ActivityType.Run);
                }
                else if (aSelect.SelectedIndex == 2)
                {
                    week.Values = getweekvalues(ActivityType.Bike);
                }
                else if (aSelect.SelectedIndex == 3)
                {
                    week.Values = getweekvalues(ActivityType.Hike);
                }
                else if (aSelect.SelectedIndex == 4)
                {
                    week.Values = getweekvalues(ActivityType.Swim);
                }
            }
            else if(IsUserVisible(c2, graph2))
            {
                if (aSelect.SelectedIndex == 0)
                {
                    month.Values = getmonthvalues(ActivityType.Walk);
                }
                else if (aSelect.SelectedIndex == 1)
                {
                    month.Values = getmonthvalues(ActivityType.Run);
                }
                else if (aSelect.SelectedIndex == 2)
                {
                    month.Values = getmonthvalues(ActivityType.Bike);
                }
                else if (aSelect.SelectedIndex == 3)
                {
                    month.Values = getmonthvalues(ActivityType.Hike);
                }
                else
                {
                    month.Values = getmonthvalues(ActivityType.Swim);
                }

            }
            else if(IsUserVisible(c3, graph3))
            {
                if (aSelect.SelectedIndex == 0)
                {
                    year.Values = getyearvalues(ActivityType.Walk);
                }
                else if (aSelect.SelectedIndex == 1)
                {
                    year.Values = getyearvalues(ActivityType.Run);
                }
                else if (aSelect.SelectedIndex == 2)
                {
                    year.Values = getyearvalues(ActivityType.Bike);
                }
                else if (aSelect.SelectedIndex == 3)
                {
                    year.Values = getyearvalues(ActivityType.Hike);
                }
                else
                {
                    year.Values = getyearvalues(ActivityType.Swim);
                }
            }
        }

        private void month_view(object sender, RoutedEventArgs e)
        {
            if (!IsUserVisible(c2, graph2))
            {
                aSelect.SelectedIndex = 0;
                setBottomData(ActivityType.Walk, 27);
                graph1.Visibility = Visibility.Collapsed;
                graph2.Visibility = Visibility.Visible;
                graph3.Visibility = Visibility.Collapsed;

            }

        }
        private void week_view(object sender, RoutedEventArgs e)
        {
            if (!IsUserVisible(c1, graph1))
            {
                setBottomData(ActivityType.Walk, 6);
                aSelect.SelectedIndex = 0;
                graph1.Visibility = Visibility.Visible;
                graph2.Visibility = Visibility.Collapsed;
                graph3.Visibility = Visibility.Collapsed;
            }
        }
        private void year_view(object sender, RoutedEventArgs e)
        {
            if (!IsUserVisible(c3, graph3))
            {
                setBottomData(ActivityType.Walk, 364);
                aSelect.SelectedIndex = 0;
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
