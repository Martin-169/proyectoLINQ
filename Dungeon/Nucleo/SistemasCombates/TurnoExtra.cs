using MazmorraLINQ.Entidades;
using MazmorraLINQ.Nucleo.SistemasCombates.Calculos;
using MazmorraLINQ.Nucleo.SistemasCombates.Menus;

namespace MazmorraLINQ.Nucleo.SistemasCombates.Turnos
{
    public static class TurnoExtraJugador
    {
        public static void Ejecutar(Jugador jugador, Enemigo enemigo)
        {
            Console.WriteLine("\nTienes un turno extra!");

            TurnoJugador.Ejecutar(jugador, enemigo);
        }
    }
}