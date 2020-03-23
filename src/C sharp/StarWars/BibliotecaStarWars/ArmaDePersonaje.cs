using System;

namespace BibliotecaStarWars
{
    public class ArmaDePersonaje
    {
        public string nombre {get; set;}
        public int pAtqOtorga {get; set;}

        public ArmaDePersonaje(string nombre, int pAtqOtorga)
        {
            this.nombre = nombre;
            this.pAtqOtorga = pAtqOtorga;
        }
    }
}