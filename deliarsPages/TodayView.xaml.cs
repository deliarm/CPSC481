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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<double> { 0, 12, 20, 34, 35 ,36 ,47 ,52, 60 }
                }
            };
            
            Labels = new[] { "12:00", "1:00", "2:00", "3:00" ,
                            " 4:00", "5:00" , "6:00", "7:00",
                            "8:00" };
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

        private void week_Click(object sender, RoutedEventArgs e)
        {
            WeekView wv = new WeekView();
            wv.Show();
            this.Close();
        }
    }






}
