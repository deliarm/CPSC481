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

        public List<Weight> WeightHistory { get; set; }

        public Info Info { get; set; } = new Info();
        public Goal Goal { get; set; } = new Goal();

        public User()
        {
            Meals = new List<Meal>();
            Steps = new List<Step>();
            Activities = new List<Activity>();
            WeightHistory = new List<Weight>();
            FoodDatabase = new List<FoodItem>();

            FillFoodDatabase();

            FillHistoricData();
        }

        private void FillHistoricData()
        {
            FillUserInfo();
            FillHistoricMeals();
            FillHistoricActivities();
            FillHistoricWeight();
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
            this.Info.Weight.Date = DateTime.Today;


            this.Info.ActivityLevel = ActivityLevel.None;

            this.Goal.Weight = new Weight();
            this.Goal.Weight.Number = 180;
            this.Goal.Weight.Unit = this.Info.Weight.Unit;

            this.Goal.WeightChange = new WeightChange();
            this.Goal.WeightChange.PerWeekWeight = new Weight();
            this.Goal.WeightChange.PerWeekWeight.Number = -0.5;
            this.Goal.WeightChange.PerWeekWeight.Unit = this.Info.Weight.Unit;

            this.Goal.CalorieGoal = CalcTDEE();

            this.Info.CurrSteps = 0;
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

        public double CalcTDEE ()
        {
            double weight = this.Info.Weight.Number;
            if (this.Info.Weight.Unit == WeightUnit.Pounds)
                weight /= 2.205;

            double bmr = weight * 20;
            double tef = bmr * 0.1;
            double neat = GetNeat();
            double eee = 250;
            double total = bmr + tef + neat + eee;
            double wchange = this.Goal.WeightChange.PerWeekWeight.Number; 

            total += (wchange * 200);

            return total;  
        }

        private void FillHistoricMeals()
        {
            Random random = new Random();
            for (int i = -400; i < 0; i++)
            {
                
                Meal meal = new Meal
                {
                    Type = MealType.Breakfast,
                    Date = DateTime.Today.AddDays(i),
                    FoodItems = new List<FoodItem>
                    {
                        getRandomFoodItem(random)   
                    }
                };
                Meals.Add(meal);    
            }
        }

        private void FillHistoricWeight()
        {
            Random random = new Random();
            int currweight = Convert.ToInt32(this.Info.Weight.Number);
            string unit = this.Info.Weight.Unit;
            for (int i = -400; i < -1; i++)
            {

                Weight weight = new Weight
                {
                    Number = random.Next(currweight - 10, currweight + 10),
                    Date = DateTime.Today.AddDays(i),
                    Unit = unit
                };
                WeightHistory.Add(weight);
            }
            Weight w = new Weight
            {
                Number = this.Info.Weight.Number,
                Date = DateTime.Today.AddDays(0),
                Unit = unit
            };
            Weight yes = new Weight
            {
                Number = this.Info.Weight.Number,
                Date = DateTime.Today.AddDays(-1),
                Unit = unit
            };
            WeightHistory.Add(yes);
            WeightHistory.Add(w);
        }

        private FoodItem getRandomFoodItem(Random random)
        {
            int calGoal = Convert.ToInt32(this.Goal.CalorieGoal);
            FoodItem item = new FoodItem
            {
                Name = "Waffles",
                Quantity = 2,
                Calories = random.Next(calGoal-700,calGoal+700),
                CaloriePerItem = 101,
                Protein = 2,
                Fat = 3,
                Carbs = 1
            };

            return item;
        }

        private void FillHistoricActivities()
        {
            

            for (int i = 0; i > -400; i--)
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
            for (int i = 1; i > -400; i--)
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
            FoodDatabase.Add(new FoodItem { Name = "Waffles", Quantity = 1, CaloriePerItem = 101, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Apples", Quantity = 1, CaloriePerItem = 90, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Eggs", Quantity = 1, CaloriePerItem = 60, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Pasta", Quantity = 1, CaloriePerItem = 250, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Coffee", Quantity = 1, CaloriePerItem = 44, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "BLT Sandwich", Quantity = 1, CaloriePerItem = 300, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Chili", Quantity = 1, CaloriePerItem = 444, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Ice cream", Quantity = 1, CaloriePerItem = 300, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Sushi", Quantity = 1, CaloriePerItem = 222, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Carrots", Quantity = 1, CaloriePerItem = 6, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Bananas", Quantity = 1, CaloriePerItem = 77, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Toast", Quantity = 1, CaloriePerItem = 101, Protein = 2, Fat = 3, Carbs = 1 });
            FoodDatabase.Add(new FoodItem { Name = "Cereal", Quantity = 1, CaloriePerItem = 194, Protein = 2, Fat = 3, Carbs = 1 });
        }
    }
}
