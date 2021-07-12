using Cafe_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    public class MenuItemRepo
    {
        private readonly List<MenuItem> _menuItems = new List<MenuItem>();
        // Create
        public bool CreateItem(MenuItem item)
        {
            if (item == default)
            {
                return false;
            }
            
            this._menuItems.Add(item);
            return true;
        }

        // Read
        public List<MenuItem> GetFullMenu()
        {
            return _menuItems;
        }

        public MenuItem GetMealByID(int id)
        {
            foreach (MenuItem meal in _menuItems)
            {
                if (meal.MealNumber == id)
                {
                    return meal;
                }
                
            }
            return null;
        }


        // Delete
        public bool DeleteItem(MenuItem item)
        {
            if (item == default)
            {
                return false;
            }

            this._menuItems.Remove(item);
            return true;
        }
    }
}
