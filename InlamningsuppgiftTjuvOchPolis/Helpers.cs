using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.NetworkInformation;

namespace InlamningsuppgiftTjuvOchPolis
{
    internal class Helpers
    {
        //metod som ritar upp "staden" och loopar den
        public static void DrawCity(List<Person> persons)
        {
            //antal för att hålla reda på antal rånade och antal arresterade
            int antalArrested = 0;
            int antalRobbed = 0;

            while (true)
            {
                //skriver ut antal rånade och antal arresterade längst ner under staden
                Console.SetCursorPosition(0, 29);
                Console.WriteLine("Antal rånade medborgare: " + antalRobbed);
                Console.WriteLine("Antal gripna tjuvar: " + antalArrested);

                //loopar igenom alla personer
                for (int i = 0; i < persons.Count; i++)
                {
                    //ritar ut M för medborgare om personen är det
                    if (persons[i] is Medborgare)
                    {
                        Console.SetCursorPosition(persons[i].PositionX, persons[i].PositionY);
                        Console.Write("M");
                    }

                    //ritar ut P för polis om personen är polis
                    if (persons[i] is Polis)
                    {
                        Console.SetCursorPosition(persons[i].PositionX, persons[i].PositionY);
                        Console.Write("P");
                    }

                    //ritar ut T för tjuv om personen är en tjuv
                    if (persons[i] is Tjuv)
                    {
                        Console.SetCursorPosition(persons[i].PositionX, persons[i].PositionY);
                        Console.Write("T");
                    }
                }

                for (int i = 0; i < persons.Count; i++)
                {
                    if (persons[i] is Polis)
                    {
                        //kör metoden polis möter och uppdaterar antalet arresreade om polisen mött en tjuv med stöldgods
                        antalArrested = Polis.Meet(persons[i], persons, antalArrested);

                    }
                    if (persons[i] is Tjuv)
                    {
                        //kör metoden tjuv möter och uppdaterar antalet rånade om tjuven mött en medborgare
                        antalRobbed = Tjuv.Meet(persons[i], persons, antalRobbed);

                    }
                   
                }

                //förflyttar alla personer
                Person.Move(persons);

                //pausar skärmen sen rensar den innan den loopas igen
                Thread.Sleep(200);
                Console.Clear();

            }
        }
        
        public static List<Polis> CreateCops(int copsSize)
        {
            List<Polis> poliser = new List<Polis>();

            for (int i = 0; i < copsSize; i++)
            {
                poliser.Add(new Polis());
            }

            return poliser;
        }

        public static List<Tjuv> CreateThieves(int thiefSize)
        {
            List<Tjuv> tjuvar = new List<Tjuv>();

            for (int i = 0; i < thiefSize; i++)
            {
                tjuvar.Add(new Tjuv());
            }

            return tjuvar;
        }

        public static List<Medborgare> CreateCiticens(int citicenSize)
        {
            List<Medborgare> medborgare = new List<Medborgare>();

            for (int i = 0; i < citicenSize; i++)
            {
                medborgare.Add(new Medborgare());
            }

            return medborgare;
        }  

    }
}
