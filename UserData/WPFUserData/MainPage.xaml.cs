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


namespace WPFUserData
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public User user= User.getInstance();
        public MainPage()
        {
            InitializeComponent();
            Percent = value => value.ToString() + "%";
            Gauge.LabelFormatter = Percent;
            Goal.Text = user.Goal.CalorieGoal.ToString();
        }

        public Func<Double, string> Percent { get; set; }

        private void TabBar_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
