using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaStarWars
{
    public class Personaje
    {
        public int id {get; set;}
        public string tipoPersonaje {get; set;}
        public int vida {get; set;}
        public int poderDeAtaque {get; set;}
        public string faccion {get; set;}
        public List<ArmaDePersonaje> armas {get; set;}

        public Personaje()
        {
            
        }

        public Personaje(int id, string tipoPersonaje,int poderDeAtaque, int vida, string faccion)
        {
            this.id = id;
            this.faccion = faccion;
            this.vida = vida;
            this.tipoPersonaje = tipoPersonaje;
            this.armas = new List<ArmaDePersonaje>();
            this.poderDeAtaque = poderDeAtaque;
        }

        public virtual void alzarSableLaser(SableLaser sableLaser)
        {

        }

        public virtual void alzarBlaster(Blaster blaster)
        {
            
        }
    }
}
