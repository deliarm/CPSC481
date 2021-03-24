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

        public Info Info = new Info();
        public Goal Goal = new Goal();

        public User()
        {
            Meals = new List<Meal>();
            Steps = new List<Step>();
            Activities = new List<Activity>();


            FillHistoricData();
        }

        private void FillHistoricData()
        {
            FillUserInfo();
            FillHistoricMeals();
        }

        private void FillUserInfo()
        {
            this.Info.Age = 24;
            this.Info.Sex = BiologicalSex.Male;

            this.Info.Height = new Height();
            this.Info.Height.Number = 169;
            this.Info.Height.Unit = HeightUnit.Centimeters;

            this.Info.Weight = new Weight();
            this.Info.Weight.Number = 199;
            this.Info.Weight.Unit = WeightUnit.Pounds;


            this.Info.ActivityLevel = ActivityLevel.None;

            this.Goal.Weight = new Weight();
            this.Goal.Weight.Number = 180;
            this.Goal.Weight.Unit = this.Info.Weight.Unit;

            this.Goal.WeightChange = new WeightChange();
            this.Goal.WeightChange.PerWeekWeight = new Weight();
            this.Goal.WeightChange.PerWeekWeight.Number = 0.5;
            this.Goal.WeightChange.PerWeekWeight.Unit = this.Info.Weight.Unit;


            this.Goal.Steps = 6000;

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
