using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekSeatTechnicalTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input person A Age of death: ");
            int personA_age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please input person A Year of death: ");
            int personA_yod = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please input person B Age of death: ");
            int personB_age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please input person B Year of death: ");
            int personB_yod = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please input how long the witch take control in years: ");
            int yearofwitch = Convert.ToInt32(Console.ReadLine());


            VillagerReport report = new VillagerReport();
            Witch witch = new Witch();
            witch.KillHistory = report.GetVillagerKilled(yearofwitch);

            Person PersonA = new Person();
            PersonA.Age = personA_age;
            PersonA.YearOfDeath = personA_yod;

            Person PersonB = new Person();            
            PersonB.Age = personB_age;
            PersonB.YearOfDeath = personB_yod;

            PersonYearOfBirth yob = new PersonYearOfBirth();
            int personAyob = yob.GetYearOfBirth(PersonA);
            int personByob = yob.GetYearOfBirth(PersonB);

            int peoplekilledonA = report.GetPeopleKilledOnYearBorn(witch, personAyob);
            int peoplekilledonB = report.GetPeopleKilledOnYearBorn(witch, personByob);

            List<decimal> peopleKilled = new List<decimal>();
            Victims victim = new Victims();
            peopleKilled.Add(peoplekilledonA);
            peopleKilled.Add(peoplekilledonB);
            decimal averagePeopleGetKilled = victim.GetAverage(peopleKilled);

            Console.WriteLine("Person A born on year: " + PersonA.YearOfDeath + "-" + PersonA.Age +" = "+ personAyob + ", number people killed on year " + personAyob + " is " + peoplekilledonA);
            Console.WriteLine("Person B born on year: " + PersonB.YearOfDeath + "-" + PersonB.Age + " = " + personByob + ", number people killed on year " + personByob + " is " + peoplekilledonB);
            Console.WriteLine("So the average is (" + peoplekilledonB + " + " + peoplekilledonA + ") / " + peopleKilled.Count + " = " + averagePeopleGetKilled);
            Console.Write("Please enter any key to exit");
            Console.ReadLine();
        }
    }
    public class Person
    {
        public int Age { get; set; }
        public int YearOfDeath { get; set; }
    }
    public class PersonYearOfBirth
    {
        public int GetYearOfBirth(Person person)
        {
            if (person.Age < 0)
                return -1;
            int born = person.YearOfDeath - person.Age;
            if (born < 0)
                return -1;
            return born;
        }
    }
    public class Witch
    {
        public List<int> KillHistory { get; set; }
    }
    public class VillagerReport
    {
        public List<int> GetVillagerKilled(int yearoperated)
        {
            if (yearoperated < 1)
                return null;
            int getKilled = 0;
            int kill = 1;
            String Informations = "" + kill;
            List<int> KillHistory = new List<int>();
            KillHistory.Add(kill);
            for (int i = 1; i <= yearoperated; i++)
            {
                int executed = getKilled + kill;
                KillHistory.Add(executed);
                getKilled = kill;
                kill = executed;
                Console.WriteLine("On Year " + (i) + " the witch kill " + Informations + " = " + KillHistory.GetRange(0, KillHistory.Count - 1).Sum());
                Informations += " + " + executed;
            }
            return KillHistory;
        }
        public int GetPeopleKilledOnYearBorn(Witch witch, int yearOfBirth)
        {
            try
            {
                int peopleKilled = witch.KillHistory.GetRange(0,yearOfBirth).Sum();
                return peopleKilled;
            }
            catch
            {
                //add log here
                return -1;
            }
        }
    }
    public class Victims
    {
        public decimal GetAverage(List<decimal> peoplekilled)
        {
            return Convert.ToDecimal(peoplekilled.Sum() / peoplekilled.Count);
        }
    }
}
