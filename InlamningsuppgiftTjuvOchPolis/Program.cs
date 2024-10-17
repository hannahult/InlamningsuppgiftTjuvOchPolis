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

            List<Polis> poliser = new List<Polis>();
            poliser = Helpers.CreateCops(copsSize);

            List<Tjuv> tjuvar = new List<Tjuv>();
            tjuvar = Helpers.CreateThieves(thiefSize);

            List<Medborgare> medborgare = new List<Medborgare>();
            medborgare = Helpers.CreateCiticens(citicenSize);   
            
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
            
           
            Helpers.DrawWorld(persons);
        
            //Helpers.WriteWorld(persons);

 
        }
    }
}
