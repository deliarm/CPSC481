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
using System.Diagnostics;
using System.Windows.Threading;
using System.Timers;

namespace WPFUserData
{
    /// <summary>
    /// Interaction logic for TrackerOptions.xaml
    /// </summary>
    public partial class TrackerOptions : Page
    {
        DispatcherTimer dt = new DispatcherTimer();
        Stopwatch sw = new Stopwatch();
        string currentTime = string.Empty;
        int distanceIncrement = 0;
        int prevDistanceIncrement = 0;
        double distanceTravelled = 0.0;

        public TrackerOptions()
        {
            InitializeComponent();
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0,0,0,0,1);
        }
        
        void dt_Tick(object sender, EventArgs e)
        {
            if (sw.IsRunning)
            {
                TimeSpan ts = sw.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                TimeDisplay.Text = currentTime;
                distanceIncrement = ts.Minutes*4+ts.Seconds/15;
                if (distanceIncrement > prevDistanceIncrement)
                {
                    prevDistanceIncrement = distanceIncrement;
                    int selectedIndex = DistanceTrackerEnabled.SelectedIndex;
                    if(selectedIndex == 0)
                    {
                        distanceTravelled = distanceTravelled + 0.1;

                        DistanceDisplay.Text = distanceTravelled.ToString();
                    }
                    
                    //ImageViewer1.Source = new BitmapImage(new Uri(@"\myserver\folder1\Customer Data\sample.png"));
                }
            }
        }
        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (sw.IsRunning)
            {
                sw.Stop();
            }
        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            
            sw.Start();
            dt.Start();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            sw.Reset();
            TimeDisplay.Text = "00:00:00";
            DistanceDisplay.Text = "0.0";
            distanceIncrement = 0;
            prevDistanceIncrement = 0;
            distanceTravelled = 0.0;
        }
        private void ManualAddButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AddActivityPage.xaml", UriKind.Relative));
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AddActivityPage.xaml", UriKind.Relative));
        }
    }
}
