using MazmorraLINQ.Entidades;

namespace MazmorraLINQ.Nucleo.SistemasCombates.Calculos
{
    public static class CalcVelJug
    {
        public static int CalcularVelocidadJugador(Jugador jugador)
        {
            int bonusBotas = 0;

            if(jugador.BotasEquipadas != null && jugador.BotasEquipadas.Tipo == "Velocidad")
            {
                bonusBotas = jugador.BotasEquipadas.Valor;
            }

            return jugador.Velocidad + bonusBotas;
        }
    }
}