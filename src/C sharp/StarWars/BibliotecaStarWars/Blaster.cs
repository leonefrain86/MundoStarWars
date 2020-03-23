using System;

namespace BibliotecaStarWars
{
    public class Blaster
    {
        public string nombre {get;}
        public int alcance {get; set;}
        
        public Blaster()
        {
            
        }

        public Blaster(int alcance)
        {
            this.nombre = "Blaster";
            this.alcance = alcance;
        }
    }
}