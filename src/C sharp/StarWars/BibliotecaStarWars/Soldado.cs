using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaStarWars
{
    public class Soldado : Personaje
    {
        public string nombre {get; set;}

        public Soldado(int id, string tipoPersonaje , string nombre, int vida, string faccion) :
             base(id, tipoPersonaje, 0, vida, faccion)
        {
            this.nombre = nombre;
        }

        public override void alzarSableLaser(SableLaser sableLaser)
        {
            armas.Add(new ArmaDePersonaje(sableLaser.nombre, sableLaser.hojas * 10));
            poderDeAtaque = armas.Sum(x => x.pAtqOtorga);
        }

        public override void alzarBlaster(Blaster blaster)
        {
            armas.Add(new ArmaDePersonaje("Blaster", blaster.alcance));
            poderDeAtaque = armas.Sum(x => x.pAtqOtorga);
        }
        public void informeSoldado()
        {
            Console.WriteLine($"id: {id}");
            Console.WriteLine($"nombre: {nombre}");
            Console.WriteLine($"tipoPersonaje: {tipoPersonaje}");
            Console.WriteLine($"vida: {vida}");
            Console.WriteLine($"poder de Ataque: {poderDeAtaque}");
            Console.WriteLine($"faccion: {faccion}");
            Console.WriteLine($"armas: {armas.Count()}");
        }
    }
}