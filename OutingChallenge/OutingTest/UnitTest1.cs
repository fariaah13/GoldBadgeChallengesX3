using System;
using KomodoOutingChallenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OutingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            KomodoOutingChallenge.OutingRepo repo = new KomodoOutingChallenge.OutingRepo();
            
               Assert.AreEqual(4, repo.ViewAllOutings().Count);
            
        }

        [TestMethod]
        public void AddNewOuting()
        {
            KomodoOutingChallenge.OutingRepo repo = new KomodoOutingChallenge.OutingRepo();

            int countofoutings = repo.ViewAllOutings().Count;

            Outing outing = new Outing(TypeOfEvent.Golf, 30, DateTime.UtcNow, 15d);
            repo.AddOutingEvent(outing);

            Assert.AreEqual(countofoutings + 1, repo.ViewAllOutings().Count);
        }
    }
}
