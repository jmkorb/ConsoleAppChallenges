using Badges_Models;
using Badges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Badge_Test
{
    [TestClass]
    public class BadgeRepoTest
    {

        private readonly BadgeRepo _repo = new BadgeRepo();

        [TestInitialize]
        public void Arrange()
        {
            int badgeOneID = 1;
            List<string> one = new List<string>() { "A1", "A2", "A3" };
            Badge badgeOne = new Badge(badgeOneID, one);
            _repo.Create(badgeOne);
        }

        [TestMethod]
        public void Create_BadgeIsNull_ReturnFalse()
        {
            Badge badge = new Badge();
            bool result = _repo.Create(badge);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Create_BadgeAlreadyExists_ReturnFalse()
        {
            List<string> list = new List<string>();
            Badge badge = new Badge(1, list);
            bool result = _repo.Create(badge);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Create_BadgeIsCreated_ReturnTrue()
        {
            List<string> list = new List<string>();
            Badge badge = new Badge(2, list);
            bool result = _repo.Create(badge);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddDoor_BadgeDoesntExist_ReturnFalse()
        {
            bool result = _repo.AddDoor(2, "test");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddDoor_BadgeExists_ReturnTrue()
        {
            bool result = _repo.AddDoor(1, "A4");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteDoor_BadgeDoesntExist_ReturnFalse()
        {
            bool result = _repo.DeleteDoor(2, "test");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeleteDoor_BadgeExists_ReturnTrue()
        {
            bool result = _repo.DeleteDoor(1, "A1");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckIfBadgeExists_BadgeDoesNotExist_ReturnFalse()
        {
            bool result = _repo.CheckIfBadgeExists(2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckIfBadgeExists_BadgeExists_ReturnTrue()
        {
            bool result = _repo.CheckIfBadgeExists(1);

            Assert.IsTrue(result);
        }
    }
}
