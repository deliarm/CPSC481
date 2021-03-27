using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUserData.Model
{
    public class Activity
    {
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public Distance Distance { get; set; }
        public ActivityType Type { get; set; }
        public int CaloriesBurned {
            get {
                return (int)(Distance.Number / (10 / Duration.TotalMinutes) * 50);
            }
        }

        public String StartTimeStr { 
            get
            {
                return StartTime.ToString("hh:MM tt");
            } 
        }

        public String DurationCaloriesStr
        {
            get
            {
                //"30 min, 750 cal"

                return Duration.TotalMinutes + " min, " + CaloriesBurned + " cal";
            }
        }

        public String DistanceStr
        {
            get {
                return Distance.Number + " " + Distance.Unit;
            }
        }

        private static User user = User.getInstance();

        static public List<Activity> getActivitiesByDate(DateTime date)
        {
            List<Activity> result = new List<Activity>();
            foreach (Activity activity in user.Activities)
            {
                if(activity.Date == date.Date)
                {
                    result.Add(activity);
                }
            }

            return result;
        }
    }
}
