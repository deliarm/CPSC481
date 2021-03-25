using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUserData.Model
{
    public class FoodItem
    {
        private static User user = User.getInstance();

        public string Name { get; set; }
        public int Quantity { get; set; }

        public String QuantityStr
        {
            get { return "x" + Quantity; }
        }

        public int Calories { get; set; }

        public String CaloriesStr
        {
            get { return Calories + " cal"; }
        }
        public int Protein { get; set; }
        public int Fat { get; set; }
        public int Carbs { get; set; }

        public static FoodItem getByName(String foodName)
        {
            foreach (FoodItem item in user.FoodDatabase)
            {
                if (item.Name == foodName)
                {
                    return item;
                }
            }

            return null;
        }

    }
}
