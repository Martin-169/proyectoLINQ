using MazmorraLINQ.Entidades;

namespace MazmorraLINQ.Nucleo.SistemasCombates.Calculos
{
    public static class CalcDaños
    {
        public static int CalcularDañoJugador(Jugador jugador)
        {
            var arma = jugador.ArmaEquipada as ArmaHabil;

            double bonusArma = 0;

            if(arma != null)
            {
                bonusArma = arma.Valor * 0.70;
            }

            return (int)(jugador.AtaqueBase + bonusArma);

        }

        public static int CalcularDañoEnemigo(Jugador jugador, Enemigo enemigo)
        {
            int defensaTotal = CalcDefJug.CalcularDefensaJugador(jugador);
            double reduccion = defensaTotal * 0.07;
            reduccion = Math.Clamp(reduccion, 0, 0.85);

            int dañoFinal = (int)(enemigo.Ataque * (1 - reduccion));
            return Math.Max(1, dañoFinal);
        }
    }
}
