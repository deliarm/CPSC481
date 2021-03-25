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
    /// Interaction logic for NewAddMealPage.xaml
    /// </summary>
    public partial class AddMealPage : Page
    {
        private List<FoodItem> CurrentFoods;
        private List<FoodItem> FoodSearchList;
        private List<FoodItem> FoodDatabase;
        private User user;

        private String CaloriesTotal
        {
            get
            {
                int cal = 0;

                foreach(FoodItem item in CurrentFoods)
                {
                    cal += item.Calories;
                }

                return "Total Calories: " + cal;
            }
        }

        public AddMealPage()
        {
            this.DataContext = this;
            InitializeComponent();

            user = User.getInstance();
            FoodDatabase = user.FoodDatabase;

            CurrentFoods = new List<FoodItem>();
            FoodSearchList = new List<FoodItem>();

            foreach(FoodItem item in FoodDatabase)
            {
                FoodSearchList.Add(item);
            }

            CurrentFoodList.ItemsSource = CurrentFoods;
            FoodOptionsList.ItemsSource = FoodSearchList;
            CaloriesTotalText.Text = CaloriesTotal;
        }

        private void SearchCancelButton_Click(object sender, RoutedEventArgs e)
        {
            SearchPopup.Visibility = Visibility.Hidden;
        }

        private void FakeSearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchPopup.Visibility = Visibility.Visible;
            SearchBox.Focus();
        }

        private void OverlayBackground_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SearchPopup.Visibility = Visibility.Hidden;
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            String foodName = (String)b.Tag;
            FoodItem selectedItem = FoodItem.getByName(foodName);
            CurrentFoods.Add(selectedItem);
            CurrentFoodList.Items.Refresh();
            CaloriesTotalText.Text = CaloriesTotal;

            SearchPopup.Visibility = Visibility.Hidden;
        }

        private void SearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            String text = SearchBox.Text.ToLower();
            FoodSearchList.Clear();

            foreach (FoodItem item in FoodDatabase)
            {
                if(item.Name.ToLower().Contains(text))
                {
                    FoodSearchList.Add(item);
                }
            }

            FoodOptionsList.Items.Refresh();
        }

        private void AddMeal_Click(object sender, RoutedEventArgs e)
        {
            Meal meal = new Meal
            {
                Type = (MealType)MealTypeCombo.SelectedItem,
                Date = DateTime.Now.Date, // Today's date.
                FoodItems = CurrentFoods
            };

            user.Meals.Add(meal);

            this.NavigationService.Navigate(new Uri("FoodPage.xaml", UriKind.Relative));
        }

        private void CurrentFoodCancel_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            String foodName = (String)b.Tag;
            FoodItem selectedItem = FoodItem.getByName(foodName);

            CurrentFoods.Remove(selectedItem);

            CurrentFoodList.Items.Refresh();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("FoodPage.xaml", UriKind.Relative));
        }
    }
}
