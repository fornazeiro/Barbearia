using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbearia.Entidades
{
    public class Calendario
    {
        public Calendario()
        {
            color = "red";
            backgroundColor = "yellow";
        }

        public string start { get; set; }
        public string title { get; set; }
        public string color { get; set; }
        public string backgroundColor { get; set; }
    }
}