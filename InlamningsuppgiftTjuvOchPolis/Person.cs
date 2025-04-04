using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
            //skapar en slumpmässig position och riktning för varje person

            PositionX = Random.Shared.Next(1, 101);
            PositionY = Random.Shared.Next(1, 26);

            DirectionX = Random.Shared.Next(-1, 2);
            DirectionY = Random.Shared.Next(-1, 2);

        }

        //metod för att förflytta varje person
        public static List <Person> Move( List<Person>  persons)
        {

            for (int i = 0; i < persons.Count; i++)
            {
                //nya positionen
                persons[i].PositionX += persons[i].DirectionX;
                persons[i].PositionY += persons[i].DirectionY;

                //villkor för ifall personen hamnar utanför "staden" så att personen kommer in igen på andra sidan
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

    class Police : Person
    {
        public List<Possesion> Confiscated { get; set; }

        public Police():base()
        {          
            //skapar en tom lista för beslagtagna saker

            List<Possesion> confistaced = new List<Possesion>();

            Confiscated = confistaced;
        }
     
        //metod för mötet mellan polis och en person
        public static int Meet(Person police, List<Person> persons, int numberOfArrested)
        {
            foreach (Person person in persons)
            {
                //om de har samma position och möts
                if (police.PositionX == person.PositionX && police.PositionY == person.PositionY)
                {
                    //om den polisen möter är en tjuv
                    if (person is Thief && ((Thief)person).StolenGods.Count!=0)
                    {
                        //om tjuven har stöldgods
                        for (int i = 0; i < ((Thief)person).StolenGods.Count; i++)                        
                        {                           
                            //polisen tar stöldgodset
                            ((Police)police).Confiscated.Add(((Thief)person).StolenGods[i]);
                            ((Thief)person).StolenGods.RemoveAt(i);

                            //antal arresterade ökar
                            numberOfArrested++;

                            //skriver ut i konsolen
                            

                            Console.SetCursorPosition(0, 26);
                            Console.WriteLine("Polis beslagtar tjuvs stöldgods: ");
                            foreach (Possesion sak in ((Police)police).Confiscated)
                            {
                                Console.Write(sak.Type + ", ");
                            }
                            Thread.Sleep(2000);
                        } 
                    }
                }

            }
            return numberOfArrested;
        }
    }

    class Thief : Person
    {
        public List<Possesion> StolenGods { get; set; }

        public Thief():base()
        {      
            //skapar en tom lista med stöldgods

            List<Possesion> stolenGods = new List<Possesion>();
            
            StolenGods = stolenGods;
        }
        
        //metod för mötet mellan tjuv och person
        public static int Meet(Person thief, List<Person> persons, int numberOfRobbed)
        {            
            
            foreach (Person person in persons)
            {
                //om de har samma position och möts
                if (thief.PositionX == person.PositionX && thief.PositionY == person.PositionY)
                {
                    //om personen som möter tjuven är medborgare
                    if (person is Citizen && ((Citizen)person).Possesions.Count != 0)
                    {
                        //slumpmässigt tal som avgör vilken av medborgarens saker som ska bli stulen
                        int index = Random.Shared.Next(0, ((Citizen)person).Possesions.Count);

                        //slumpmässiga saken läggs till på tjuvens lista med stöldgods och tas bort från medborgarens lista
                        ((Thief)thief).StolenGods.Add(((Citizen)person).Possesions[index]);

                        Console.SetCursorPosition(0, 26);
                        Console.WriteLine("Tjuv rånar medborgare, han tog " + ((Citizen)person).Possesions[index].Type + "\n");
                        Thread.Sleep(2000);

                        ((Citizen)person).Possesions.RemoveAt(index);

                        //antal rånade medborgare ökar
                        numberOfRobbed++;
                    }
                }
            }

            return numberOfRobbed;

        }

    }
    class Citizen : Person
    {
        public List<Possesion> Possesions { get; set; }

        public Citizen():base()
        {          
            //skapar en lista med medborgarens tillhörigheter och lägger till dem
            List <Possesion> possesions = new List<Possesion>();

            possesions.Add(new Possesion("nycklar"));
            possesions.Add(new Possesion("mobil"));
            possesions.Add(new Possesion("plånbok"));
            possesions.Add(new Possesion("klocka"));

            Possesions = possesions;

        }
    }
}
