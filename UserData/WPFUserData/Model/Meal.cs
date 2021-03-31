using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUserData.Model
{
    public class Meal
    {
        public MealType Type { get; set; }
        public DateTime Date { get; set; }
        public List<FoodItem> FoodItems { get; set; }
        
        public int Calories
        {
            get
            {
                int calories = 0;

                foreach(FoodItem food in FoodItems)
                {
                    calories += food.Calories;
                }

                return calories;
            }
        }

        public string CaloriesStr
        {
            get
            {
                return Calories + " cal";
            }
        }

        public int Protein
        {
            get
            {
                int protein = 0;
                foreach(FoodItem food in FoodItems)
                {
                    protein += food.Protein;
                }

                return protein;
            }
        }

        public int Fat
        {
            get
            {
                int fat = 0;
                foreach (FoodItem food in FoodItems)
                {
                    fat += food.Fat;
                }

                return fat;
            }
        }

        public int Carbs
        {
            get
            {
                int carbs = 0;
                foreach (FoodItem food in FoodItems)
                {
                    carbs += food.Carbs;
                }

                return carbs;
            }
        }



        static public List<Meal> getMealsByDate(DateTime date)
        {
            User user = User.getInstance();
            List<Meal> meals = new List<Meal>();
            foreach(Meal m in user.Meals) {
                if(m.Date == date.Date)
                {
                    meals.Add(m);
                }
            }

            return meals;
        }
    }
}
