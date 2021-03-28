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
using WPFUserData.Model;

namespace WPFUserData
{
    /// <summary>
    /// Interaction logic for AddActivitiesPage.xaml
    /// </summary>
    public partial class AddActivitiesPage : Page
    {
        private bool hasCaloriesBeenManuallyAltered { get; set; } = false;

        public List<string> DistanceOptions { get; set; } = new List<string> {
            DistanceUnit.Kilometers, 
            DistanceUnit.Miles 
        };

        private bool hasFinishedSetup = false;

        public AddActivitiesPage()
        {
            InitializeComponent();
            this.DataContext = this;

            hasFinishedSetup = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("ActivitiesPage.xaml", UriKind.Relative));
        }

        private Activity BuildActivity()
        {
            //TODO: Error handling
            double hours = 0;
            Double.TryParse(DurationHoursTextBox.Text, out hours);

            double minutes = 0;
            Double.TryParse(DurationMinutesTextBox.Text, out minutes);

            double durationMinutes = (hours * 60) + minutes;

            DateTime now = DateTime.Now;
            DateTime durationAgo = DateTime.Now.AddMinutes(-durationMinutes);

            DateTime startTime = DateTime.Now.AddMinutes(-durationMinutes);

            Activity activity = new Activity
            {
                Type = (ActivityType)ActivityTypeCombo.SelectedItem,
                Date = startTime.Date,
                Duration = TimeSpan.FromMinutes(durationMinutes),
                StartTime = startTime, // Assume the activity started exactly `durationMinutes` ago
                Distance = new Distance
                {
                    Number = Double.Parse(DistanceTextBox.Text), //TODO: Error handling
                    Unit = (string)DistanceUnitComboBox.SelectedItem
                }
            };

            if (hasCaloriesBeenManuallyAltered)
            {
                activity.ManualCaloriesBurned = Int32.Parse(CaloriesBurnedTextBox.Text); //TODO: Error handling;
            }
            else
            {
                // Don't set calories, it will be automatically calculated based on user info and activity data.
            }

            return activity;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Activity activity = BuildActivity();
            User.getInstance().Activities.Add(activity);

            this.NavigationService.Navigate(new Uri("ActivitiesPage.xaml", UriKind.Relative));
        }


        private void ActivityTypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCaloriesBurned();
        }

        private void DurationHoursTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCaloriesBurned();
        }

        private void DurationMinutesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCaloriesBurned();
        }

        private void DistanceUnitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCaloriesBurned();
        }

        private void DistanceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCaloriesBurned();
        }

        private void UpdateCaloriesBurned()
        {
            if(!hasFinishedSetup)
            {
                // We don't want to trigger this whiel the page is still being created
                return;
            }

            if(hasCaloriesBeenManuallyAltered)
            {
                return; // Do nothing if the user is manually setting calories
            }
            else
            {
                Activity activity = BuildActivity();

                CaloriesBurnedTextBox.Text = Activity.CalcCaloriesBurned(activity.Type, activity.Distance, activity.Duration).ToString();
            }
        }

        private void CaloriesBurnedTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            hasCaloriesBeenManuallyAltered = true;
        }

        
    }
}
