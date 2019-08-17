using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutingChallenge
{
    public class OutingRepo
    {
        public List<Outing> _listOfOutings = new List<Outing>();

        public OutingRepo()
        {
            Seed();
        }


        //Display All --- list
        public List<Outing> ViewAllOutings()
        {
            return _listOfOutings;
        }

        //Add Outing .Add
        public void AddOutingEvent(Outing newOuting)
        {
            _listOfOutings.Add(newOuting);
        }

        //This method shows a list of outings by different types

        public List<Outing> ListByType(TypeOfEvent type)
        {
            List<Outing> listByType = new List<Outing>();

            foreach (Outing outing in _listOfOutings)
            {
                if (outing.EventType == type)
                {
                    listByType.Add(outing);
                }
            }

            return listByType;
        }
        //Helper Total Cost for all Outings
        public double TotalCost(List<Outing> outings)
        {
            double totalCost = 0;
            foreach (Outing trip in outings)
            {
                totalCost += trip.CostPerPerson;
            }

            return totalCost;
        }

        public void Seed()
        {
            Outing golf = new Outing(TypeOfEvent.Golf, 10, DateTime.UtcNow, 10.00d);
            _listOfOutings.Add(golf);

            Outing park = new Outing(TypeOfEvent.Park, 30, DateTime.UtcNow, 15.00d);
            _listOfOutings.Add(park);

            Outing concert = new Outing(TypeOfEvent.Concert, 10, DateTime.UtcNow, 20.00d);
            _listOfOutings.Add(concert);

            Outing bowling = new Outing(TypeOfEvent.Bowling, 10, DateTime.UtcNow, 30.00d);
            _listOfOutings.Add(bowling);
        }

    }
}
