using Cafe_Models;
using Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Cafe_Test
{
    [TestClass]
    public class MenuItemRepoTest
    {
        [TestMethod]
        public void CreateItem_MenuIsNull_ReturnFalse()
        {
            // Arrange - create any variables we need to test this method
            MenuItem menuItem = null;
            MenuItemRepo repo = new MenuItemRepo();

            // Act - actually calling the method
            bool result = repo.CreateItem(menuItem);

            // Assert - making sure the method did what it was supposed
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CreateItem_MenuIsNotNull_ReturnTrue()
        {
            // Arrange - create any variables we need to test this method
            List<string> ingredientsList = new List<string>() { "buns", "beef patty", "lettuce", "thousand island" };
            MenuItem menuItem = new MenuItem(123, "Big Mac", "The original king", ingredientsList, 3.00);
            MenuItemRepo repo = new MenuItemRepo();

            // Act - actually calling the method
            bool result = repo.CreateItem(menuItem);

            // Assert - making sure the method did what it was supposed
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetMealByID_MealExists_ReturnMeal()
        {
            List<string> ingredientsList = new List<string>() { "buns", "beef patty", "lettuce", "thousand island" };
            MenuItem menuItem = new MenuItem(123, "Big Mac", "The original king", ingredientsList, 3.00);
            MenuItemRepo repo = new MenuItemRepo();
            repo.CreateItem(menuItem);
            int id = 123;

            MenuItem result = repo.GetMealByID(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.MealNumber, id);
        }

        [TestMethod]
        public void GetMealByID_MealDoesNotExist_ReturnNull()
        {
            List<string> ingredientsList = new List<string>() { "buns", "beef patty", "lettuce", "thousand island" };
            MenuItem menuItem = new MenuItem(123, "Big Mac", "The original king", ingredientsList, 3.00);
            MenuItemRepo repo = new MenuItemRepo();
            repo.CreateItem(menuItem);
            int id = 5;

            MenuItem result = repo.GetMealByID(id);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteItem_MenuIsDefault_ReturnFalse()
        {
            MenuItem menuItem = null;
            MenuItemRepo repo = new MenuItemRepo();

            bool result = repo.DeleteItem(menuItem);

            Assert.IsFalse(result);
        }        

        [TestMethod]
        public void DeleteItem_MenuIsNotDefault_ReturnTrue()
        {
            List<string> ingredientsList = new List<string>() { "buns", "beef patty", "lettuce", "thousand island" };
            MenuItem menuItem = new MenuItem(123, "Big Mac", "The original king", ingredientsList, 3.00);
            MenuItemRepo repo = new MenuItemRepo();
            repo.CreateItem(menuItem);

            bool result = repo.DeleteItem(menuItem);

            Assert.IsTrue(result);
        }
    }
}
