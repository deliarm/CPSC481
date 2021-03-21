using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUserData.Model
{
    public class Activity
    {
        public DateTime Date;
        public DateTime StartTime;
        public TimeSpan Duration;
        public int Distance;
        public ActivityType Type;
        public int CaloriesBurned; /* Should this be a derived property? */
    }
}
