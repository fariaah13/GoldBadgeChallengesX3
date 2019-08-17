using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCafeChallenge
{
    public class MenuRepo
    {
        public List<MenuItem> _listOfItems = new List<MenuItem>();

        //Add Items
        public void AddItemToMenu(MenuItem item)
        {
            _listOfItems.Add(item);
        }

        //View Items
        public List<MenuItem> GetMenuItems()
        {
            return _listOfItems;
        }

        //Delete Items
        public bool DeleteItemFromMenu(int number)
        {
            MenuItem item = GetItemByNumber(number);

            if (item == null)
            {
                return false; 
            }

            int initialCount = _listOfItems.Count;
            _listOfItems.Remove(item); 

            if(initialCount > _listOfItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper methods ---> gets item by number from list
        private MenuItem GetItemByNumber(int number)
        {
            foreach (MenuItem item in _listOfItems)
            {
                if (item.ItemNumber == number)
                {
                    return item; 
                }
            }
            return null;
        }
    }
}
