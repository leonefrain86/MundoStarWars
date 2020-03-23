using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaStarWars
{
    public class Vehiculo
    {
        public string nombreM {get; set;}
        public int capacidad {get; set;}
        public double velocidad {get; set;}
        public List<Soldado> soldados {get; set;}
        public List<Guerrero> guerreros {get; set;}
        public bool mismaFaccion {get; set;}
        public int totalArmas {get; set;}

        public Vehiculo(string nombreM, int capacidad, double velocidad)
        {
            this.soldados = new List<Soldado>();
            this.guerreros = new List<Guerrero>();

            this.nombreM = nombreM;
            this.capacidad = capacidad;
            this.velocidad = velocidad;
            this.totalArmas = 0;
            this.mismaFaccion = false;
        }

        public bool comprobarMismaFaccion()
        {
            if(soldados.All(x => x.faccion == "Alianza Rebelde" || x.faccion == "Imperio"))
            {
                 if(guerreros.All(x => x.faccion == "Alianza Rebelde" || x.faccion == "Imperio"))
                 {
                     if(soldados[0].faccion == guerreros[0].faccion)
                     {
                         return true;
                     }
                 }       
            }
            return false;   
        }

        public int comprobarTotalArmas ()
        {
            int aux = 0;
            foreach (var soldado in soldados)
            {
                aux = aux + soldado.armas.Count();
            }
            foreach (var guerrero in guerreros)
            {
                aux = aux + guerrero.armas.Count();
            }
            return aux;
        }

        private void comprobadorDeCapacidad()
        {
            if(soldados.Count() + guerreros.Count() >= capacidad )
                throw new Exception ("Se ha alcanzado la capacidad maxima del vehiculo");
        }

        public void subirSoldado(List<Soldado> soldadosF)
        {
            do
            {
                this.comprobadorDeCapacidad();
                Console.WriteLine("Subida de soldados: ");
                this.mostrarSoldados(soldadosF);
                Console.Write("Elija soldado a subir por id: ");
                int auxA = Convert.ToInt32(Console.ReadLine());
                if(this.soldados.Exists(x => x.id == auxA) != true) 
                {
                    this.soldados.Add(soldadosF.Find(x => x.id == auxA));
                    soldadosF.Remove(soldadosF.Find(x => x.id == auxA));
                    Console.WriteLine("¡El personaje ha subido al vehiculo con exito!");
                } 
                else
                {
                    Console.WriteLine("¡El personaje ya ha subido al vehiculo o no existe!");
                }

                Console.WriteLine("Quiere continuar s/n: ");    
            } while (Console.ReadLine() == "s");
        }  

        public void subirGuerrero(List<Guerrero> guerrerosF)
        {
            do
            {
                this.comprobadorDeCapacidad();
                Console.WriteLine("Subida de guerrros: ");
                this.mostrarGuerreros(guerrerosF);
                Console.WriteLine("Elija guerrero a subir por id: ");
                int auxA = Convert.ToInt32(Console.ReadLine());
                
                if(this.guerreros.Exists(x => x.id == auxA) != true) 
                {
                    this.guerreros.Add(guerrerosF.Find(x => x.id == auxA));
                    guerrerosF.Remove(guerrerosF.Find(x => x.id == auxA));
                    Console.WriteLine("¡El personaje a subido son exito al vehiculo!");
                }  
                else
                {
                    Console.WriteLine("¡El personaje ay ha subido al vehiculo o no existe!");
                }

                Console.WriteLine("Quiere continuar s/n: ");        
            } while (Console.ReadLine() == "s");
        }

        public void subirPersonajes(List<Soldado> soldados, List<Guerrero> guerreros)
        {
            
            this.subirSoldado(soldados);
            
            this.subirGuerrero(guerreros);
            this.totalArmas = this.comprobarTotalArmas();
            this.mismaFaccion = this.comprobarMismaFaccion();
        }

        public void mostrarSoldados(List<Soldado> soldados)
        {
            foreach (var soldado in soldados)
            {
                Console.WriteLine($"id: {soldado.id} tipo:{soldado.tipoPersonaje} nombre:{soldado.nombre} vida:{soldado.vida} faccion: {soldado.faccion} armas: {soldado.armas.Count()}"); 
            }
        }

        public void mostrarGuerreros(List<Guerrero> guerrerosA)
        {
            foreach (var guerrero in guerrerosA)
            {
                Console.WriteLine($"id: {guerrero.id} tipo:{guerrero.tipoPersonaje} fuerza:{guerrero.fuerza} vida:{guerrero.vida} faccion:{guerrero.faccion} midicloriano:{guerrero.midicloriano} armaMax: {guerrero.armaMax.nombre} pAtqOtorga: {guerrero.armaMax.pAtqOtorga}"); 
            }
        }

        public List<Guerrero> bajarGuerreros()
        {
            var returnGS = new List<Guerrero>();
            do
            {
                this.mostrarGuerreros(this.guerreros);
                Console.Write("Elija personaje a bajar del vehiculo por id: ");
                int auxID = Convert.ToInt32(Console.ReadLine()); 
                if(this.guerreros.Exists(x => x.id == auxID))
                {
                    returnGS.Add(this.guerreros.First(x => x.id == auxID));
                    this.guerreros.Remove(this.guerreros.First(x => x.id == auxID));
                    Console.WriteLine("¡El personaje a bajado con exito del vehiculo!");
                }
                else
                {
                    Console.WriteLine("¡El personaje no esta en el vehiculo o no existe!");
                    //throw new Exception("El personaje no esta en el vehiculo o no existe");
                }
                Console.Write("Quiere continuar s/n: ");
            } while (Console.ReadLine() == "s");
            this.totalArmas = this.comprobarTotalArmas();
            this.mismaFaccion = this.comprobarMismaFaccion();
            return returnGS;
        }

        public List<Soldado> bajarSoldados()
        {
            var returnSS = new List<Soldado>();
            do
            {
                this.mostrarSoldados(this.soldados);
                Console.Write("Elija personaje a bajar del vehiculo por id: ");
                int auxID = Convert.ToInt32(Console.ReadLine()); 
                if(this.soldados.Exists(x => x.id == auxID))
                {
                    returnSS.Add(this.soldados.First(x => x.id == auxID));
                    this.soldados.Remove(this.soldados.First(x => x.id == auxID));
                    Console.WriteLine("¡El personaje a bajado con exito del vehiculo!");
                }
                else
                {
                    Console.WriteLine("¡El personaje no esta en el vehiculo o no existe!");
                    //throw new Exception("El personaje no esta en el vehiculo o no existe");
                }
                Console.Write("Quiere continuar s/n: ");
            } while (Console.ReadLine() == "s");

            this.totalArmas = this.comprobarTotalArmas();
            this.mismaFaccion = this.comprobarMismaFaccion();
            return returnSS;
        }

        public void Informe()
        {
            Console.WriteLine($"modelo: {nombreM}");
            Console.WriteLine($"capacidad: {capacidad}");
            Console.WriteLine($"personajes: {soldados.Count() + guerreros.Count()}");
            Console.WriteLine($"misma faccion: {mismaFaccion}");
            Console.WriteLine($"total de armas: {totalArmas}");
        }
    }
}