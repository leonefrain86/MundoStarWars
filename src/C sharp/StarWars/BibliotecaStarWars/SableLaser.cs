using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaStarWars
{
    public class SableLaser
    {
        public string nombre {get;}
        public int hojas {get; set;}

        public SableLaser()
        {
            
        }

        public SableLaser(int hojas)
        {
            this.nombre = "Sable Laser";

            if (hojas <= 2 && hojas > 0)
            this.hojas = hojas;
            else
            throw new Exception("Solo pude ser de 1 o 2");

        }
    }
}