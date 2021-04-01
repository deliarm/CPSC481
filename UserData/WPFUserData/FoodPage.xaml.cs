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
    /// Interaction logic for FoodPage.xaml
    /// </summary>
    public partial class FoodPage : Page
    {
        public IList<Meal> Meals { get; set; }
        public string CaloriesStr { get; set; }
        public string ProteinStr { get; set; }
        public string FatStr { get; set; }
        public string CarbsStr { get; set; }

        public FoodPage()
        {
            InitializeComponent();

            this.DataContext = this;

            Meals = Meal.getMealsByDate(DateTime.Now.Date);
            MealsList.ItemsSource = Meals;

            // ------------- Calc sums for a day ------------- //
            int calories = 0;
            float protein = 0;
            float fat = 0;
            float carbs = 0;

            foreach (Meal m in Meals)
            {
                calories += m.Calories;
                protein += m.Protein;
                fat += m.Fat;
                carbs += m.Carbs;

            }

            float proteinPercentage = protein / (fat + carbs);
            float fatPercentage = fat / (protein + carbs);
            float carbsPercentage = carbs / (protein + fat);

            ProteinStr = proteinPercentage + "%";
            FatStr = fatPercentage + "%";
            CarbsStr = carbsPercentage + "%";

            CaloriesStr = calories + " cal";

            

        }

        private void AddMeal_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch("AddMealPage.xaml");
        }
    }
}
