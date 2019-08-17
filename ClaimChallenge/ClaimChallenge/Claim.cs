using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimChallenge
{
    public enum TypeOfClaim
    {
        House = 1,
        Car,
        Theft
    }
    public class Claim
    {
        public string ClaimID { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get
            {
                TimeSpan ValidClaim = DateOfClaim - DateOfIncident;
                if (ValidClaim.Days < 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Claim() { }

        public Claim(string claimID, TypeOfClaim claimType, string description, double claimAmount,
                     DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
