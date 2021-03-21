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

namespace WPFUserData
{
    /// <summary>
    /// Interaction logic for NewAddMealPage.xaml
    /// </summary>
    public partial class AddMealPage : Page
    {
        public AddMealPage()
        {
            InitializeComponent();

            List<FoodItemOld> foodItems = new List<FoodItemOld>();
            foodItems.Add(new FoodItemOld() { FoodName = "Waffles", Quantity = "x3", Calories=400 });
            foodItems.Add(new FoodItemOld() { FoodName = "Apples", Quantity = "x1", Calories = 100 });
            foodItems.Add(new FoodItemOld() { FoodName = "Eggs", Quantity = "x30", Calories = 2000 });

            

            currentFoodList.ItemsSource = foodItems;

            //TEMP: OBVIOUSLY THEY SHOULDN'T HAVE THE SAME CONTENTS
            FoodOptionsList.ItemsSource = foodItems;
        }

        private void SearchCancelButton_Click(object sender, RoutedEventArgs e)
        {
            SearchPopup.Visibility = Visibility.Hidden;
        }

        private void FakeSearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchPopup.Visibility = Visibility.Visible;
            RealSearchBox.Focus();
        }

        private void OverlayBackground_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SearchPopup.Visibility = Visibility.Hidden;
        }
    }

    public class FoodItemOld
    {
        public string FoodName { get; set; }
        public string Quantity { get; set; }
        public int Calories { get; set; }
        public string CaloriesStr
        {
            get
            {
                return Calories + " cal";
            }
        }
    }
}
