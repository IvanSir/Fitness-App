using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessCL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessCL.Model;

namespace FitnessCL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
   
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var gender = "man";
            var height = 180;
            var weight = 60;

            var userController = new UserController(userName);

            userController.SetNewUserData(gender, birthDate, weight, height);
            var userController2 = new UserController(userName);
           
            Assert.AreEqual(userName, userController2.CurrentUser.Name);
            Assert.AreEqual(birthDate, userController2.CurrentUser.BirthDate);
            Assert.AreEqual(height, userController2.CurrentUser.Height);
            Assert.AreEqual(weight, userController2.CurrentUser.Weight);
            Assert.AreEqual(gender, userController2.CurrentUser.Gender.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            var userName = Guid.NewGuid().ToString();

            var userController = new UserController(userName);

            Assert.AreEqual(userName, userController.CurrentUser.Name);
        }
    }
}