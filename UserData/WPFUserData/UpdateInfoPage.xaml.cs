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

            // Binding for Weight and Weight unit

            weightVal.Text = user.Info.Weight.Number + "";
            string[] initialWU = LoadWeightUnitBoxData();
            weightUnit.ItemsSource = initialWU;
            weightUnit.SelectedIndex = Array.IndexOf(initialWU, user.Info.Weight.Unit);

            // Binding for Height and Height unit

            heightVal.Text = user.Info.Height.Number + "";
            string[] initialHU = LoadHeightUnitBoxData();
            heightUnit.ItemsSource = initialHU;
            heightUnit.SelectedIndex = Array.IndexOf(initialHU, user.Info.Height.Unit);

            // Binding Actitvity Level
            string[] initialAL = LoadActivtityLevelComboBoxData();
            activityLvlVal.ItemsSource = initialAL;
            activityLvlVal.SelectedIndex = Array.IndexOf(initialAL, user.Info.ActivityLevel) ;

            // Binding for Steps Goal
            stepGoalVal.Text = user.Goal.Steps + "";

            // Binding for Weight Goals
            if (user.Goal.Weight.Number == user.Info.Weight.Number)
            {
                weightGoalPanel.Visibility = Visibility.Collapsed;
                goalCombo.SelectedIndex = 0;
            }
            else
            {
                weightGoalPanel.Visibility = Visibility.Visible;
                if (user.Goal.Weight.Number < user.Info.Weight.Number)
                {
                    weightLabel.Text = "Lose";
                    goalCombo.SelectedIndex = 1;
                }
                else
                {
                    weightLabel.Text = "Gain";
                    goalCombo.SelectedIndex = 2;
                }
            }

            double[] initialWC = LoadWeigthChangeComboBoxData();
            weightChange.ItemsSource = initialWC;
            weightChange.SelectedIndex = Array.IndexOf(initialWC, user.Goal.WeightChange.PerWeekWeight);


            weightChange.Text = user.Goal.WeightChange.PerWeekWeight.Number + "";

            weightGoalVal.Text = user.Goal.Weight.Number + "";

            goalUnit.Text = user.Info.Weight.Unit;
            //-----------------------------------//
        }

        private string[] LoadWeightUnitBoxData()
        {
            string[] strArray = {
            WeightUnit.Kilograms,
            WeightUnit.Pounds
            };
            return strArray;
        }

        private string[] LoadHeightUnitBoxData()
        {
            string[] strArray = {
            HeightUnit.Centimeters,
            HeightUnit.Feet
            };
            return strArray;
        }

        private string[] LoadActivtityLevelComboBoxData()
        {
            string[] strArray = {
            ActivityLevel.None,
            ActivityLevel.Light,
            ActivityLevel.Medium,
            ActivityLevel.Heavy
            };
            return strArray;
        }


        private double[] LoadWeigthChangeComboBoxData()
        {
            double[] dblArray = { 0.5, 1.0, 1.5, 2.0};
            if (user.Info.Weight.Unit == WeightUnit.Kilograms)
            {
                dblArray[0] = 0.25;
                dblArray[1] = 0.5;
                dblArray[2] = 0.75;
                dblArray[3] = 1;

            }
            return dblArray;
        }

        private void WeightUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            goalUnit.Text = weightUnit.SelectedItem.ToString();
            double[] newWC = LoadWeigthChangeComboBoxData();

            weightChange.ItemsSource = newWC;
            weightChange.SelectedIndex = Array.IndexOf(newWC, user.Goal.WeightChange.PerWeekWeight);

        }

        private void Goal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (goalCombo.SelectedValue.ToString() == "Maintain")
            {
                weightGoalPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                weightGoalPanel.Visibility = Visibility.Visible;
                if (goalCombo.SelectedValue.ToString() == "Lose")
                {
                    weightLabel.Text = "Lose";
                }
                else
                {
                    weightLabel.Text = "Gain";
                };
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch("ProfilePage.xaml");
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

            user.Info.Weight.Number = Double.Parse(weightVal.Text);

            if (weightUnit.SelectedItem.ToString() == WeightUnit.Pounds)
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

            if (heightUnit.SelectedItem.ToString() == HeightUnit.Centimeters)
            {
                user.Info.Height.Unit = HeightUnit.Centimeters;
            }
            else
            {
                user.Info.Height.Unit = HeightUnit.Feet;
            }
            

            if (activityLvlVal.SelectedItem.ToString() == ActivityLevel.None)
            {
                user.Info.ActivityLevel = ActivityLevel.None;
            }
            else if (activityLvlVal.SelectedItem.ToString() == ActivityLevel.Light)
            {
                user.Info.ActivityLevel = ActivityLevel.Light;

            }
            else if (activityLvlVal.SelectedItem.ToString() == ActivityLevel.Medium)
            {
                user.Info.ActivityLevel = ActivityLevel.Medium;
            }
            else
            {
                user.Info.ActivityLevel = ActivityLevel.Heavy;

            }

            user.Goal.Steps = Int32.Parse(stepGoalVal.Text);

            if (goalCombo.SelectedIndex == 0)
            {
                user.Goal.Weight.Number = user.Info.Weight.Number;
                user.Goal.WeightChange.PerWeekWeight.Number = 0.0;
            }
            else
            {
                user.Goal.Weight.Number = Double.Parse(weightGoalVal.Text);
                double num = Double.Parse(weightChange.SelectedItem.ToString());

                if(goalCombo.SelectedIndex == 1)
                    user.Goal.WeightChange.PerWeekWeight.Number = -num;
                else if(goalCombo.SelectedIndex == 2)
                    user.Goal.WeightChange.PerWeekWeight.Number = num;

                user.Goal.CalorieGoal = user.CalcTDEE();
            }

            Weight newW = new Weight();
            newW.Number = user.Info.Weight.Number;
            newW.Unit = user.Info.Weight.Unit;
            newW.Date = DateTime.Today;
            user.WeightHistory[user.WeightHistory.Count-1] = newW;

            //-----------------------------------//
            Switcher.Switch("ProfilePage.xaml");
        }

    }
}
