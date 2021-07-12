using Claims_Models;
using Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Console
{
    public class ProgramUI
    {
        private readonly ClaimRepository _claims = new ClaimRepository();
        private readonly ClaimRepository _oldClaims = new ClaimRepository();

        public void Run()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");
                string menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case "1":
                        DisplayClaims();
                        break;
                    case "2":
                        //CompleteNextClaim();
                        break;
                    case "3":
                        CreateClaim();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                }
            }
        }

        public void CreateClaim()
        {
            bool correctInput = default;
            string inputValue = default;

            do
            {
                Console.WriteLine("Enter the claim ID number:");
                inputValue = Console.ReadLine();
                correctInput = int.TryParse(inputValue, out int result);
            } while (!correctInput);
            int claimID = int.Parse(inputValue);

            ClaimType claimType = default;
            bool runAgain = false;
            do
            {
                Console.WriteLine("What is type of claim is this? Car, Home, or Theft?");
                string typeAnswer = Console.ReadLine().ToLower();
                switch (typeAnswer)
                {
                    case "car":
                        claimType = ClaimType.Car;
                        break;
                    case "home":
                        claimType = ClaimType.Home;
                        break;
                    case "theft":
                        claimType = ClaimType.Theft;
                        break;
                    default:
                        Console.WriteLine("That is not an option.");
                        runAgain = true;
                        break;
                }
            } while (runAgain);
            Console.WriteLine("Enter a claim description:");
            string claimDescription = Console.ReadLine();

            do
            {
                Console.WriteLine("What is the cost of damage:");
                inputValue = Console.ReadLine();
                correctInput = double.TryParse(inputValue, out double result);
            } while (!correctInput);
            double claimAmount = double.Parse(inputValue);

            do
            {
                Console.WriteLine("What was the date of the incident? (MM/DD/YYYY)");
                inputValue = Console.ReadLine();
                correctInput = DateTime.TryParse(inputValue, out DateTime result);

            } while (!correctInput);
            DateTime dateOfAccident = DateTime.Parse(inputValue);

            do
            {
                Console.WriteLine("What is the date of the claim? (MM/DD/YYYY)");
                inputValue = Console.ReadLine();
                correctInput = DateTime.TryParse(inputValue, out DateTime result);
            } while (!correctInput);
            DateTime claimDate = DateTime.Parse(inputValue);

            TimeSpan timeDifference = claimDate.Subtract(dateOfAccident);
            bool isValid = true;
            if(timeDifference.Days > 30)
            {
                isValid = false;
            }

            Claim claim = new Claim(claimID, claimType, claimDescription, claimAmount, dateOfAccident, claimDate, isValid);
            _claims.Create(claim);
        }

        public void DisplayClaims()
        {
            Console.WriteLine($"{"ClaimID",10}" +
                $"{"Type",10}" +
                $"{"Description",10}" +
                $"{"Amount",10}" +
                $"{"DateOfAccident",10}" +
                $"{"DateOfClaim",10}" +
                $"{"IsValid",10}");
            //Console.WriteLine("ClaimID" + "\t" + "Type" + "\t" + "Description" + "\t" + "Amount" + "\t" +
            //    "DateOfAccident" + "\t" + "DateOfClaim" + "\t" + "IsValid");
            Queue <Claim> listOfClaims = _claims.ReadClaims();
            foreach(Claim item in listOfClaims)
            {
                //Console.WriteLine($"{item.ClaimID}" + "\t" + $"{item.Type}" + "\t" + $"{item.}" + "\t" + "Amount" + "\t" +
                //    "DateOfAccident" + "\t" + "DateOfClaim" + "\t" + "IsValid");
                Console.WriteLine($"{item.ClaimID,10}" +
                    $"{item.Type,10}" +
                    $"{item.Description,10}" +
                    $"{item.Amount,10}" +
                    $"{item.DateOfAccident,10}" +
                    $"{item.DateOfClaim,10}" +
                    $"{item.IsValid,10}");
            }
        }
    }
}
