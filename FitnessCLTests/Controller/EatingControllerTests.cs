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
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        { var rnd = new Random();
            var userController = new UserController(new Guid().ToString());
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(new Guid().ToString(),rnd.Next(50,500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            eatingController.Add(food, 100);

            Assert.AreEqual(food.Name ,eatingController.Eating.Foods.First().Key.Name);
            
        }
    }
}