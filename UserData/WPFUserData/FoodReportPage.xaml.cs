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

            Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<double> { 2, 5, 1 }
                },
            };

            AxisLabels = new[] { "Jan", "Feb", "Mar" };
            DataContext = this;
        }
        public SeriesCollection Series { get; set; }
        public string[] AxisLabels { get; set; }
    }
}
