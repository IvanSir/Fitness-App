using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCL.Model
{
    [Serializable]
    public class Activity
    {
        
        public string Name { get;}

        public double CaloriesPerMinute { get; }

        public Activity(string name,double cpm)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Invalid name", nameof(name));
            }
           
            Name = name;

            CaloriesPerMinute = cpm;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
