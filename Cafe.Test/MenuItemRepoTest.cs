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
        private readonly MenuItemRepo _repo = new MenuItemRepo();

        [TestInitialize]
        public void Arrange()
        {
            List<string> ingredientsList = new List<string>() { "buns", "beef patty", "lettuce", "thousand island" };
            MenuItem menuItem = new MenuItem(123, "Big Mac", "The original king", ingredientsList, 3.00);
            _repo.CreateItem(menuItem);
        }


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
            // Act - actually calling the method
            bool result = _repo.CreateItem(menuItem);

            // Assert - making sure the method did what it was supposed
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetMealByID_MealExists_ReturnMeal()
        {
            int id = 123;

            MenuItem result = _repo.GetMealByID(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.MealNumber, id);
        }

        [TestMethod]
        public void GetMealByID_MealDoesNotExist_ReturnNull()
        {
            int id = 5;

            MenuItem result = _repo.GetMealByID(id);

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
            bool result = _repo.DeleteItem(menuItem);

            Assert.IsTrue(result);
        }
    }
}
