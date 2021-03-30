using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUserData.Model
{
    public class Goal
    {
        public int Steps { get; set; }
        public Weight Weight { get; set; }
        public WeightChange WeightChange { get; set; }
        public int CalorieGoal { get; set; }
    }
}
