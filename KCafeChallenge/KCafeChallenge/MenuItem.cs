using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCafeChallenge
{
    public class MenuItem
    {
        public string ItemName { get; set; }
        public int ItemNumber { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }

        public MenuItem() { }

        public MenuItem(string itemName, int itemNumber, string description, string ingredients, double price)
        {
            ItemName = itemName;
            ItemNumber = itemNumber;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
