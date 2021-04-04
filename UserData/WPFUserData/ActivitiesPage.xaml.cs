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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class ActivitiesPage : Page
    {
        public List<String> Dates { get; set; } = new List<String>();

        public List<Activity> CurrentActivities { get; set; } = new List<Activity>();

        public double TotalCaloriesBurned {
            get
            {
                int cal = 0;

                foreach(Activity activity in CurrentActivities)
                {
                    cal += activity.CaloriesBurned;
                }
                return cal;
            }
        }

        public ActivitiesPage()
        {
            
            InitializeComponent();
            this.DataContext = this;

            DateTime now = DateTime.Now.Date;
            for(int i = 0; i > -10; i--)
            {
                String dateStr = now.AddDays(i).ToString("MMMM dd, yyyy");
                Dates.Add(dateStr);
            }
        }

        private void DateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = DateTime.Parse((string)DateComboBox.SelectedItem);
            CurrentActivities.Clear();
            CurrentActivities.AddRange(Activity.getActivitiesByDate(date));
            CurrentActivitiesList.Items.Refresh();

            //HACK, BREAKS? BINDING?
            TotalCaloriesBurnedText.Text = TotalCaloriesBurned.ToString();
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch("ActivityReportPage.xaml");
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch("TrackerOptions.xaml");
        }
    }
}
