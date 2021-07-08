﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Models
{
    public class MenuItem
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public double Price { get; set; }

        public MenuItem() { }
        
        public MenuItem(string mealName, string description, List<string> ingredients, double price)
        {
            this.MealName = mealName;
            this.Description = description;
            this.Ingredients = ingredients;
            this.Price = price;
        }

        public MenuItem(int mealNumber, string mealName, string description, List<string> ingredients, double price)
        {
            this.MealNumber = mealNumber;
            this.MealName = mealName;
            this.Description = description;
            this.Ingredients = ingredients;
            this.Price = price;
        }
        
    }
}
