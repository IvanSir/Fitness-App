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
    public class ExcerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var rnd = new Random();
            
            var activityName = new Guid().ToString();
            var userController = new UserController(new Guid().ToString());
            var excerciseController = new ExcerciseController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(10,50));
            
            
            excerciseController.Add(activity,DateTime.Now,DateTime.Now.AddHours(1));


            Assert.AreEqual(activityName, excerciseController.Activities.First().Name);
        }
    }
}