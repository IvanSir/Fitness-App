using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCL.Model
{
    [Serializable]
    public class Excercise
    {

        public DateTime Start { get; }
        public DateTime Finish { get; }

        public Activity Activity { get; }

        public User User { get; }

        public Excercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;

        }
    }
}
