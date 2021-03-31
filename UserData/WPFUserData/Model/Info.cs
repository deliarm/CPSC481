using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUserData.Model;

namespace WPFUserData.Model
{
    public class Info
    {
        public int Age { get; set; }
        public BiologicalSex Sex { get; set; }
        public Weight Weight { get; set; }
        public Height Height { get; set; }
        public String ActivityLevel { get; set; }

        public int CalorieIntakeToday
        {
            get
            {
                int cals = 0;
                
                foreach(Meal meal in Meal.getMealsByDate(DateTime.Now.Date))
                {
                    cals += meal.Calories;
                }

                return cals;
            }
        }

        public int CalorieBurnedToday
        {
            get
            {
                int cals = 0;

                foreach(Activity activity in Activity.getActivitiesByDate(DateTime.Now.Date))
                {
                    cals += activity.CaloriesBurned;
                }

                return cals;
            }
        }
    }
}
