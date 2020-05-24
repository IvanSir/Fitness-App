using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCL.Model
{
    [Serializable]
    public class Food
    {

        public string Name { get; set; }

        public double Proteins { get; set; }

        public double Fats { get; set; }

        public double Carbohydrates { get; set; }

        public double Calories { get; set; }

        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name, double proteins, double fats, double carbo, double calories)
        {
        
            
            if (string.IsNullOrWhiteSpace(name))
            {
            throw new ArgumentNullException("Invalid name", nameof(name));
            }


            Name = name;
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbo;
            Calories = calories;

        }

        public override string ToString()
        {
            return Name;

        }
    }
}
