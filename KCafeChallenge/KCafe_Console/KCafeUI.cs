using KCafeChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCafe_Console
{
    class KCafeUI
    {
        private MenuRepo _menuRepo = new MenuRepo();
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
                    "1. Add Item \n" +
                    "2. Delete Item \n" +
                    "3. View All \n" +
                    "4. Exit");


                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //Add Item
                        AddItem();
                        break;

                    case "2":
                        //Delete Item
                        DeleteItem();
                        break;

                    case "3":
                        //View All
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

        //Case 1

        public void AddItem()
        {
            Console.Clear();
            MenuItem newItem = new MenuItem();

            //Item Name
            Console.WriteLine("What is the item name?");
            newItem.ItemName = Console.ReadLine();


            //Item Number
            Console.WriteLine("What is the item number?");
            string newItemNumber = Console.ReadLine();
            int itemNumber = int.Parse(newItemNumber);
            newItem.ItemNumber = (int)itemNumber;

            //Item Description
            Console.WriteLine("Description of item.");
            newItem.Description = Console.ReadLine();

            //Item Ingredients
            Console.WriteLine("List ingredients in item.");
            newItem.Ingredients = Console.ReadLine();

            //Item Price ---> an int can be a double so it works
            Console.WriteLine("What is the price of the item");
            string newItemPrice = Console.ReadLine();
            int itemPrice = int.Parse(newItemPrice);
            newItem.Price = (int)itemPrice;

            //This adds item to repo so UI will remember the new item
            //references the method in repo that actually adds the new item
            _menuRepo.AddItemToMenu(newItem);
        }

        //Case 2
        public void DeleteItem()
        {
            Console.Clear();

            ViewAll();

            Console.WriteLine("Enter item number to be deleted.");
            string input = Console.ReadLine();
            int number = int.Parse(input);
            bool wasDeleted = _menuRepo.DeleteItemFromMenu(number); //this number has to be an int

            //bool
            if (wasDeleted)
            {
                Console.WriteLine("Item has been removed");

                //View  list with removed item
                ViewAll();

            }
            else
                Console.WriteLine("Item could not be removed");
        }

        //Case 3
        public void ViewAll()
        {
            Console.Clear();

            List<MenuItem> listOfItems = _menuRepo.GetMenuItems();

            foreach (MenuItem item in listOfItems)
            {
                // use item. so it pulls info for that specific item
                Console.WriteLine($"{item.ItemNumber}. {item.ItemName} {item.Price}");
            }

        }
    }
}
