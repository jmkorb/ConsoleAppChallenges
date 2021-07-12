using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Models
{
    public enum ClaimType
    {
        Car,
        Home,
        Theft
    }
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType Type { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim() { }

        public Claim( int claimID, ClaimType type, string description, double amount, 
            DateTime dateOfAccident, DateTime dateOfClaim, bool isValid)
        {
            this.ClaimID = claimID;
            this.Type = type;
            this.Description = description;
            this.Amount = amount;
            this.DateOfAccident = dateOfAccident;
            this.DateOfClaim = dateOfClaim;
            this.IsValid = isValid;
        }
    }
}
