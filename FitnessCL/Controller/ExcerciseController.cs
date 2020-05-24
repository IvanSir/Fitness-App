using FitnessCL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCL.Controller
{
    public class ExcerciseController : ControllerBase
    {
        private readonly User User;

        public List<Excercise> Excercises { get; }
        public List<Activity> Activities { get; }

        public ExcerciseController(User user)
        {
            User = user ?? throw new ArgumentNullException("Invalid user", nameof(user));
            Excercises = GetAllExcercises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>("activities.dat") ?? new List<Activity>();
        }

        private List<Excercise> GetAllExcercises()
        {
            return Load<List<Excercise>>("excercises.dat") ?? new List<Excercise>();
        }

        private void Save()
        {
            Save("excercises.dat", Excercises);
            Save("activities.dat", Activities);
        }

        public void Add(Activity activity,DateTime start,DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if(act == null)
            {
                Activities.Add(activity);
                var excercise = new Excercise(start, end, activity, User);
                Excercises.Add(excercise);
                
            }
            else
            {
                var excercise = new Excercise(start, end, act, User);
                Excercises.Add(excercise);
            }

            Save();



        }
    }
}
