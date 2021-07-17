using Badges_Models;
using Badges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Console
{
    public class ProgramUI
    {
        BadgeRepo _badgeRepo = new BadgeRepo();
        public void Run()
        {
            SeedData();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("\nWelcome, Security Admin. What would you like to do?\n" +
                    "_______Menu_______\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");

                bool keepAsking = true;
                while (keepAsking)
                {
                    keepAsking = false;
                    string answer = Console.ReadLine();
                    switch (answer)
                    {
                        case "1":
                            CreateBadge();
                            break;
                        case "2":
                            EditBadge();
                            break;
                        case "3":
                            ListBadges();
                            break;
                        case "4":
                            keepRunning = false;
                            break;
                        default:
                            Console.WriteLine("Select 1-3");
                            keepAsking = true;
                            break;
                    }
                }
            }
        }
        public void CreateBadge()
        {
            Console.WriteLine("Input the badge's number");
            int badgeID = OutputProperID();
            if (_badgeRepo.CheckIfBadgeExists(badgeID))
            {
                Console.WriteLine("This badge number is taken.");
                CreateBadge();
            }

            Console.WriteLine("What door do they need access to?");
            string doorName = Console.ReadLine().ToUpper();
            List<string> doors = new List<string>() { doorName };
            Badge badge = new Badge(badgeID, doors);
            _badgeRepo.Create(badge);
            bool keepAsking = false;
            bool addMoreDoors = true;
            Console.WriteLine("Would you like to add more doors? (y/n)");
            do
            {
                keepAsking = false;
                string yesOrNo = Console.ReadLine().ToLower();
                switch (yesOrNo)
                {
                    case "y":
                        break;
                    case "n":
                        addMoreDoors = false;
                        break;
                    default:
                        keepAsking = true;
                        Console.WriteLine("Select y or n");
                        break;
                }
            } while (keepAsking);
            if (addMoreDoors)
            {
                AddMoreDoors(badgeID);
            }
        }

        public void EditBadge()
        {
            ListBadges();
            Console.WriteLine("What is the ID of the badge you'd like to update?");
            int badgeID = OutputProperID();
            List<string> doors = _badgeRepo.ReturnBadges()[badgeID];

            bool keepUpdating = true;
            while (keepUpdating)
            {
                Console.WriteLine($"BadgeID: {badgeID}      Door Access: {string.Join(", ", doors)}");
                Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door\n" +
                "3. Return to main menu");
                bool keepAsking = true;

                while (keepAsking)
                {
                    keepAsking = false;
                    string answer = Console.ReadLine();
                    switch (answer)
                    {
                        case "1":
                            if (doors.Count == 0)
                            {
                                Console.WriteLine("This badge has no door accesses to remove");
                                break;
                            }
                            RemoveDoor(badgeID);
                            break;
                        case "2":
                            AddMoreDoors(badgeID);
                            break;
                        case "3":
                            keepUpdating = false;
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Select 1-3");
                            keepAsking = true;
                            break;
                    }
                }
            }
        }
        public void ListBadges()
        {
            Dictionary<int, List<string>> badges = _badgeRepo.ReturnBadges();

            foreach(var badge in badges)
            {
                Console.WriteLine($"BadgeID: {badge.Key}      Door Access: {string.Join(", ", badge.Value)}");
            }
            Console.WriteLine();
        }

        public void RemoveDoor(int badgeID)
        {
            List<string> doors = _badgeRepo.ReturnBadges()[badgeID];
            Console.WriteLine("What door would you like to remove?");
            string door = default;
            bool requestDoor = true;

            while(requestDoor)
            {
                door = Console.ReadLine().ToUpper();
                if (!doors.Contains(door))
                {
                    Console.WriteLine("Input a door the badge already has access to in order to remove it");
                }
                else
                {
                    _badgeRepo.DeleteDoor(badgeID, door);
                    requestDoor = false;
                }
            }
        }
        public void AddMoreDoors(int badgeID)
        {
            bool addingDoors = true;
            bool keepAsking = false;
            string yesOrNo = default;

            while (addingDoors)
            {
                Console.WriteLine("Input a door this badge needs access to:");
                string newDoor = Console.ReadLine().ToUpper();
                _badgeRepo.AddDoor(badgeID, newDoor);
                Console.WriteLine("Would you like to add any other doors? (y/n)");
                do
                {
                    keepAsking = false;
                    yesOrNo = Console.ReadLine().ToLower();
                    switch (yesOrNo)
                    {
                        case "y":
                            break;
                        case "n":
                            addingDoors = false;
                            break;
                        default:
                            keepAsking = true;
                            Console.WriteLine("Select y or n");
                            break;
                    }
                } while (keepAsking);
            }
            Console.Clear();
        }
        public int OutputProperID()
        {
            string answer = default;
            bool check = default;
            do
            {
                answer = Console.ReadLine();
                check = int.TryParse(answer, out int test);
                if (!check)
                {
                    Console.WriteLine("Give a valid number");
                }
            } while (!check);

            return int.Parse(answer);
        }

        public void SeedData()
        {
            int badgeOneID = 1;
            int badgeTwoID = 2;
            int badgeThreeID = 3;

            List<string> one = new List<string>() { "A1", "A2", "A3" };
            List<string> two = new List<string>() { "B1", "B2", "B3" };
            List<string> three = new List<string>() { "C1", "C2", "C3" };

            Badge badgeOne = new Badge(badgeOneID, one);
            Badge badgeTwo = new Badge(badgeTwoID, two);
            Badge badgeThree = new Badge(badgeThreeID, three);

            _badgeRepo.Create(badgeOne);
            _badgeRepo.Create(badgeTwo);
            _badgeRepo.Create(badgeThree);
        }
    }
}
