using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUserData.Model
{
    public class User
    {
        private static User instance;

        /**
         * Implement a singleton
         */
        public static User getInstance()
        {
            if(User.instance == null)
            {
                User.instance = new User();
            }
            return User.instance;
        }

        public List<Meal> Meals;
        public List<Step> Steps;
        public List<Activity> Activities;

        public Info Info;
        public Goal Goal;

        public User()
        {
            Meals = new List<Meal>();
            Steps = new List<Step>();
            Activities = new List<Activity>();


            FillHistoricData();
        }

        private void FillHistoricData()
        {
            FillHistoricMeals();
        }

        private void FillHistoricMeals()
        {
            for(int i = 0; i < 100; i++)
            {
                Meal meal = new Meal
                {
                    Type = MealType.Breakfast,
                    Date = new DateTime(2021, 1 + (i / 28), 1 + (i % 27) ),
                    FoodItems = new List<FoodItem>
                    {
                        getRandomFoodItem(),
                        getRandomFoodItem(),
                        getRandomFoodItem()
                    }
                };
                Meals.Add(meal);
                Meals.Add(meal);
            }
        }

        private FoodItem getRandomFoodItem()
        {
            FoodItem item = new FoodItem
            {
                Name = "Waffles",
                Quantity = 2,
                Calories = 101,
                Protein = 2,
                Fat = 3,
                Carbs = 1
            };

            return item;
        }
    }
}
