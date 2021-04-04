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
        public int ManualCaloriesBurned { get; set; } = -1; // Default to indicate that it hasn't been set
        public int CaloriesBurned {
            get {
                if(ManualCaloriesBurned != -1)
                {
                    return ManualCaloriesBurned;
                }
                else
                {
                    return CalcCaloriesBurned(Type, Distance, Duration);
                }
            }
        }

        public String StartTimeStr { 
            get
            {
                return StartTime.ToString("hh:mm tt");
            } 
        }

        public String DurationCaloriesStr
        {
            get
            {
                return (int)(Duration.TotalMinutes) + " min, " + CaloriesBurned + " cal";
            }
        }

        public String DistanceStr
        {
            get {
                return Distance.Number + " " + Distance.Unit;
            }
        }

        static public List<Activity> getActivitiesByDate(DateTime date)
        {
            User user = User.getInstance();
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

        /**
         * The method that is used to determine how many calories an activity burns
         */
        static public int CalcCaloriesBurned(ActivityType type, Distance distance, TimeSpan duration)
        {
            return (int)(distance.Number / (10 / duration.TotalMinutes) * 50); ;
        }
    }
}
