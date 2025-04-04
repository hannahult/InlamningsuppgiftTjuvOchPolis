using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningsuppgiftTjuvOchPolis
{
    internal class Possesion
    {
        //skapar saker som kommer att erhållas som tillhörigheter, stöldgods och beslagtaget hos personer
        public string Type { get; set; }

        public Possesion(string type)
        {
            Type = type;
        }
    }
}
