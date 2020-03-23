using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaStarWars
{
    public class Guerrero : Personaje
    {
        public ArmaDePersonaje armaMax {get; set;} 
        public int midicloriano {get; set;}
        public double fuerza {get; set;}

        public Guerrero()
        {
            
        }

        public Guerrero(int id, string tipoPersonaje, int midicloriano, int vida, string faccion, double fuerza) :
             base(id, tipoPersonaje, 0, vida, faccion)
        {
            this.midicloriano = midicloriano;
            this.fuerza = fuerza;
            armaMax = new ArmaDePersonaje("null", 0);
        }
        

        public override void alzarSableLaser(SableLaser sableLaser)
        {
            if (sableLaser.hojas == 2)
                armas.Add(new ArmaDePersonaje("SableLaser", midicloriano));
            else
                armas.Add(new ArmaDePersonaje("SableLaser", midicloriano/2));

            this.actualizarValores();
        }

        public override void alzarBlaster(Blaster blaster)
        {
            armas.Add(new ArmaDePersonaje("Blaster", blaster.alcance));
            this.actualizarValores();
        }

        public void actualizarValores()
        {
            poderDeAtaque = armas.Sum(x => x.pAtqOtorga) + midicloriano;
            this.armaMax = armas.Find(x => x.pAtqOtorga == armas.Max(y => y.pAtqOtorga));
        }

        public void cambiarDeFaccion()
        {
            if(this.faccion == "Alianza Revelde")
            {
                faccion = "Imperio";
            }
            else
            {
                faccion = "Alianza Revelde";
            }
        
            Console.WriteLine("Cambio realizado con exito");
        }

        public void informeGuerrero()
        {
            Console.WriteLine($"id: {id}");
            Console.WriteLine($"fuerza: {fuerza}");
            Console.WriteLine($"tipoPersonaje: {tipoPersonaje}");
            Console.WriteLine($"vida: {vida}");
            Console.WriteLine($"poder de Ataque: {poderDeAtaque}");
            Console.WriteLine($"faccion: {faccion}");
            Console.WriteLine($"armas: {armas.Count()}");
            Console.WriteLine($"armaMax nombre: {armaMax.nombre}");
            Console.WriteLine($"armaMax Poder Otorgado: {armaMax.pAtqOtorga}");
        }

        public Guerrero robarArma(List<Guerrero> guerrerosFV, List<Guerrero> guerrerosDV)
        {
            bool comprobador = false;
            var unGuerrero = new Guerrero();
            do
            {
                Console.WriteLine("Guerreros fuera del vehiculo: ");
                foreach (var guerreroFV in guerrerosFV.OrderBy(x => x.id))
                {
                    Console.WriteLine($"id: {guerreroFV.id} fuerza:{guerreroFV.fuerza} faccion:{guerreroFV.faccion}  armaMax: {guerreroFV.armaMax.nombre} pAtqOtorga: {guerreroFV.armaMax.pAtqOtorga}"); 
                }

                Console.WriteLine("Guerreros dentro del vehiculo");
                foreach (var guerreroDV in guerrerosDV.OrderBy(x => x.id))
                {
                    Console.WriteLine($"id: {guerreroDV.id} fuerza:{guerreroDV.fuerza} faccion:{guerreroDV.faccion}  armaMax: {guerreroDV.armaMax.nombre} pAtqOtorga: {guerreroDV.armaMax.pAtqOtorga}"); 
                }
            
                Console.WriteLine("Ingrese el id del guerrero a quien la va robar el arma: ");
                int auxID = Convert.ToInt32(Console.ReadLine());

                if (guerrerosFV.Exists(x => x.id == auxID && x.faccion != this.faccion && x.fuerza < this.fuerza && x.armas.Count() > 0 && this.id != auxID) )
                {
                    comprobador = true;
                    unGuerrero = this.traspasoDeArna(guerrerosFV.First(x => x.id == auxID));
                    unGuerrero.actualizarValores();
                }
                else
                {
                    if (guerrerosDV.Exists(x => x.id == auxID && x.faccion != this.faccion && x.fuerza < this.fuerza && x.armas.Count() > 0 && this.id != auxID))
                    {
                        comprobador = true;
                        unGuerrero = this.traspasoDeArna(guerrerosDV.First(x => x.id == auxID));
                        unGuerrero.actualizarValores();
                    }
                    else
                    {
                        comprobador = false;
                        Console.WriteLine("El guerrero no cumple con los requisitos para que lo roben");
                    }
                }   
                
            } while (comprobador != true);

            return unGuerrero;
        }

        private Guerrero traspasoDeArna(Guerrero guerrero)
        {
            
            int auxC = 1;
            do
            {
                foreach (var armaR in guerrero.armas)
                {
                    Console.WriteLine($"{auxC++}- nombre: {armaR.nombre} poder: {armaR.pAtqOtorga}");
                }
                Console.WriteLine("Que arma desea robar: ");
                auxC = Convert.ToInt32(Console.ReadLine());

                if (auxC > 0 && auxC <= guerrero.armas.Count())
                {
                    var arma = guerrero.armas[auxC-1];
                    guerrero.armas.Remove(guerrero.armas[auxC-1]);
                    // foreach (var armaR in guerrero.armas)
                    // {
                    //     Console.WriteLine($"{auxC++}- nombre: {armaR.nombre} poder: {armaR.pAtqOtorga}");
                    // }
                    if (arma.nombre == "SableLaser")
                    {
                        var auxSL = new SableLaser();
                        if (arma.pAtqOtorga == guerrero.midicloriano)
                        {
                            auxSL = new SableLaser(2);
                            this.alzarSableLaser(auxSL);
                        }
                        else
                        {
                            auxSL = new SableLaser(1);
                            this.alzarSableLaser(auxSL);
                        }
                    }
                    else
                    {
                        var auxBL = new Blaster();
                        auxBL = new Blaster(arma.pAtqOtorga);
                        this.alzarBlaster(auxBL);
                    }
                }
                else
                {
                    Console.WriteLine("El arma no existe");
                } 
            } while (auxC < 0 && auxC > guerrero.armas.Count());

            return guerrero;   
        }
    }
}