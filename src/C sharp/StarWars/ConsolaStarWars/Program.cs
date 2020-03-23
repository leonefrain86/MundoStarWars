using System;
using BibliotecaStarWars;
using System.Collections.Generic;
using System.Linq;

namespace ConsolaStarWars
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos soldados y guerreros
            List<Soldado> soldados = new List<Soldado>{
                new Soldado(1, "soldado", "lyon1", 60, "Imperio"),
                new Soldado(2, "soldado", "lyon2", 60, "Alianza Revelde"),
                new Soldado(3, "soldado", "lyon3", 60, "Imperio"),
                new Soldado(4, "soldado", "lyon4", 60, "Imperio")    
            };
            List<Guerrero> guerreros = new List<Guerrero>{
                new Guerrero(1, "guerrero", 10, 100, "Alianza Revelde", 400.3),
                new Guerrero(2, "guerrero", 50, 110, "Alianza Revelde", 39.2),
                new Guerrero(3, "guerrero", 40, 90, "Alianza Revelde", 70.4),
                new Guerrero(4, "guerrero", 40, 90, "Alianza Revelde", 70.4)
            };

            //CREAMOS NUESTRO VEHICULO
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("Vehiculo creado: ");
            Vehiculo unVehiculo = new Vehiculo("HZX", 4, 1500);
            unVehiculo.Informe();

            //Creamos sables laser
            SableLaser sableLaserDos = new SableLaser(2);
            SableLaser sableLaserUno = new SableLaser(1);

            //Creamos balster
            Blaster blasterMn = new Blaster(40);
            Blaster blasterMy = new Blaster(70);

            //Creamos a nuestro personaje Soldado
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("Soldado creado: ");
            Soldado unSoldado = new Soldado(5,"soldado", "lyon0", 60, "Alianza Revelde");
            //El soldado alza armas
            Console.WriteLine("");
            unSoldado.alzarBlaster(blasterMy);
            unSoldado.alzarSableLaser(sableLaserUno);
            unSoldado.informeSoldado();


            //Creamos a nuestro personaje Guerrero
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("Guerrero creado: ");
            Guerrero unGuerrero = new Guerrero(5, "guerrero", 10, 100, "Imperio", 40.3);
            //El guerrero alza armas
            Console.WriteLine("");
            unGuerrero.alzarSableLaser(sableLaserDos);
            unGuerrero.alzarBlaster(blasterMn);
            unGuerrero.informeGuerrero();


            //CAMBIAR DE FACCION
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("Cambio de faccion del guerrero que creamos: ");
            Console.WriteLine("");
            unGuerrero.cambiarDeFaccion();
            unGuerrero.informeGuerrero();
            Console.WriteLine("---------------------------------------------------------------------------------------------------");


            //AÑADIMOS LOS PERSONAJES CREADOS A SUS LISTAS
            soldados.Add(unSoldado);
            guerreros.Add(unGuerrero);


            // ROBAR ARMA 

            //Creamos a nuestro guerrero para que sea robado
            Guerrero fulanitoGuerrero = new Guerrero(6, "guerrero", 10, 100, "Imperio", 40.3);
            fulanitoGuerrero.alzarSableLaser(sableLaserDos);
            fulanitoGuerrero.alzarBlaster(blasterMy);
            fulanitoGuerrero.alzarSableLaser(sableLaserUno);
            fulanitoGuerrero.alzarBlaster(blasterMn);

            //Subimos al guerrero que va ser robado en el vehiculo
            unVehiculo.guerreros.Add(fulanitoGuerrero);

            var guerreroRobado = new Guerrero();
            //Obtenemos el resultado del soldado robado apartir del ladron a partir del guerrero que lo robo
            guerreroRobado = guerreros[0].robarArma(guerreros, unVehiculo.guerreros);
            
            //Actualizamos Listas
            if(unVehiculo.guerreros.Exists(x => x.id == guerreroRobado.id) == true)
            {
                unVehiculo.guerreros[unVehiculo.guerreros.IndexOf(unVehiculo.guerreros.First(x => x.id == guerreroRobado.id))] = guerreroRobado;
            }
            else
            {
                guerreros[guerreros.IndexOf(guerreros.First(x => x.id == guerreroRobado.id))] = guerreroRobado;
            }
            
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine("Personajes en el vehiculo: ");
            unVehiculo.mostrarGuerreros(unVehiculo.guerreros);
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine("Personajes fuera del vehiculo: ");
            unVehiculo.mostrarGuerreros(guerreros);

            //SUBIDA Y BAJADA DE PERSONAJES

            //Creamos vehiculo
            
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine("VEHICULO:");
            unVehiculo.Informe();
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            unVehiculo.subirPersonajes(soldados, guerreros);
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            
            // Proceso para remover soldados que han subido al vehiculo
            foreach (var soldadoVehiculo in unVehiculo.soldados)
            {
                if(soldados.Exists(x => x.id == soldadoVehiculo.id) == true)
                {
                    soldados.Remove(soldados.First(x => x.id == soldadoVehiculo.id));
                }
            }

            // Proceso para remover guerreros que han subido al vehiculo
            foreach (var guerreroVehiculo in unVehiculo.guerreros)
            {
                if(guerreros.Exists(x => x.id == guerreroVehiculo.id) == true)
                {
                    guerreros.Remove(guerreros.First(x => x.id == guerreroVehiculo.id));
                }
            }
            
            //Bajar personajes del vehiculo
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine("Guerreros a bajar");
            var guerrerosBajados = unVehiculo.bajarGuerreros();
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            onsole.WriteLine("Soldados a bajar");
            var soldadosBajados = unVehiculo.bajarSoldados();

            //Añado a los soldados que fueron bajados
            foreach (var guerrero in guerrerosBajados)
            {
                guerreros.Add(guerrero);
            }
            foreach (var soldado in soldadosBajados)
            {
                soldados.Add(soldado);
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine("Personajes en el vehiculo: ");
            unVehiculo.mostrarSoldados(unVehiculo.soldados);
            unVehiculo.mostrarGuerreros(unVehiculo.guerreros);
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine("VEHICULO:");
            unVehiculo.Informe();
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine("Personajes fuera del vehiculo: ");
            unVehiculo.mostrarSoldados(soldados);
            unVehiculo.mostrarGuerreros(guerreros);
            Console.WriteLine("----------------------------------------------------------------------------------------------------");


        }
    }
}
