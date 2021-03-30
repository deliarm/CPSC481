using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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

        public List<Meal> Meals { get; set; }
        public List<Step> Steps { get; set; }
        public List<Activity> Activities { get; set; }

        public List<FoodItem> FoodDatabase { get; set; }

        public Info Info { get; set; } = new Info();
        public Goal Goal { get; set; } = new Goal();

        public User()
        {
            Meals = new List<Meal>();
            Steps = new List<Step>();
            Activities = new List<Activity>();

            FoodDatabase = new List<FoodItem>();

            FillFoodDatabase();

            FillHistoricData();
        }

        private void FillHistoricData()
        {
            FillUserInfo();
            FillHistoricMeals();
            FillHistoricActivities();
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

            this.Goal.CalorieGoal = CalcTDEE();
            
            this.Goal.Steps = 6000;

        }

        private double GetNeat()
        {
            if (this.Info.ActivityLevel == ActivityLevel.Light)
                return 330;
            if (this.Info.ActivityLevel == ActivityLevel.Medium)
                return 410;
            if (this.Info.ActivityLevel == ActivityLevel.Heavy)
                return 500;
            return 250;
        }

        private int CalcTDEE ()
        {
            double weight = this.Info.Weight.Number;
            if (this.Info.Weight.Unit == WeightUnit.Pounds)
                weight /= 2.205;

            double bmr = weight * 20;
            double tef = bmr * 0.1;
            double neat = GetNeat();
            double eee = 250;

            return Convert.ToInt32(bmr + tef + neat + eee);   
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

        private void FillHistoricActivities()
        {
            

            for (int i = 0; i > -100; i--)
            {
                int y = Math.Abs(i);

                Activity activity = new Activity
                {
                    Type = (ActivityType)(y % 5), //Rotate activities
                    Date = DateTime.Now.Date.AddDays(i),
                    StartTime = DateTime.Now.AddDays(i).AddHours(y % 12),
                    Distance = new Distance
                    {
                        Number = 1 + (y % 5) + ((y % 9)/10.0),
                        Unit = DistanceUnit.Kilometers
                    },
                    Duration = TimeSpan.FromMinutes(30 + (y % 15))
                };
                Activities.Add(activity);
            }

            // Add a second, different activity
            for (int i = 1; i > -100; i--)
            {
                int y = Math.Abs(i);

                Activity activity = new Activity
                {
                    Type = (ActivityType)(y % 5), //Rotate activities
                    Date = DateTime.Now.Date.AddDays(i-1),
                    StartTime = DateTime.Now.AddDays(i).AddHours(y % 12),
                    Distance = new Distance
                    {
                        Number = 1 + (y % 5) + ((y % 9) / 10.0),
                        Unit = DistanceUnit.Kilometers
                    },
                    Duration = TimeSpan.FromMinutes(30 + (y % 5))
                };
                Activities.Add(activity);
            }
        }


        private void FillFoodDatabase()
        {
            FoodDatabase.Add(new FoodItem { Name = "Waffles", Quantity = 1, Calories = 101, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Apples", Quantity = 1, Calories = 90, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Eggs", Quantity = 1, Calories = 60, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Pasta", Quantity = 1, Calories = 250, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Coffee", Quantity = 1, Calories = 44, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "BLT Sandwich", Quantity = 1, Calories = 300, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Chili", Quantity = 1, Calories = 444, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Ice cream", Quantity = 1, Calories = 300, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Sushi", Quantity = 1, Calories = 222, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Carrots", Quantity = 1, Calories = 6, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Bananas", Quantity = 1, Calories = 77, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Toast", Quantity = 1, Calories = 101, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Cereal", Quantity = 1, Calories = 194, Protein = 2, Fat = 3, Carbs = 1 });
        }
    }
}
