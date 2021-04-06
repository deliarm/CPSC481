using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUserData.Model
{
    public class FoodItem
    {
        public List<String> quantities { get; set; } = new List<string> { "x1", "x2", "x3", "x4", "x5", "x6", "x7", "x8", "x9", "x10" };

        public string Name { get; set; }
        public int Quantity { get; set; }

        public String QuantityStr
        {
            get { return "x" + Quantity; }
            set
            {
                Quantity = Int32.Parse(value.Substring(1));
            }
        }

        public int CaloriePerItem { get; set; }

        public int Calories { 
            get
            {
                return CaloriePerItem * Quantity;
            } 
            // If we can get away without a setter that would be best.
            //set
            //{
            //    CaloriePerItem = value / Quantity;
            //} 
        }

        public String CaloriesStr
        {
            get { return Calories + " cal"; }
        }
        public int Protein { get; set; }
        public int Fat { get; set; }
        public int Carbs { get; set; }

        public static FoodItem getByName(String foodName)
        {
            User user = User.getInstance();

            foreach (FoodItem item in user.FoodDatabase)
            {
                if (item.Name == foodName)
                {
                    return item;
                }
            }

            return null;
        }

        public FoodItem()
        {

        }

        public FoodItem(FoodItem other)
        {
            Name = other.Name;
            Quantity = other.Quantity;
            CaloriePerItem = other.CaloriePerItem;
            Protein = other.Protein;
            Fat = other.Fat;
            Carbs = other.Carbs;
        }

    }
}
