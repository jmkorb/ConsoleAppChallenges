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
            Console.WriteLine("Welcome, Security Admin. What would you like to do?\n" +
                "1. Add a badge\n" +
                "2. Edit a badge\n" +
                "3. List all badges.");

            bool keepAsking = false;
            while(keepAsking)
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
                    default:
                        Console.WriteLine("Select 1-3");
                        keepAsking = true;
                        break;
                }
            }
        }
        public void CreateBadge()
        {
            Console.WriteLine("What is the number on the badge?");
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
            int badgeID = int.Parse(answer);

            Console.WriteLine("What door do they need access to?");
            string doorName = Console.ReadLine();
            List<string> doors = new List<string>() { doorName };
            Badge badge = new Badge(badgeID, doors);
            _badgeRepo.Create(badge);

            Console.WriteLine("Would you like to add any other doors? (y/n)");

        }

        public void EditBadge()
        {

        }
        public void ListBadges()
        {

        }
    }
}
