﻿using System;
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

        public static List <Person> Move( List<Person>  persons)
        {

            for (int i = 0; i < persons.Count; i++)
            {

                persons[i].PositionX += persons[i].DirectionX;
                persons[i].PositionY += persons[i].DirectionY;


                if (persons[i].PositionY > 25)
                {
                    persons[i].PositionY = 1;
                }
                if (persons[i].PositionY < 1)
                {
                    persons[i].PositionY = 25;
                }

                if (persons[i].PositionX > 100)
                {
                    persons[i].PositionX = 1;
                }
                if (persons[i].PositionX < 1)
                {
                    persons[i].PositionX = 100;
                }

            }
            return persons;

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

        
        public static List<Person> Meet(Person polis, List<Person> persons)
        {
            foreach (Person person in persons)
            {
                if (polis.PositionX == person.PositionX && polis.PositionY == person.PositionY)
                {
                    if (person is Tjuv)
                    {                 
                        for (int i = 0; i < ((Tjuv)person).Stoldgods.Count; i++) 
                           
                        {
                            ((Polis)polis).Beslagtaget.Add(((Tjuv)person).Stoldgods[i]);
                            ((Tjuv)person).Stoldgods.RemoveAt(i);

                            string status = "Polis beslagtar tjuvs stöldgods: " + polis.PositionX + ", " + polis.PositionY + "\n";

                            Helpers.WriteStatus(status);

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
        public static List<Person> Meet(Person tjuv, List<Person> persons)
        {
            foreach (Person person in persons)
            {
                if (tjuv.PositionX == person.PositionX && tjuv.PositionY == person.PositionY )
                {
                    if (person is Medborgare && ((Medborgare)person).Tillhorigheter.Count != 0 )
                    {

                        int index = Random.Shared.Next(0, ((Medborgare)person).Tillhorigheter.Count -1);
                        
                        ((Tjuv)tjuv).Stoldgods.Add(((Medborgare)person).Tillhorigheter[index]);

                        ((Medborgare)person).Tillhorigheter.RemoveAt(index);

                        string status = "Tjuv rånar medborgare: " + tjuv.PositionX + ", " + tjuv.PositionY + "\n";    
                        
                        Helpers.WriteStatus(status);
                    }
                }

            }

            return persons;

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
