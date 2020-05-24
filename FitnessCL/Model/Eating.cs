using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCL.Model
{
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }
        public DateTime Moment { get; }

        public Dictionary<Food,double> Foods { get; }


        public User User { get; }

        public Eating(User user )
        {
            User = user ?? throw new ArgumentNullException("Invalid user",nameof(user));
            Moment = DateTime.Now;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
