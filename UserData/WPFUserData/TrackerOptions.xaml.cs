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
    static class Globals
    { 
        public static double distance;
        public static int timeSeconds;
        public static int timeMinutes;
        public static int timeHours;
    }
    public partial class TrackerOptions : Page
    {
        
        DispatcherTimer dt = new DispatcherTimer();
        Stopwatch sw = new Stopwatch();
        string currentTime = string.Empty;
        int distanceIncrement = 0;
        int prevDistanceIncrement = 0;
        double distanceTravelled = 0.0;

        int whichMap = 1;
        

        public TrackerOptions()
        {
            InitializeComponent();

            //Map animation
            Uri map1 = new Uri("Icons/map1.png", UriKind.Relative);
            MapAnimation.Source = new BitmapImage(map1);

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
                Globals.timeSeconds = ts.Seconds;
                Globals.timeMinutes = ts.Minutes % 60;
                Globals.timeHours = ts.Minutes / 60;
                Globals.distance = distanceTravelled;
                if (distanceIncrement > prevDistanceIncrement)
                {
                    prevDistanceIncrement = distanceIncrement;
                    int selectedIndex = DistanceTrackerEnabled.SelectedIndex;
                    if(selectedIndex == 0)
                    {
                        distanceTravelled = distanceTravelled + 0.1;
                        DistanceDisplay.Text = distanceTravelled.ToString();

                        whichMap++;
                        if(whichMap == 2)
                        {
                            Uri map2 = new Uri("Icons/map2.png", UriKind.Relative);
                            MapAnimation.Source = new BitmapImage(map2);
                        }
                        else if(whichMap == 3)
                        {
                            Uri map3 = new Uri("Icons/map3.png", UriKind.Relative);
                            MapAnimation.Source = new BitmapImage(map3);
                        }
                        else if(whichMap == 4)
                        {
                            Uri map4 = new Uri("Icons/map4.png", UriKind.Relative);
                            MapAnimation.Source = new BitmapImage(map4);
                        }
                        else if(whichMap == 5)
                        {
                            Uri map5 = new Uri("Icons/map5.png", UriKind.Relative);
                            MapAnimation.Source = new BitmapImage(map5);
                        }
                        else if(whichMap == 6)
                        {
                            Uri map6 = new Uri("Icons/map6.png", UriKind.Relative);
                            MapAnimation.Source = new BitmapImage(map6);
                        }
                        else if(whichMap == 7)
                        {
                            Uri map7 = new Uri("Icons/map7.png", UriKind.Relative);
                            MapAnimation.Source = new BitmapImage(map7);
                        }
                        else if(whichMap == 8)
                        {
                            Uri map8 = new Uri("Icons/map8.png", UriKind.Relative);
                            MapAnimation.Source = new BitmapImage(map8);
                        }
                        else if(whichMap == 9)
                        {
                            Uri map9 = new Uri("Icons/map9.png", UriKind.Relative);
                            MapAnimation.Source = new BitmapImage(map9);
                        }
                        else if(whichMap == 10)
                        {
                            Uri map10 = new Uri("Icons/map10.png", UriKind.Relative);
                            MapAnimation.Source = new BitmapImage(map10);
                        }
                        else if(whichMap == 11)
                        {
                            Uri map11 = new Uri("Icons/map11.png", UriKind.Relative);
                            MapAnimation.Source = new BitmapImage(map11);
                        }
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
            Globals.timeSeconds = 0;
            Globals.timeMinutes = 0;  
            Globals.timeHours = 0;
            Globals.distance = 0.0;

            Uri map1 = new Uri("Icons/map1.png", UriKind.Relative);
            MapAnimation.Source = new BitmapImage(map1);
            whichMap = 1;
        }
        private void ManualAddButton_Click(object sender, RoutedEventArgs e)
        {
            Globals.timeSeconds = 0;
            Globals.timeMinutes = 0;  
            Globals.timeHours = 0;
            Globals.distance = 0.0;
            Switcher.Switch("AddActivityPage.xaml");
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch("AddActivityPage.xaml");
        }
        /** Not sure how to do the back button
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {        
            this.NavigationService.Navigate(new Uri("ActivitiesPage.xaml", UriKind.Relative));
        }
        */
    }
}
