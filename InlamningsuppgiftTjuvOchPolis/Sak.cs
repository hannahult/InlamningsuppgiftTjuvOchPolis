using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningsuppgiftTjuvOchPolis
{
    internal class Sak
    {
        
        public string Type { get; set; }

        public Sak(string type)
        {
            Type = type;
        }
    }
}
