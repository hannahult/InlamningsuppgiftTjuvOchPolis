using System.ComponentModel;
using System.Threading;

namespace InlamningsuppgiftTjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int copsSize = 10;
            int thiefSize = 20;
            int citicenSize = 30;

            
            //skapar poliser
            List<Polis> poliser = new List<Polis>();
            poliser = Helpers.CreateCops(copsSize);

            //skapar tjuvar
            List<Tjuv> tjuvar = new List<Tjuv>();
            tjuvar = Helpers.CreateThieves(thiefSize);

            //skapar medborgare
            List<Medborgare> medborgare = new List<Medborgare>();
            medborgare = Helpers.CreateCiticens(citicenSize);   
            
            //lägger in alla olika personer i en och samma lista
            List<Person> persons = new List<Person>();         
            foreach (Medborgare medborgares in medborgare)
            {
                persons.Add(medborgares);
            }
            foreach (Polis polis in poliser)
            {
                persons.Add(polis);
            }
            foreach (Tjuv tjuv in tjuvar)
            {
                persons.Add(tjuv);  
            }
            
            //ritar upp och loopar staden
            Helpers.DrawCity(persons);
        
            //Helpers.WriteWorld(persons);

 
        }
    }
}
