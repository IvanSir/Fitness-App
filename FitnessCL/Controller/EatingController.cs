using FitnessCL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCL.Controller
{
    public class EatingController :ControllerBase
    {
        private readonly User user;

        public Eating Eating { get; }
        public List<Food> Foods { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Invalid user", nameof(user));

            Foods = GetAllFood();
            Eating = GetEating();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        private Eating GetEating()
        {
            return Load<Eating>("eatings.dat") ?? new Eating(user);
        }

        private List<Food> GetAllFood()
        {
            return Load<List<Food>>("food.dat") ?? new List<Food>();
        }

        private void Save()
        {
            Save("food.dat", Foods);
            Save("eatings.dat", Eating);
        }
    }
}
