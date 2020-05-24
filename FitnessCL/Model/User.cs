using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCL.Model
{
    [Serializable]
    public class User
    {
        #region Properties

        public string Name { get; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }
       
        public double Weight { get; set; }
        
        public double Height { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }

        #endregion
        public User(string name, 
                    Gender gender, 
                    DateTime birthDate, 
                    double weight, 
                    double height)
        {
            #region Exceptions
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Invalid name", nameof(name));
            }
            if(gender == null)
            {
                throw new ArgumentNullException("Invalid gender", nameof(gender));
            }
            if(birthDate < DateTime.Parse("01.01.1930") || birthDate > DateTime.Now)
            {
                throw new ArgumentException("Invalid date", nameof(birthDate));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Invalid height", nameof(height));
            }
            if(weight <= 0)
            {
                throw new ArgumentException("Invalid weight", nameof(weight));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Invalid name", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }


    }
}
