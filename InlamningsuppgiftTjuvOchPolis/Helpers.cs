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
        public static void DrawWorld(List<Person> persons)
        {
            int antalArrested = 0;
            int antalRobbed = 0;

            while (true) 
            {                  
                Console.SetCursorPosition(0, 29);
                Console.WriteLine("Antal rånade medborgare: " + antalRobbed);
                Console.WriteLine("Antal gripna tjuvar: " + antalArrested);


                for (int i = 0; i < persons.Count; i++)
                {
                if (persons[i] is Medborgare)
                {
                    Console.SetCursorPosition(persons[i].PositionX, persons[i].PositionY);
                    Console.Write("M");

                }

                if (persons[i] is Polis)
                {
                    Console.SetCursorPosition(persons[i].PositionX, persons[i].PositionY);
                    Console.Write("P");

                    antalArrested = Polis.Meet(persons[i], persons, antalArrested);
                    

                }

                if (persons[i] is Tjuv)
                {
                    Console.SetCursorPosition(persons[i].PositionX, persons[i].PositionY);
                    Console.Write("T");

                    antalRobbed = Tjuv.Meet(persons[i], persons, antalRobbed);
                                                    
                }

            }

                Person.Move(persons);

                Thread.Sleep(200);
                Console.Clear();
            }
        }

        public static void WriteWorld(List<Person> persons)
        {
            int antalArrested = 0;
            int antalRobbed = 0;

            while (true)
            {
                Console.SetCursorPosition(0, 0);

                for (int i = 0; i < persons.Count; i++)
                    {
                    Console.Write(persons[i].GetType().Name + " " + persons[i].PositionX + ", " + persons[i].PositionY + "\t");

                    if (persons[i] is Medborgare)
                    {
                        foreach (Sak sak in ((Medborgare)persons[i]).Tillhorigheter)
                        {
                            Console.Write(sak.Type + ", ");
                        }
                    }

                    if (persons[i] is Tjuv)
                    {
                        Tjuv.Meet(persons[i], persons, antalRobbed);

                        foreach (Sak sak in ((Tjuv)persons[i]).Stoldgods)
                        {
                            Console.Write(sak.Type + ", ");
                        }
                    }

                    if (persons[i] is Polis)
                    {
                        Polis.Meet(persons[i], persons, antalArrested);

                        foreach (Sak sak in ((Polis)persons[i]).Beslagtaget)
                        {
                            Console.Write(sak.Type + ", ");
                        }
                    }
                    Console.WriteLine();
                }

                Person.Move(persons);
               
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
