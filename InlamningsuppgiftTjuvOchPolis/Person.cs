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

    class Polis : Person
    {
        public List<Sak> Beslagtaget { get; set; }

        public Polis():base()
        {          
            //skapar en tom lista för beslagtagna saker

            List<Sak> beslagtaget = new List<Sak>();

            Beslagtaget = beslagtaget;
        }
     
        //metod för mötet mellan polis och en person
        public static int Meet(Person polis, List<Person> persons, int antalArrested)
        {
            foreach (Person person in persons)
            {
                //om de har samma position och möts
                if (polis.PositionX == person.PositionX && polis.PositionY == person.PositionY)
                {
                    //om den polisen möter är en tjuv
                    if (person is Tjuv && ((Tjuv)person).Stoldgods.Count!=0)
                    {
                        //om tjuven har stöldgods
                        for (int i = 0; i < ((Tjuv)person).Stoldgods.Count; i++)                        
                        {                           
                            //polisen tar stöldgodset
                            ((Polis)polis).Beslagtaget.Add(((Tjuv)person).Stoldgods[i]);
                            ((Tjuv)person).Stoldgods.RemoveAt(i);

                            //antal arresterade ökar
                            antalArrested++;

                            //skriver ut i konsolen
                            

                            Console.SetCursorPosition(0, 26);
                            Console.WriteLine("Polis beslagtar tjuvs stöldgods: ");
                            foreach (Sak sak in ((Polis)polis).Beslagtaget)
                            {
                                Console.Write(sak.Type + ", ");
                            }
                            Thread.Sleep(2000);
                        } 
                    }
                }

            }
            return antalArrested;
        }
    }

    class Tjuv : Person
    {
        public List<Sak> Stoldgods { get; set; }

        public Tjuv():base()
        {      
            //skapar en tom lista med stöldgods

            List<Sak> stoldgods = new List<Sak>();
            
            Stoldgods = stoldgods;
        }
        
        //metod för mötet mellan tjuv och person
        public static int Meet(Person tjuv, List<Person> persons, int antalRobbed)
        {            
            
            foreach (Person person in persons)
            {
                //om de har samma position och möts
                if (tjuv.PositionX == person.PositionX && tjuv.PositionY == person.PositionY)
                {
                    //om personen som möter tjuven är medborgare
                    if (person is Medborgare && ((Medborgare)person).Tillhorigheter.Count != 0)
                    {
                        //slumpmässigt tal som avgör vilken av medborgarens saker som ska bli stulen
                        int index = Random.Shared.Next(0, ((Medborgare)person).Tillhorigheter.Count);

                        //slumpmässiga saken läggs till på tjuvens lista med stöldgods och tas bort från medborgarens lista
                        ((Tjuv)tjuv).Stoldgods.Add(((Medborgare)person).Tillhorigheter[index]);

                        //skrivs ut i konsolen 
                        Console.SetCursorPosition(0, 26);
                        Console.WriteLine("Tjuv rånar medborgare, han tog " + ((Medborgare)person).Tillhorigheter[index].Type + "\n");
                        Thread.Sleep(2000);

                        ((Medborgare)person).Tillhorigheter.RemoveAt(index);

                        //antal rånade medborgare ökar
                        antalRobbed++;
                    }
                }
            }

            return antalRobbed;

        }

    }
    class Medborgare : Person
    {
        public List<Sak> Tillhorigheter { get; set; }

        public Medborgare():base()
        {          
            //skapar en lista med medborgarens tillhörigheter och lägger till dem
            List <Sak> tillhorigheter = new List<Sak>();

            tillhorigheter.Add(new Sak("nycklar"));
            tillhorigheter.Add(new Sak("mobil"));
            tillhorigheter.Add(new Sak("plånbok"));
            tillhorigheter.Add(new Sak("klocka"));

            Tillhorigheter = tillhorigheter;

        }
    }
}
