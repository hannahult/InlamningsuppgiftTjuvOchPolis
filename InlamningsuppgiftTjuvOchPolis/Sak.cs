using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningsuppgiftTjuvOchPolis
{
    internal class Sak
    {
        //skapar saker som kommer att erhållas som tillhörigheter, stöldgods och beslagtaget hos personer
        public string Type { get; set; }

        public Sak(string type)
        {
            Type = type;
        }
    }
}
