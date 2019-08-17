using System;
using System.Collections.Generic;
using KomodoOutingChallenge;

namespace OutingConsole
{
    class OutingUI
    {
        private OutingRepo _outingRepo = new OutingRepo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select an option: \n" +
                    "1. Add Outing \n" +
                    "2. View Costs by Outing\n" +
                    "3. View Total Costs \n" +
                    "4. View All Outings \n" +
                    "5. Exit");


                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //Add Item
                        AddOutingEvent();
                        break;


                    case "2":
                        //View Total Costs
                        TotalCost();
                        break;

                    case "3":
                        //View All Outings by cost
                        CostOfAllOutings();
                        break;
                    case "4":
                        //View all
                        ViewAll();
                        break;

                    case "5":
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

        //Case 1
        public void AddOutingEvent()
        {
            Console.Clear();

            //OutingType
            Console.WriteLine("Event type:");
            
        }

        //Case 2
        public void TotalCost()
        {
            List<Outing> outingList = new List<Outing>();

            var listOfEnums = Enum.GetValues(typeof(TypeOfEvent));
            foreach (TypeOfEvent eventType in listOfEnums)
            {
                outingList = _outingRepo.ListByType(eventType);
                Console.WriteLine($"The cost of this event was {_outingRepo.TotalCost(outingList)}");
            }
        }

        //Case 3
        public void CostOfAllOutings()
        {
            double costOfAllEvents = _outingRepo.TotalCost(_outingRepo.ViewAllOutings());
            Console.WriteLine($"The final cost is {costOfAllEvents}");
            
        }

        // Case 4
        public void ViewAll()
        {
            List<Outing> allOutings = _outingRepo.ViewAllOutings();
            foreach (Outing occasion in allOutings)
            {
                Console.WriteLine($"Event name: {occasion.EventType}\n" +
                                  $"Number of attendees {occasion.NumberOfPeople}\n" +
                                  $"Date of event: {occasion.DateOfEvent.ToString( )}\n" +
                                  $"Cost of event {occasion.CostPerPerson}");
            }
        }
    }
}
