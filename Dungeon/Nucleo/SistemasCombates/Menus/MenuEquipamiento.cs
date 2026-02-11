using MazmorraLINQ.Entidades;
using MazmorraLINQ.Nucleo.SistemaInventario;

namespace MazmorraLINQ.Nucleo.Menus
{
    public static class MenuEquipamiento
    {
        public static void Mostrar(Jugador jugador)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== Menú de Equipamiento ===");
                Console.WriteLine("1. Cambiar arma");
                Console.WriteLine("2. Cambiar armadura");
                Console.WriteLine("3. Cambiar botas");
                Console.WriteLine("4. Volver");
                Console.WriteLine("Elige una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CambiarArma(jugador);
                        break;
                    
                    case "2":
                        CambiarArmadura(jugador);
                        break;
                    
                    case "3":
                        CambiarBotas(jugador);
                        break;
                    
                    case "4":
                        salir = true;
                        break;
                    
                    default:
                        Console.WriteLine("Opción no válida");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void CambiarArma(Jugador jugador)
        {
            Console.Clear();
            Console.WriteLine("=== Cambiar Arma ===");

            if(jugador.ArmaEquipada != null)
                Console.WriteLine($"Arma equipada actualmente: {jugador.ArmaEquipada.Nombre} (+{jugador.ArmaEquipada.Valor} daño)");
            else
                Console.WriteLine("Arma equipada actualmente: Ninguna");
            
            Console.WriteLine("\nArmas en el inventario:");

            var armas = jugador.Inventario
            .Where(o => o.Tipo == "Arma")
            .ToList();

            if (armas.Count == 0)
            {
                Console.WriteLine("No tienes armas en el inventario.");
                Thread.Sleep(1000);
                return;
            }

            //Cambio de bucle por LINQ
            armas
                .Select((a, i) => new { Arma = a, Index = i})
                .ToList()
                .ForEach(x =>
                    Console.WriteLine($"{x.Index + 1}. {x.Arma.Nombre} (+{x.Arma.Valor} daño)")
                );

            Console.WriteLine("\nElige un arma para equipar: ");
            if (!int.TryParse(Console.ReadLine(), out int opcion) || opcion < 1 || opcion > armas.Count)
            {
                Console.WriteLine("Opción no válida.");
                Console.ReadKey();
                return;
            }

            var nuevaArma = armas[opcion - 1];

            if(jugador.ArmaEquipada != null)
                jugador.Inventario.Add(jugador.ArmaEquipada);
            
            jugador.ArmaEquipada = nuevaArma;
            jugador.Inventario.Remove(nuevaArma);

            Console.WriteLine($"\nHas equipado: {nuevaArma.Nombre}");
            Thread.Sleep(1000);

            return;

        }

        private static void CambiarArmadura(Jugador jugador)
        {
            Console.Clear();
            Console.WriteLine("=== Cambiar Armadura ===");

            if(jugador.ArmaduraEquipada != null)
                Console.WriteLine($"Armadura equipada actualmente: {jugador.ArmaduraEquipada.Nombre} (+{jugador.ArmaduraEquipada.Valor * 4} defensa)");
            else
                Console.WriteLine("Armadura equipada actualmente: Ninguna");
            
            Console.WriteLine("\nArmaduras en el inventario:");

            var armaduras = jugador.Inventario
            .Where(o => o.Tipo == "Defensa")
            .ToList();

            if (armaduras.Count == 0)
            {
                Console.WriteLine("No tienes armaduras en el inventario.");
                Thread.Sleep(1000);
                return;
            }

            //Cambio de bucle por LINQ
            armaduras
                .Select((a, i) => new { Armadura = a, Index = i})
                .ToList()
                .ForEach(x =>
                    Console.WriteLine($"{x.Index + 1}. {x.Armadura.Nombre} (+{x.Armadura.Valor * 4} defensa)")
                );
            
            Console.WriteLine("\nElige una armadura para equipar: ");
            if (!int.TryParse(Console.ReadLine(), out int opcion) || opcion < 1 || opcion > armaduras.Count)
            {
                Console.WriteLine("Opción no válida.");
                Console.ReadKey();
                return;
            }

            var nuevaArmadura = armaduras[opcion - 1];

            if(jugador.ArmaduraEquipada != null)
                jugador.Inventario.Add(jugador.ArmaduraEquipada);
            
            jugador.ArmaduraEquipada = nuevaArmadura;
            jugador.Inventario.Remove(nuevaArmadura);

            Console.WriteLine($"\nHas equipado: {nuevaArmadura.Nombre}");
            Thread.Sleep(1000);

            return;
        }

        private static void CambiarBotas(Jugador jugador)
        {
            Console.Clear();
            Console.WriteLine("=== Cambiar Bota ===");

            if(jugador.BotasEquipadas != null)
                Console.WriteLine($"Bota equipada actualmente: {jugador.BotasEquipadas.Nombre} (+{jugador.BotasEquipadas.Valor} velocidad)");
            else
                Console.WriteLine("Bota equipada actualmente: Ninguna");
            
            Console.WriteLine("\nBotas en el inventario:");

            var botas = jugador.Inventario
            .Where(o => o.Tipo == "Velocidad")
            .ToList();

            if (botas.Count == 0)
            {
                Console.WriteLine("No tienes botas en el inventario.");
                Thread.Sleep(1000);
                return;
            }

            //Cambio de bucle por LINQ
            botas
                .Select((b, i) => new { Bota = b, Index = i})
                .ToList()
                .ForEach(x =>
                    Console.WriteLine($"{x.Index + 1}. {x.Bota.Nombre} (+{x.Bota.Valor} velocidad)")
                );

            Console.WriteLine("\nElige una bota para equipar: ");
            if (!int.TryParse(Console.ReadLine(), out int opcion) || opcion < 1 || opcion > botas.Count)
            {
                Console.WriteLine("Opción no válida.");
                Console.ReadKey();
                return;
            }

            var nuevaBota = botas[opcion - 1];

            if(jugador.BotasEquipadas != null)
                jugador.Inventario.Add(jugador.BotasEquipadas);
            
            jugador.BotasEquipadas = nuevaBota;
            jugador.Inventario.Remove(nuevaBota);

            Console.WriteLine($"\nHas equipado: {nuevaBota.Nombre}");
            Thread.Sleep(1000);

            return;
        }
    }
}