using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using FitnessCL;
using FitnessCL.Controller;
using FitnessCL.Model;

namespace FitnessCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resource = new ResourceManager("FitnessCMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resource.GetString("Hello",culture));
            Console.WriteLine(resource.GetString("EnterName",culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if(userController.IsNewUser)
            {
                Console.WriteLine("What's your gender?");
                var gender = Console.ReadLine();
                var birthDate = ParseDate("BirthDate");
                var height = ParseDouble("height");
                var weight = ParseDouble("weight");
                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();

 
            var excerciseController = new ExcerciseController(userController.CurrentUser);
            var eatingController = new EatingController(userController.CurrentUser);

            while (true)
            {


                Console.WriteLine("What's next?");
                Console.WriteLine("E - add food");
                Console.WriteLine("A - add excercise");
                Console.WriteLine("Q - quit");

                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Item1, foods.Item2);
                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;

                    case ConsoleKey.A:
                        var exc = EnterExcercise();
                        excerciseController.Add(exc.Item3, exc.Item1, exc.Item2);
                        foreach(var item in excerciseController.Excercises)
                        {
                            Console.WriteLine($"{item.Activity} from {item.Start.ToShortTimeString()} to {item.Finish.ToShortTimeString()}");
                        }
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();
            }
            }

        private static (DateTime,DateTime,Activity) EnterExcercise()
        {
            Console.WriteLine("Input name of the Excercise");
            var name = Console.ReadLine();

            var cpm = ParseDouble("calories per minute");
            var begin = ParseDate("Begin time");
            var end = ParseDate("End time");

            var activity = new Activity(name, cpm);

            return (begin,end,activity);

        }

        private static (Food,double) EnterEating()
        {
            Console.WriteLine("Input name");
            var food = Console.ReadLine();

            var weight = ParseDouble("weight");
            var calories = ParseDouble("calories");
            var proteins = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbo = ParseDouble("carbohydrates");
            var product = new Food(food,proteins,fats,carbo,calories);
            return (product, weight);
        }

        private static double ParseDouble(string message)
        {
            
            while(true)
            {
                Console.WriteLine($"What is your {message}?");
                if (double.TryParse(Console.ReadLine(), out double number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine($"Invalid {message}");
                }
            }

        }

        private static DateTime ParseDate(string message)
        {
            while(true)
            {
                Console.WriteLine($"What's your {message}? dd.mm.yyyy");
                if(DateTime.TryParse(Console.ReadLine(),out DateTime birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine($"Invalid {message}");
                }
            }
        }

    }
}
