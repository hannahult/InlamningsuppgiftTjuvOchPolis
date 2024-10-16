using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InlamningsuppgiftTjuvOchPolis
{
    internal class Helpers
    {
        public static void DrawWorld(List<Person> persons)
        {
            while (true)
            {
                for (int i = 0; i < persons.Count; i++)
                {
                    if (persons[i] is Polis)
                    {


                        Console.SetCursorPosition(persons[i].PositionX, persons[i].PositionY);
                        Console.Write("P");

                        Polis.Meet(persons[i], persons);

                        

                    }
                

                    if (persons[i] is Tjuv)
                    {
                        Console.SetCursorPosition(persons[i].PositionX, persons[i].PositionY);
                        Console.Write("T");
                        Tjuv.Meet(persons[i], persons);

                        

                    }
               
                    if (persons[i] is Medborgare)
                    {
                        Console.SetCursorPosition(persons[i].PositionX, persons[i].PositionY);
                        Console.Write("M");

                       
                    }

                }
            
                Person.Move(persons);

                

                Thread.Sleep(2000);
                Console.Clear();
                

            }

        }

        public static void WriteWorld(List<Person> persons)
        {
            while (true)
            {
                foreach (Person person in persons)
                {
                    Console.Write(person.GetType() + " " + person.PositionX + ", " + person.PositionY + "\t");

                    if (person is Medborgare)
                    {
                        foreach (Sak sak in ((Medborgare)person).Tillhorigheter)
                        {
                            Console.Write(sak.Type + ", ");
                        }
                    }

                    if (person is Tjuv)
                    {
                        foreach (Sak sak in ((Tjuv)person).Stoldgods)
                        {
                            Console.Write(sak.Type + ", ");
                        }
                    }

                    if (person is Polis)
                    {
                        foreach (Sak sak in ((Polis)person).Beslagtaget)
                        {
                            Console.Write(sak.Type + ", ");
                        }
                    }
                    Console.WriteLine();
                }
                Person.Move(persons);              
                Thread.Sleep(200);
                Console.Clear ();
            }
        }

        public static void WriteStatus(string status)
        {
            List<string> historik = new List<string>();

            historik.Add(status);

            Console.SetCursorPosition(1,27);
            foreach (string s in historik)
            {
                Console.Write(s);
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
