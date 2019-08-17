using ClaimChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Claim = ClaimChallenge.Claim;

namespace ClaimUI
{
    public class KClaimUI
    {
        private ClaimRepo _claimRepo = new ClaimRepo();

        public void Run()
        {
            Seed();
            Main();
        }
        private void Main()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select one of the following options: \n" +
                    "1. Next Claim \n" +
                    "2. Add Claim \n" +
                    "3. View all Claims \n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //Next Claim
                        NextClaim();
                        break;
                    case "2":
                        //Add Claim
                        AddClaim();
                        break;
                    case "3":
                        //View All Claims
                        ViewAll();
                        break;
                    case "4":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //Add Claim
        public void AddClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            //ClaimID
            Console.WriteLine("What is the claim ID?");
            newClaim.ClaimID = Console.ReadLine();


            //ClaimType
            Console.WriteLine("What is the claim type? \n" +
                "1. House\n" +
                "2. Car \n" +
                "3. Theft");
            newClaim.ClaimType = (TypeOfClaim)int.Parse(Console.ReadLine());
                                 //casting - taking one type and converting

            //Description
            Console.WriteLine("Claim description:");
            newClaim.Description = Console.ReadLine();


            //ClaimAmount
            Console.WriteLine("Claim Amount:");
            string newClaimAmmount = Console.ReadLine();
            double claimAmount = double.Parse(newClaimAmmount);
            newClaim.ClaimAmount = (int)claimAmount;

            //Date Of Incident
            Console.WriteLine("Date of incident(YYYY, MM, DD):");
            string incidentDate = Console.ReadLine();
            DateTime dateOfIncident = Convert.ToDateTime(incidentDate);
            newClaim.DateOfIncident = (DateTime)dateOfIncident;


            //Date Of Claim
            Console.WriteLine("Date of claim (YYYY, MM, DD):");
            string claimDate = Console.ReadLine();
            DateTime dateOfClaim = Convert.ToDateTime(claimDate);
            newClaim.DateOfClaim = (DateTime)dateOfClaim;

            _claimRepo.AddClaim(newClaim);
        }
        //View All Claims
        private void ViewAll()
        {
            Console.Clear();

            Queue<Claim> listOfClaims = _claimRepo.GetAllClaims();


            foreach (Claim newClaim in listOfClaims)
            {
                ClaimInfoConsoleDisplay(newClaim);
            }
        }
        public void NextClaim()
        {
            Console.Clear();
            //"catches" whatever is returned
            Queue<Claim> entireQueue = _claimRepo.GetAllClaims();
            Claim nextClaim = entireQueue.Peek();
            ClaimInfoConsoleDisplay(nextClaim);

            //Remove
            Console.WriteLine("Remove? Type Y or N");
            string userInput = Console.ReadLine();
            if (userInput == "Y")
            {
                entireQueue.Dequeue();
            }
            if (userInput == "N")
            {
                return;
            }
        }

        //Claim info
        private void ClaimInfoConsoleDisplay(Claim newClaim)
        { 
               Console.WriteLine($"Claim ID: {newClaim.ClaimID} \n" +
                                  $"Claim Type: {newClaim.ClaimType} \n" +
                                  $"Claim Description: {newClaim.Description} \n" +
                                  $"Date of Claim: {newClaim.DateOfClaim.ToShortDateString()} \n" +
                                  $"Date of Incident: {newClaim.DateOfIncident.ToShortDateString()}\n" +
                                  $"Valid?: {newClaim.IsValid}\n");
            

        }

        private void Seed()
        {
            Claim theft = new Claim("123", TypeOfClaim.Theft, "Stolen pancake", 5.50d, new DateTime(2009, 04, 05), new DateTime(2009, 04, 09));

            Claim home = new Claim("123", TypeOfClaim.House, "Stolen pancake", 5.50d, new DateTime(2009, 04, 05), new DateTime(2009, 04, 09));

            _claimRepo.AddClaim(theft);
            _claimRepo.AddClaim(home);
        }
    }
}
