using MazmorraLINQ.Entidades;
using MazmorraLINQ.Nucleo.Menus;
using MazmorraLINQ.Nucleo.SistemasCombates.Calculos;
using MazmorraLINQ.Nucleo.SistemasCombates.Menus;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MazmorraLINQ.Nucleo.SistemasCombates.Turnos
{
    public static class TurnoJugador
    {
        public static bool Ejecutar(Jugador jugador, Enemigo enemigo)
        {
            while (true)
            {
                Console.WriteLine("\nTu turno:");
                Console.WriteLine("1. Atacar");
                Console.WriteLine("2. Elegir poción");
                Console.WriteLine("3. Usar ceniza de guerra");
                Console.WriteLine("4. Equipamiento");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        int daño = CalcDaños.CalcularDañoJugador(jugador);
                        enemigo.Vida -= daño;

                        //Evitamos numeros negativos
                        enemigo.Vida = Math.Max(0, enemigo.Vida);

                        Console.WriteLine($"Atacas e infliges {daño}. Vida del enemigo: {enemigo.Vida}");
                        return true;
                    
                    case "2":
                        bool usada = MenuPociones.Mostrar(jugador);

                        if (usada) 
                            return true;
                        
                        break;
                    case "3":
                        bool usado = MenuCenizas.Mostrar(jugador, enemigo);
                        
                        if (usado)
                            return true;
                        
                        break;
                    
                    case "4":
                        MenuEquipamiento.Mostrar(jugador);
                        break;
                    
                    default:
                        Console.WriteLine("Opción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}