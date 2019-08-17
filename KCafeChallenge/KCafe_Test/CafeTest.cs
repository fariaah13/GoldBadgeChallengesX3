using System;
using System.Collections.Generic;
using KCafeChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KCafe_Test
{
    [TestClass]
    public class CafeTest
    {
        [TestMethod]
        public void AddItems()
        {
            //Arrange
            MenuRepo repo = new MenuRepo(); //----> new object of MenuRepo
            MenuItem hotDog = new MenuItem("Hot Dog", 1, "It's a hot dog.", "Bun, hotdog, mustard, relish", 1.00d);
            //Act
            repo.AddItemToMenu(hotDog);
            List<MenuItem> listOfItemOnMenu = repo.GetMenuItems();
            //Assert
            bool foundItem = false;
            foreach (MenuItem item in listOfItemOnMenu)
            {
                if (item.ItemName == hotDog.ItemName)
                {
                    Console.WriteLine($"{item.ItemNumber}. {item.ItemName}\n" +
                        $"{item.Description}");

                    foundItem = true;
                    break;
                }
            }
            Assert.IsTrue(foundItem);
        }
        public void RemoveItems()
        {
            //Arrange
            MenuRepo repo = new MenuRepo();
            //Act
            //Assert
        }
    }
}
