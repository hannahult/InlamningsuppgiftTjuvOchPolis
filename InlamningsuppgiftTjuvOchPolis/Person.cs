using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningsuppgiftTjuvOchPolis
{
    internal class Person
    {
        public int PositionX {  get; set; }

        public int PositionY { get; set; }

        public int DirectionX { get; set; }

        public int DirectionY { get; set; }

        public Person() 
        {
            PositionX = Random.Shared.Next(1, 101);
            PositionY = Random.Shared.Next(1, 26);

            DirectionX = Random.Shared.Next(-1, 2);
            DirectionY = Random.Shared.Next(-1, 2);

        }

        public virtual void Meet()
        {

        }

        public static void Move(int[,] area, List <Person> persons)
        {
            foreach (Person person in persons)
            {
                person.PositionX += person.DirectionX;
                person.PositionY += person.DirectionY;


                if (person.PositionY >= area.GetLength(0))
                {
                    person.PositionY = 1;
                }
                else if (person.PositionY < area.GetLength(0))
                {
                    person.PositionY = 25;
                }

                if (person.PositionX >= area.GetLength(1))
                {
                    person.PositionX = 1;
                }
                else if (person.PositionX < area.GetLength(1))
                {
                    person.PositionX = 100;
                }

            }


        }
    }

    class Polis : Person
    {
        public List<Sak> Beslagtaget { get; set; }

        public Polis():base()
        {
            List<Sak> beslagtaget = new List<Sak>();

            Beslagtaget = beslagtaget;

        }

        
        public static List<Person> Meet(Polis polis, List<Person> persons)
        {
            foreach (Person person in persons)
            {
                if (polis.PositionX == person.PositionX && polis.PositionY == person.PositionY)
                {
                    if (person is Tjuv)
                    {
                        foreach (Sak sak in person.Stoldgods)
                        {
                            polis.Beslagtaget.Add(sak);
                            person.Stoldgods.Remove(sak);
                            
                            //skicka till status

                        }
                    }
                }

            }

            return persons;

        }


      

        
    }

    class Tjuv : Person
    {
        public List<Sak> Stoldgods { get; set; }

        public Tjuv():base()
        {      
            List<Sak> stoldgods = new List<Sak>();
            
            Stoldgods = stoldgods;
        }

        

        
    }
    class Medborgare : Person
    {
        public List<Sak> Tillhorigheter { get; set; }

        public Medborgare():base()
        {
           
            
            List <Sak> tillhorigheter = new List<Sak>();

            tillhorigheter.Add(new Sak("nycklar"));
            tillhorigheter.Add(new Sak("mobil"));
            tillhorigheter.Add(new Sak("plånbok"));
            tillhorigheter.Add(new Sak("klocka"));

            Tillhorigheter = tillhorigheter;

        }
    }

    
}
