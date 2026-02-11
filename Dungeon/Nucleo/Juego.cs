using MazmorraLINQ.Entidades;
using MazmorraLINQ.Datos;
using MazmorraLINQ.Nucleo.SistemasCombates;
using MazmorraLINQ.Nucleo.SistemaInventario;

namespace MazmorraLINQ.Nucleo;

public class Juego
{
    private Jugador jugador;
    private List<Sala> mazmorra;

    public void Iniciar()
    {
        jugador = new Jugador();
        mazmorra = GeneradorMazmorra.GenerarMazmorra();

        Console.WriteLine("=== MAZMORRA LINQ ===");

        foreach (var sala in mazmorra)
        {
            Console.WriteLine($"\n===== SALA {sala.Id} =====");

            MostrarEstadoJugador();
            MostrarContenidoSala(sala);

            // Permitir recoger objetos del suelo
            foreach (var objeto in sala.Objetos)
            {
                bool respuestaValida = false;

                while (!respuestaValida)
                {
                    Console.WriteLine($"\n¿Quieres recoger el objeto {objeto.Nombre} ({objeto.Tipo}, Rareza: {objeto.Rareza})? (s/n)");
                    string respuesta = Console.ReadLine()?.Trim().ToLower();

                    if (respuesta == "s")
                    {
                        InventarioJugador.RecogerObjeto(jugador, objeto);
                        respuestaValida = true;
                    }
                    else if (respuesta == "n")
                    {
                        Console.WriteLine($"Ignoras el objeto {objeto.Nombre}.");
                        respuestaValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Opción incorrecta, elige 's' o 'n'.");
                    }
                }
            }


            // Combate contra enemigos
            foreach (var enemigo in sala.Enemigos)
            {
                Console.WriteLine($"\nEnemigo: {enemigo.Nombre} (Nivel {enemigo.Nivel}, Vida: {enemigo.Vida}, Ataque: {enemigo.Ataque})");

                bool vivo = SistemaCombate.Combatir(jugador, enemigo);

                if (!vivo)
                {
                    Console.WriteLine("\nHas muerto.");
                    return;
                }

                jugador.EnemigosDerrotados++;

                // Subida de nivel
                if (jugador.EnemigosDerrotados % 3 == 0)
                {
                    jugador.Nivel++;
                    jugador.AtaqueBase++;
                    
                    jugador.VidaMaxima += 30;
                    jugador.Vida = jugador.VidaMaxima;

                    Console.WriteLine($"¡Subes a nivel {jugador.Nivel}! Ataque base ahora: {jugador.AtaqueBase}! Vida máxima ahora: {jugador.VidaMaxima}");
                }

                // Botín del enemigo
                var botin = SistemaBotin.GenerarBotin();
                Console.WriteLine($"\nEl enemigo dejó un objeto: {botin.Nombre} ({botin.Tipo}, Rareza: {botin.Rareza})");
                bool respuestaValida = false;

                while (!respuestaValida)
                {
                    Console.WriteLine("¿Quieres recogerlo? (s/n)");
                    string recoger = Console.ReadLine()?.Trim().ToLower();

                    if (recoger == "s")
                    {
                        jugador.Inventario.Add(botin);
                        Console.WriteLine($"Has recogido {botin.Nombre}.");
                        respuestaValida = true;
                    }
                    else if (recoger == "n")
                    {
                        Console.WriteLine($"Ignoras el objeto {botin.Nombre}.");
                        respuestaValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Opción incorrecta, elige 's' o 'n'.");
                    }
                }

            }
        }

        Console.WriteLine("\n¡Has completado la mazmorra!");
        MostrarEstadoJugador();
    }

    private void MostrarEstadoJugador()
    {
        Console.WriteLine($"\nEstado del jugador:");
        Console.WriteLine($"Vida: {jugador.Vida}");
        Console.WriteLine($"Ataque base: {jugador.AtaqueBase}");
        Console.WriteLine($"Defensa: {jugador.Defensa}");
        Console.WriteLine($"Velocidad: {jugador.Velocidad}");
        Console.WriteLine($"Nivel: {jugador.Nivel}");
        
        Console.WriteLine("\n=== Equipamiento ===");
        
        if (jugador.ArmaEquipada != null)
            Console.WriteLine($"Arma equipada: {jugador.ArmaEquipada.Nombre} (+{jugador.ArmaEquipada.Valor} daño)");
        else
            Console.WriteLine("Arma equipada: Ninguna");
            
        if (jugador.ArmaduraEquipada != null)
            Console.WriteLine($"Armadura equipada: {jugador.ArmaduraEquipada.Nombre} (+{jugador.ArmaduraEquipada.Valor * 4} defensa)");
        else
            Console.WriteLine("Armadura equipada: Ninguna");

        if (jugador.BotasEquipadas != null)
            Console.WriteLine($"Botas equipadas: {jugador.BotasEquipadas.Nombre} (+{jugador.BotasEquipadas.Valor} velocidad)");
        else
            Console.WriteLine("Botas equipadas: Ninguna");
        
        Console.WriteLine();
    }
    private void MostrarContenidoSala(Sala sala)
    {
        Console.WriteLine("\nObjetos en el suelo:");
        if (sala.Objetos.Any())
        {
            //Cambio de bucle por LINQ
            sala.Objetos
                .ToList()
                .ForEach(obj =>
                {
                    string texto = obj.Tipo switch
                    {
                        "Defensa" => $"- {obj.Nombre} (+{obj.Valor} defensa, Rareza: {obj.Rareza})",
                        "Arma" => $"- {obj.Nombre} (+{obj.Valor} daño, Rareza: {obj.Rareza})",
                        "Velocidad" => $"- {obj.Nombre} (+{obj.Valor} velocidad, Rareza: {obj.Rareza})",
                        "Pocion" => $"- {obj.Nombre} (+{obj.Valor} vida, Rareza: {obj.Rareza})",
                        _ => $"- {obj.Nombre} ({obj.Tipo}, Rareza: {obj.Rareza})"
                    };

                    Console.WriteLine(texto);
                });
        }
        else
        {
            Console.WriteLine("No hay objetos en esta sala.");
        }

        Console.WriteLine("\nEnemigos en la sala:");
        
        //Cambio de bucle por LINQ
        sala.Enemigos
            .ToList()
            .ForEach(e =>
                Console.WriteLine($"- {e.Nombre} (Nivel {e.Nivel})")
            );
    }
}
