using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WeekView : Window
    {
        public WeekView()
        {
            InitializeComponent();


            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<double> { 33, 38, 39, 44 ,47 ,40, 35 }
                }
            };

            Labels = new[] { "M", "T", "W", "TH", " F", "SA", "SU" };
            Formatter = value => value.ToString("N");

            DataContext = this;



        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }


        private void CartesianChart_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TabBar_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void day_view(object sender, RoutedEventArgs e)
        {
            MainWindow tv = new MainWindow();
            tv.Show();
            this.Close();
        }

       
    }
}