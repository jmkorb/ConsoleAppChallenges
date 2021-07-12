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
        private readonly MenuItemRepo _cafeRepository = new MenuItemRepo();
        int mealNumber = 1;
        public void Run()
        {
            SeedData();
            bool keepRunning = true;
            while(keepRunning)
            {
                bool inMenu = false;
                do
                {
                    Console.WriteLine("Welcome to Komodo Cafe's menu manager!\n");

                    Console.WriteLine("What would you like to do?\n" +
                        "1. Add a new meal to the menu.\n" +
                        "2. Delete a meal from the menu.\n" +
                        "3. Display Current Menu.\n" +
                        "4. Exit\n");

                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            Console.Clear();
                            CreateMeal();
                            break;
                        case "2":
                            Console.Clear();
                            DeleteMeal();
                            break;
                        case "3":
                            Console.Clear();
                            DisplayMenu();
                            break;
                        case "4":
                            keepRunning = false;
                            break;
                        default:
                            Console.WriteLine("That's not one of the options.");
                            inMenu = true;
                            break;
                    }
                } while (inMenu);
                bool finishRunning = true;
                while(finishRunning)
                {
                    Console.WriteLine("\nWould you like to return to the menu? y/n");
                    string returnToMenu = Console.ReadLine();
                    switch (returnToMenu)
                    {
                        case "y":
                            finishRunning = false;
                            Console.Clear();
                            break;
                        case "n":
                            finishRunning = false;
                            keepRunning = false;
                            break;
                        default:
                            Console.WriteLine("Please answer y or n.");
                            break;
                    }
                }
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
                    else 
                    {
                        Console.WriteLine("Please answer either y or n.");
                    }
                }
            }

            Console.WriteLine("How much will this meal cost?");
            string getPrice = Console.ReadLine();
            double price = double.Parse(getPrice);

            MenuItem newItem = new MenuItem( mealNumber++, name, description, ingredientsList, price );
            _cafeRepository.CreateItem(newItem);
        }

        public void DeleteMeal()
        {
            DisplayMenu();
            Console.WriteLine("Please input the meal number you want to remove.");
            string inputMeal = Console.ReadLine();
            if(inputMeal == null || !int.TryParse(inputMeal, out int result))
            {
                DeleteMeal();
            }
            int selectedMeal = int.Parse(inputMeal);

            MenuItem meal = _cafeRepository.GetMealByID(selectedMeal);
            _cafeRepository.DeleteItem(meal);
        }

        public void DisplayMenu()
        {
            List<MenuItem> currentMenu = _cafeRepository.GetFullMenu();

            foreach (MenuItem meal in currentMenu)
            {
                Console.WriteLine($"#{meal.MealNumber} {meal.MealName}\n" +
                    $"{meal.Description}\n" +
                    $"Ingredients: {string.Join(", ", meal.Ingredients)}\n" +
                    $"Price: ${meal.Price}\n");
            }
        }

        private void SeedData()
        {
            List<string> ingredientsList = new List<string>() { "buns", "beef patty", "lettuce", "thousand island" };
            MenuItem bigMac = new MenuItem(123, "Big Mac", "The original king", ingredientsList, 3.00);
            MenuItem mcDouble = new MenuItem(124, "McDouble", "Two beef patties with cheese", ingredientsList, 2.00);
            MenuItem mcChicken = new MenuItem(125, "McChicken", "Chicken patty with lettuce and mayo", ingredientsList, 1.00);

            _cafeRepository.CreateItem(bigMac);
            _cafeRepository.CreateItem(mcDouble);
            _cafeRepository.CreateItem(mcChicken);
        }
    }
}
