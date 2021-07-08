using Cafe_Models;
using Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console
{
    class ProgramUI
    {
        private readonly MenuItemRepo cafe_Repository = new MenuItemRepo();
        int mealNumber = default;
        public void Run()
        {
            Console.WriteLine("Welcome to Komodo Cafe's menu manager!");

            Console.WriteLine("What would you like to do?\n" +
                "1. Add a new meal to the menu.\n" +
                "2. Delete a meal from the menu.");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    break;
                case "2":
                    break;
            }


        }

        public void CreateMeal()
        {
            List<string> ingredientsList = new List<string>();

            Console.WriteLine("What is the name of the meal?");
            string name = Console.ReadLine();

            Console.WriteLine("Add the meal description:");
            string description = Console.ReadLine();

            bool addingIngredients = true;

            while (addingIngredients)
            {
                Console.WriteLine("Add one of the ingredient's:");
                string ingredient = Console.ReadLine();

                ingredientsList.Add(ingredient);

                Console.WriteLine("Are there any more ingredients to add? y/n");
                string answer = Console.ReadLine();

                bool keepAsking = true;
                while (keepAsking)
                {
                    if (answer == "n")
                    {
                        addingIngredients = false;
                        keepAsking = false;
                    }
                    else if (answer == "y")
                    {
                        keepAsking = false;
                    }

                    Console.WriteLine("Please answer either y or n.");
                }
            }

            Console.WriteLine("How much will this meal cost?");
            string getPrice = Console.ReadLine();
            double price = double.Parse(getPrice);

            MenuItem newItem = new MenuItem( mealNumber++, name, description, ingredientsList, price );


        }
    }
}
