using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeekSeatTechnicalTest;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestYearOfBirthSukses()
        {
            Person person = new Person();
            person.Age = 1;
            person.YearOfDeath = 10;
            PersonYearOfBirth yob = new PersonYearOfBirth();
            int personYob = yob.GetYearOfBirth(person);
            Assert.AreNotEqual(personYob, -1);
        }
        [TestMethod]
        public void TestYearOfBirthGagal()
        {
            Person person = new Person();
            person.Age = -1;
            person.YearOfDeath = 10;
            PersonYearOfBirth yob = new PersonYearOfBirth();
            int personYob = yob.GetYearOfBirth(person);
            Assert.AreEqual(personYob, -1);
        }
        [TestMethod]
        public void TestGetVillagerKiledSukses()
        {
            VillagerReport report = new VillagerReport();
            Witch witch = new Witch();
            witch.KillHistory = report.GetVillagerKilled(10);
            Assert.IsNotNull(witch.KillHistory);
        }
        [TestMethod]
        public void TestGetVillagerKiledFailed()
        {
            VillagerReport report = new VillagerReport();
            Witch witch = new Witch();
            witch.KillHistory = report.GetVillagerKilled(0);
            Assert.IsNull(witch.KillHistory);
        }
        [TestMethod]
        public void TestGetPeopleKilledOnYearBornSukses()
        {
            VillagerReport report = new VillagerReport();
            Witch witch = new Witch();
            witch.KillHistory = report.GetVillagerKilled(10);
            int peoplekilled = report.GetPeopleKilledOnYearBorn(witch, 5);
            Assert.AreNotEqual(peoplekilled,-1);
        }
        [TestMethod]
        public void TestGetPeopleKilledOnYearBornFailed()
        {
            VillagerReport report = new VillagerReport();
            Witch witch = new Witch();
            witch.KillHistory = report.GetVillagerKilled(0);
            int peoplekilled = report.GetPeopleKilledOnYearBorn(witch, 5);
            Assert.AreEqual(peoplekilled, -1);
        }
    }
}
