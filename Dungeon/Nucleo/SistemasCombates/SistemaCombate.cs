using MazmorraLINQ.Entidades;
using MazmorraLINQ.Nucleo.SistemasCombates.Calculos;
using MazmorraLINQ.Nucleo.SistemasCombates.Turnos;

namespace MazmorraLINQ.Nucleo.SistemasCombates
{
    public static class SistemaCombate
    {
        public static bool Combatir(Jugador jugador, Enemigo enemigo)
        {
            Console.WriteLine($"\nCombate contra {enemigo.Nombre}!");
            Pausa();

            int velJugador = CalcVelJug.CalcularVelocidadJugador(jugador);
            int velEnemigo = CalcVelEne.CalcularVelocidadEnemigo(enemigo);

            bool turnoJugador = velJugador >= velEnemigo;

            while (jugador.Vida > 0 && enemigo.Vida > 0)
            {
                if (turnoJugador)
                {
                    TurnoJugador.Ejecutar(jugador, enemigo);

                    if (enemigo.Vida <= 0)
                    {
                        break;
                    }

                    if (velJugador >= velEnemigo * 2)
                    {
                        TurnoExtraJugador.Ejecutar(jugador, enemigo);

                        if(enemigo.Vida <= 0)
                        {
                            break;
                        }
                    }

                    //Evitar que si tienes mucha Vel ataques siempre tu
                    turnoJugador = false; 
                }
                else
                {
                    int daño = CalcDaños.CalcularDañoEnemigo(jugador, enemigo);
                    jugador.Vida -= daño;

                    //Evitamos numeros negativos
                    jugador.Vida = Math.Max(0, jugador.Vida);

                    Console.WriteLine($"{enemigo.Nombre} te golpea por {daño}. Tu vida: {jugador.Vida}");
                    Pausa();

                    //Evitar que si tienes mucha Vel ataques siempre tu
                    turnoJugador = true;
                }

                //Cambio de bucle por LINQ
                jugador.CooldownsCenizas.Keys
                    .Where(k => jugador.CooldownsCenizas[k] > 0)
                    .ToList()
                    .ForEach(k => jugador.CooldownsCenizas[k]--);

            }
            return jugador.Vida > 0;
        }

        private static void Pausa()
        {
            Thread.Sleep(1500);
        }
    }
}