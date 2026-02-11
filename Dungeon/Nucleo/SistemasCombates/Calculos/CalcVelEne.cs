using MazmorraLINQ.Entidades;

namespace MazmorraLINQ.Nucleo.SistemasCombates.Calculos
{
    public static class CalcVelEne
    {
        public static int CalcularVelocidadEnemigo( Enemigo enemigo)
        {
            return enemigo.Velocidad;
        }
    }
}