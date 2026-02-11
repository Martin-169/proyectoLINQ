using MazmorraLINQ.Entidades;

namespace MazmorraLINQ.Nucleo.SistemasCombates.Calculos
{
    public static class CalcDefJug
    {
        public static int CalcularDefensaJugador(Jugador jugador)
        {
            int bonusArmadura = 0;

            if(jugador.ArmaduraEquipada != null && jugador.ArmaduraEquipada.Tipo == "Defensa")
            {
                bonusArmadura = jugador.ArmaduraEquipada.Valor * 4;
            }

            return jugador.Defensa + bonusArmadura;
        }
    }
}