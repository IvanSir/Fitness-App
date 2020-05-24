using FitnessCL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCL.Controller
{
    class FitnessContext : DbContext
    {
        public FitnessContext(): base("DBConnection") { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Food> Foods { get; set; }

        public DbSet<Excercise> Excercises { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<User> User { get; set; }
    }
}
