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
    /// Interaction logic for InfoPage.xaml
    /// </summary>
    public partial class UpdateInfoPage : Page
    {
        public User user;
        public UpdateInfoPage()
        {
            InitializeComponent();

            this.DataContext = this;

            //-------------Profile binding-------//
            user = User.getInstance();

            ageVal.Text = user.Info.Age + "";

            if (Enum.GetName(typeof(BiologicalSex), user.Info.Sex) == "Female") {
                Female.IsChecked = true;
            }
            else {
                Male.IsChecked = true;
            }

            weightVal.Text = user.Info.Weight.Number + "";

            if (user.Info.Weight.Unit == "lbs")
            {
                Pounds.IsSelected = true;
            } else {
                Kilogram.IsSelected = true;
            }

            heightVal.Text = user.Info.Height.Number + "";

            if (user.Info.Height.Unit == "cm")
            {
                Centimeters.IsSelected = true;
            }
            else
            {
                Feet.IsSelected = true;
            }


            activityLvlVal.Text = user.Info.ActivityLevel;

            stepGoalVal.Text = user.Goal.Steps + "";

            if (user.Goal.Weight.Number == user.Info.Weight.Number)
            {
                goalCombo.SelectedIndex = 0;
            } else if (user.Goal.Weight.Number < user.Info.Weight.Number)
            {
                goalCombo.SelectedIndex = 1;
            }  else
            {
                goalCombo.SelectedIndex = 2;
            }

            weightChange.Text = user.Goal.WeightChange.PerWeekWeight.Number + "";

            weightGoalVal.Text = user.Goal.Weight.Number + "";

            goalUnit.Text = user.Info.Weight.Unit;
            

            //-----------------------------------//
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Goal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (goalCombo.SelectedItem.ToString()  == "Maintain"){
                weightGoalPanel.Visibility = Visibility.Collapsed;
            } else  {
                weightGoalPanel.Visibility = Visibility.Visible;
                if (goalCombo.SelectedItem.ToString() == "Lose")
                {
                    weightLabel.Text = "Lose";
                }
                else
                {
                    weightLabel.Text = "Gain";
                } ;
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("ProfilePage.xaml", UriKind.Relative));
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            user.Info.Age = int.Parse(ageVal.Text); 

            if (Female.IsChecked == true)
            {
                
                user.Info.Sex = BiologicalSex.Female;
            }
            else
            {
                user.Info.Sex = BiologicalSex.Male;
            }

            weightVal.Text = user.Info.Weight.Number + "";

            user.Info.Weight.Number = Double.Parse(weightVal.Text);

            if (Pounds.IsSelected == true)
            {
                user.Info.Weight.Unit = WeightUnit.Pounds;
                user.Goal.Weight.Unit = WeightUnit.Pounds;
                user.Goal.WeightChange.PerWeekWeight.Unit = WeightUnit.Pounds;
            }
            else
            {
                user.Info.Weight.Unit = WeightUnit.Kilograms;
                user.Goal.Weight.Unit = WeightUnit.Kilograms;
                user.Goal.WeightChange.PerWeekWeight.Unit = WeightUnit.Kilograms;
            }


            user.Info.Height.Number = Int32.Parse(heightVal.Text);

            if (Centimeters.IsSelected == true )
            {
                user.Info.Height.Unit = HeightUnit.Centimeters;
            }
            else
            {
                user.Info.Height.Unit = HeightUnit.Feet;
            }

            Console.Write(activityLvlVal.SelectedItem.ToString());

            if (activityLvlVal.SelectedItem.ToString() == "Sedentry (Office Job)")
            {
                user.Info.ActivityLevel = ActivityLevel.None;
            }
            else if (activityLvlVal.SelectedItem.ToString() == "Light Exercise(1-2/week)")
            {
                user.Info.ActivityLevel = ActivityLevel.Light;

            }
            else if (activityLvlVal.SelectedItem.ToString() == "Medium Exercise(3-5/week)")
            {
                user.Info.ActivityLevel = ActivityLevel.Medium;
            }
            else
            {
                user.Info.ActivityLevel = ActivityLevel.Heavy;

            }

            user.Goal.Steps = Int32.Parse(stepGoalVal.Text);

            if (user.Goal.Weight.Number == user.Info.Weight.Number)
            {
                goalCombo.SelectedIndex = 0;
            }
            else if (user.Goal.Weight.Number < user.Info.Weight.Number)
            {
                goalCombo.SelectedIndex = 1;
            }
            else
            {
                goalCombo.SelectedIndex = 2;
            }

            user.Goal.Weight.Number = Double.Parse(weightGoalVal.Text);

            //user.Goal.WeightChange.PerWeekWeight.Number = Double.Pare

            //-----------------------------------//
            this.NavigationService.Navigate(new Uri("ProfilePage.xaml", UriKind.Relative));
        }
}
}
