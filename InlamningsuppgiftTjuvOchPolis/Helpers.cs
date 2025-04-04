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
            int numberOfArrested = 0;
            int numberOfRobbed = 0;

            while (true)
            {
                //skriver ut antal rånade och antal arresterade längst ner under staden
                Console.SetCursorPosition(0, 29);
                Console.WriteLine("Antal rånade medborgare: " + numberOfRobbed);
                Console.WriteLine("Antal gripna tjuvar: " + numberOfArrested);

                //loopar igenom alla personer
                for (int i = 0; i < persons.Count; i++)
                {
                    //ritar ut M för medborgare om personen är det
                    if (persons[i] is Citizen)
                    {
                        Console.SetCursorPosition(persons[i].PositionX, persons[i].PositionY);
                        Console.Write("M");
                    }

                    //ritar ut P för polis om personen är polis
                    if (persons[i] is Police)
                    {
                        Console.SetCursorPosition(persons[i].PositionX, persons[i].PositionY);
                        Console.Write("P");
                    }

                    //ritar ut T för tjuv om personen är en tjuv
                    if (persons[i] is Thief)
                    {
                        Console.SetCursorPosition(persons[i].PositionX, persons[i].PositionY);
                        Console.Write("T");
                    }
                }

                for (int i = 0; i < persons.Count; i++)
                {
                    if (persons[i] is Police)
                    {
                        //kör metoden polis möter och uppdaterar antalet arresreade om polisen mött en tjuv med stöldgods
                        numberOfArrested = Police.Meet(persons[i], persons, numberOfArrested);

                    }
                    if (persons[i] is Thief)
                    {
                        //kör metoden tjuv möter och uppdaterar antalet rånade om tjuven mött en medborgare
                        numberOfRobbed = Thief.Meet(persons[i], persons, numberOfRobbed);

                    }
                   
                }

                //förflyttar alla personer
                Person.Move(persons);

                //pausar skärmen sen rensar den innan den loopas igen
                Thread.Sleep(200);
                Console.Clear();

            }
        }
        
        public static List<Police> CreatePolices(int policeSize)
        {
            List<Police> polices = new List<Police>();

            for (int i = 0; i < policeSize; i++)
            {
                polices.Add(new Police());
            }

            return polices;
        }

        public static List<Thief> CreateThieves(int thiefSize)
        {
            List<Thief> thieves = new List<Thief>();

            for (int i = 0; i < thiefSize; i++)
            {
                thieves.Add(new Thief());
            }

            return thieves;
        }

        public static List<Citizen> CreateCiticens(int citicenSize)
        {
            List<Citizen> citizens = new List<Citizen>();

            for (int i = 0; i < citicenSize; i++)
            {
                citizens.Add(new Citizen());
            }

            return citizens;
        }  

    }
}
