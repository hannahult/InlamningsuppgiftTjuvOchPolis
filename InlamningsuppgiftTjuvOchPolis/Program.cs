using System.ComponentModel;
using System.Threading;

namespace InlamningsuppgiftTjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int policeSize = 10;
            int thiefSize = 20;
            int citicenSize = 30;

            
            //skapar poliser
            List<Police> polices = new List<Police>();
            polices = Helpers.CreatePolices(policeSize);

            //skapar tjuvar
            List<Thief> thieves = new List<Thief>();
            thieves = Helpers.CreateThieves(thiefSize);

            //skapar medborgare
            List<Citizen> citizens = new List<Citizen>();
            citizens = Helpers.CreateCiticens(citicenSize);   
            
            //lägger in alla olika personer i en och samma lista
            List<Person> persons = new List<Person>();         
            foreach (Citizen citizen in citizens)
            {
                persons.Add(citizen);
            }
            foreach (Police police in polices)
            {
                persons.Add(police);
            }
            foreach (Thief thief in thieves)
            {
                persons.Add(thief);  
            }
            
            //ritar upp och loopar staden
            Helpers.DrawCity(persons);
        
        }
    }
}
