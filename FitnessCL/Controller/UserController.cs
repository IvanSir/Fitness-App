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
    public class UserController : ControllerBase
    {
        public List<User> Users { get; }

        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;

        public UserController(string userName)
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Invalid name", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(us => us.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

        }

        private List<User> GetUsersData()
        {
            return Load<List<User>>("users.dat") ?? new List<User>();
        }

        public void SetNewUserData(string gendername, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(gendername);
            CurrentUser.Height = height;
            CurrentUser.Weight = weight;
            CurrentUser.BirthDate = birthDate;
            Save();

        }


        public void Save()
        {
            Save("user.dat",Users);
        }

        
    }
}
