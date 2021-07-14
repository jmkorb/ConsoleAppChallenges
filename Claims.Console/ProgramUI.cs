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
            SeedData();
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
                        Console.Clear();
                        DisplayClaims();
                        break;
                    case "2":
                        Console.Clear();
                        CompleteNextClaim();
                        break;
                    case "3":
                        Console.Clear();
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
                if (correctInput)
                {
                    correctInput = CheckForIdDuplicates(int.Parse(inputValue));
                    if (!correctInput)
                    {
                        Console.WriteLine("This number has been taken.");
                    }
                }
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
                Console.WriteLine("This claim is not valid.");
                isValid = false;
            }
            else
            {
                Console.WriteLine("This claim is valid.");
            }

            Claim claim = new Claim(claimID, claimType, claimDescription, claimAmount, dateOfAccident, claimDate, isValid);
            _claims.Create(claim);
        }

        public void DisplayClaims()
        {
            Queue<Claim> listOfClaims = _claims.ReadClaims();
            foreach(Claim item in listOfClaims)
            {
                Console.WriteLine($"Claim: {item.ClaimID}\n" +
                    $"Type: {item.Type}  " +
                    $"Description: {item.Description}  " +
                    $"Amount: {item.Amount}\n" +
                    $"Date of Accident: {item.DateOfAccident.Date.ToString("d")}  " +
                    $"Date of Claim: {item.DateOfClaim.Date.ToString("d")}  " +
                    $"Is Valid: {item.IsValid}\n");
            }
            Console.WriteLine();
        }

        public void CompleteNextClaim()
        {
            Queue<Claim> allClaims = _claims.ReadClaims();
            Claim nextClaim = allClaims.Peek();
            Console.WriteLine($"ClaimID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.Type}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Amount: {nextClaim.Amount}\n" +
                $"Date of Accident: {nextClaim.DateOfAccident.Date.ToString("d")}\n" +
                $"Date of Claim: {nextClaim.DateOfClaim.Date.ToString("d")}\n" +
                $"Is Valid: {nextClaim.IsValid}\n");

            Console.WriteLine("Do you want to deal with this claim now? (y/n)");
            string givenAnswer = default;
            do
            {
                givenAnswer = Console.ReadLine().ToLower();
                switch (givenAnswer)
                {
                    case "y":
                        _claims.Delete();
                        Console.Clear();
                        Console.WriteLine("Done!");
                        break;
                    case "n":
                        break;
                    default:
                        Console.WriteLine("Provide a 'y' or 'n'");
                        givenAnswer = default;
                        break;
                }
            } while (givenAnswer == default);
        }

        public bool CheckForIdDuplicates(int checkID)
        {
            Queue<Claim> claims = _claims.ReadClaims();
            int counter = 0;
            foreach(Claim claim in claims)
            {
                if(checkID == claim.ClaimID)
                {
                    counter++;
                }
            }
            if(counter > 0)
            { 
                return false;
            }
            else
            {
                return true;
            }
        }

        public void SeedData()
        {
            Claim firstClaim = new Claim (1, ClaimType.Theft, "Stole their stereo", 500.00, new DateTime(2021, 3, 1), new DateTime(2021, 3, 10), true);
            Claim secondClaim = new Claim (2, ClaimType.Home, "Tornado damage", 500.00, new DateTime(2021, 4, 1), new DateTime(2021, 4, 13), true);
            Claim thirdClaim = new Claim (3, ClaimType.Car, "Delorean crashed after coming through space-time continuum", 2300.05, new DateTime(1987, 5, 1), new DateTime(2021, 6, 10), false);

            _claims.Create(firstClaim);
            _claims.Create(secondClaim);
            _claims.Create(thirdClaim);
        }
    }
}
