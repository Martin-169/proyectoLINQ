using MazmorraLINQ.Entidades;

namespace MazmorraLINQ.Nucleo.SistemasCombates.Menus
{
    public static class MenuPociones
    {
        public static bool Mostrar(Jugador jugador)
        {
            var pociones = jugador.Inventario
                .Where(o => o.Tipo == "Poción")
                .ToList();
            
            if (pociones.Count == 0)
            {
                Console.WriteLine("No tienes pociones.");
                return false;
            }

            while (true)
            {
                Console.WriteLine($"\nTus pociones (Vida actual: {jugador.Vida}/{jugador.VidaMaxima}):");

                //Cambio de bucle por LINQ
                pociones
                    .Select((p, i) => new { Pocion = p, Index = i})
                    .ToList()
                    .ForEach(x =>
                        Console.WriteLine($"{x.Index + 1}. {x.Pocion.Nombre} (+{x.Pocion.Valor} vida)")
                    );

                Console.WriteLine("0. Volver  atrás");
                Console.WriteLine("\nElige una poción: ");

                string eleccion = Console.ReadLine();

                if (eleccion == "0")
                {
                    return false;
                }

                if (!int.TryParse(eleccion, out int indice) ||
                    indice < 1 || indice > pociones.Count)
                {
                    Console.WriteLine("Opción incorrecta.");
                    continue;
                }

                var pocion = pociones[indice - 1];

                if(jugador.Vida + pocion.Valor > jugador.VidaMaxima)
                {
                    Console.WriteLine("Vas a desperdiciar esta poción.");
                    continue;
                }

                jugador.Vida += pocion.Valor;
                jugador.Inventario.Remove(pocion);

                Console.WriteLine($"Usas {pocion.Nombre} y recuperas {pocion.Valor} de vida.");
                return true;
            }
        }
    }
}