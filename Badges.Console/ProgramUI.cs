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
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome, Security Admin. What would you like to do?\n" +
                    "_______Menu_______\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");

                bool keepAsking = false;
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

            Console.WriteLine("What door do they need access to?");
            string doorName = Console.ReadLine();
            List<string> doors = new List<string>() { doorName };
            Badge badge = new Badge(badgeID, doors);
            _badgeRepo.Create(badge);

            AddMoreRooms(badgeID);
        }

        public void EditBadge()
        {
            Console.WriteLine("What is the badge number to update?");
            int badgeID = OutputProperID();
            List<string> doors = _badgeRepo.ReturnBadges()[badgeID];
            Console.WriteLine($"Badge {badgeID} has access to doors {string.Join("&", doors)}");

            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door\n" +
                "3. Return to menu");
            bool keepUpdating = true;
            bool keepAsking = true;
            while (keepUpdating)
            { 
                while (keepAsking)
                {
                    keepAsking = false;
                    string answer = Console.ReadLine();
                    switch (answer)
                    {
                        case "1":
                            break;
                        case "2":
                            AddMoreRooms(badgeID);
                            break;
                        case "3":
                            break;
                        default:
                            keepAsking = true;
                            break;
                    }
                }
            }
        }
        public void ListBadges()
        {

        }

        public void RemoveRoom(int badgeID)
        {
            Console.WriteLine("What room would you like to remove?");
        }

        public void AddMoreRooms(int badgeID)
        {
            Console.WriteLine("Would you like to add any other doors? (y/n)");
            bool addingRooms = true;
            string yesOrNo = default;
            do
            {
                yesOrNo = Console.ReadLine();
                switch (yesOrNo)
                {
                    case "y":
                        break;
                    case "n":
                        addingRooms = false;
                        break;
                    default:
                        Console.WriteLine("Select y or n");
                        break;
                }
            } while (yesOrNo != "n" || yesOrNo != "y");

            while (addingRooms)
            {
                Console.Clear();
                Console.WriteLine("Input a door this badge needs access to:");
                string newRoom = Console.ReadLine();
                _badgeRepo.AddRoom(badgeID, newRoom);
                AddMoreRooms(badgeID);
            }
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
                else if (_badgeRepo.CheckIfBadgeExists(int.Parse(answer)))
                {
                    Console.WriteLine("This badge number is taken. Please input a different number.");
                    check = false;
                }
            } while (!check);

            return int.Parse(answer);
        }

    }
}
