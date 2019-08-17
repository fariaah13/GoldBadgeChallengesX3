using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOutingChallenge
{
    public enum TypeOfEvent
    {
        Golf = 1,
        Bowling,
        Park,
        Concert
    }
    public class Outing
    {
        public int NumberOfPeople { get; set; }
        public DateTime DateOfEvent { get; set; }
        public double CostPerPerson { get; set; }
        public TypeOfEvent EventType { get; set; }

        public Outing() { }

        public Outing(TypeOfEvent eventType, int numberOfPeople, DateTime dateOfEvent, double costPerPerson)
        {
            EventType = eventType;
            NumberOfPeople = numberOfPeople;
            DateOfEvent = dateOfEvent;
            CostPerPerson = costPerPerson;
            
        }
    }

}
