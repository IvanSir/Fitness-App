using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCL.Model
{
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; }
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Invalid gender", nameof(name));
            }

            Name = name;
        }
        
        public override string ToString()
        {
            return Name;

        }
    }
}
