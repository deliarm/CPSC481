using System;
using System.Net;
using System.IO;
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
using LiveCharts.Defaults;
using LiveCharts.Configurations;
using WPFUserData.Model;
using System.Globalization;


namespace WPFUserData
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public User user = User.getInstance();
        public MainPage()
        {
            InitializeComponent();
            
            int calGoal = Convert.ToInt32(user.Goal.CalorieGoal);
            int calBurn = user.Info.CalorieBurnedToday;
            int calIntake = user.Info.CalorieIntakeToday(DateTime.Today.AddDays(0));
            int calRem = calGoal + calBurn - calIntake;
            double percentVal = ((Convert.ToDouble(calIntake)/(calGoal+calBurn)) * 100.0);
            percentVal = Math.Round(percentVal,2);

            Goal.Text = calGoal.ToString();
            Rcal.Text = calRem.ToString();

            Gauge.Value = percentVal;
            Percent = value => value.ToString() + "%";
            Gauge.LabelFormatter = Percent;

            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

            Day1.Text = DateTime.Today.AddDays(-6).ToString("MMM d",culture);
            Day2.Text = DateTime.Today.AddDays(-5).ToString("MMM d", culture);
            Day3.Text = DateTime.Today.AddDays(-4).ToString("MMM d", culture);
            Day4.Text = DateTime.Today.AddDays(-3).ToString("MMM d", culture);
            Day5.Text = DateTime.Today.AddDays(-2).ToString("MMM d", culture);
            Day6.Text = DateTime.Today.AddDays(-1).ToString("MMM d", culture);
            Day7.Text = DateTime.Today.AddDays(0).ToString("MMM d", culture);

            day1v.Text = (user.Info.CalorieIntakeToday(DateTime.Today.AddDays(-6))).ToString();
            day2v.Text = (user.Info.CalorieIntakeToday(DateTime.Today.AddDays(-5))).ToString();
            day3v.Text = (user.Info.CalorieIntakeToday(DateTime.Today.AddDays(-4))).ToString();
            day4v.Text = (user.Info.CalorieIntakeToday(DateTime.Today.AddDays(-3))).ToString();
            day5v.Text = (user.Info.CalorieIntakeToday(DateTime.Today.AddDays(-3))).ToString();
            day6v.Text = (user.Info.CalorieIntakeToday(DateTime.Today.AddDays(-1))).ToString();
            TodayIntake.Text = calIntake.ToString();

            Random random = new Random();
            user.Info.CurrSteps += random.Next(100, 500);

            CStep.Text = (user.Info.CurrSteps).ToString();
            GStep.Text = "/" + (user.Goal.Steps).ToString();

            StepProg.Value = Convert.ToDouble(user.Info.CurrSteps) / (user.Goal.Steps);
            StepProg.Value *= 100.0;

        }

        public Func<Double, string> Percent { get; set; }

        private void TabBar_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
