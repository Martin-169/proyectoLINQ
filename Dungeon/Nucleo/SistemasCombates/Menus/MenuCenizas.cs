using MazmorraLINQ.Entidades;

namespace MazmorraLINQ.Nucleo.SistemasCombates.Menus
{
    public static class MenuCenizas
    {
        public static bool Mostrar(Jugador jugador, Enemigo enemigo)
        {
            var arma = jugador.ArmaEquipada as ArmaHabil;
            
            if (arma == null)
            {
                Console.WriteLine("No tienes un arma equipada");
                return false;
            }

            if(string.IsNullOrEmpty(arma.CenizaNombre))
            {
                Console.WriteLine("Tu arma equipada no tiene ceniza de guerra");
                return false;
            }

            jugador.CooldownsCenizas.TryGetValue(arma.Nombre, out int cdRestante);

            if(cdRestante > 0)
            {
                Console.WriteLine($"La ceniza no está lista. Faltan {cdRestante} turnos.");
                return false;
            }

            enemigo.Vida -= arma.CenizaDaño;

            enemigo.Vida = Math.Max(0, enemigo.Vida);

            Console.WriteLine($"Usas {arma.CenizaNombre} e infliges {arma.CenizaDaño} de daño.");
            Console.WriteLine($"Vida del enemigo: {enemigo.Vida}");

            jugador.CooldownsCenizas[arma.Nombre] = arma.CenizaCooldown;

            return true;
        }
    }
}