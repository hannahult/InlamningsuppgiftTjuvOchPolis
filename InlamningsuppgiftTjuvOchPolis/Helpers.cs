using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace InlamningsuppgiftTjuvOchPolis
{
    internal class Helpers
    {
        public static void DrawWorld(List<Person> persons)
        {
            while (true)
            {
                int[,] area = new int[25, 100];

                //lägg in collision

                //isoccupied position metod

                foreach (Person person in persons)
                {
                    if (person is Polis && area[person.PositionY, person.PositionX] == null)
                    {
                        
                        
                        Console.SetCursorPosition(person.PositionX, person.PositionY);            
                        Console.Write("P");
                        Polis.Meet(person, persons);
                        
                    }



                    if (person is Tjuv && person.PositionX == null && person.PositionY == null)
                    {
                        Console.SetCursorPosition(person.PositionX, person.PositionY);
                        Console.Write("T");
                        
                    }


                    if (person is Medborgare && person.PositionX == null && person.PositionY == null)
                    {
                        Console.SetCursorPosition(person.PositionX, person.PositionY);
                        Console.Write("M");
                        
                    }

                }

                foreach (Person person in persons)
                {
                    Console.Write(person.GetType + " " + person.PositionX + ", " + person.PositionY);

                    if (person is Medborgare)
                    {
                        foreach (Sak sak in Tillhorigheter)
                        { Console.Write(sak.Type); }


                    }

                    Thread.Sleep(2000);
                    Console.Clear();
                    persons = Person.Move(area[,], persons);

                }

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

        public static void Confiscate(Polis polis, Tjuv tjuv)
        {
            foreach (Sak sak in tjuv.Stoldgods)
            {
                polis.Beslagtaget.Add(sak);
                tjuv.Stoldgods.Remove(sak);
                //skicka till status
            }

        }

        public static void Robbery(Tjuv tjuv, Medborgare medborgares)
        {
            int rnd = Random.Shared.Next(1, medborgares.Tillhorigheter.Count + 1);
            tjuv.Stoldgods.Add(medborgares.Tillhorigheter[rnd]);

            medborgares.Tillhorigheter.RemoveAt(rnd);
            //skicka till status

        }

        public static void SayHello()
        {

        }

       
        public static void IsOccupied()
        {

        }

        public static void WriteStatus()
        {
            Console.WriteLine();
        }

    }
}
