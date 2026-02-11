using MazmorraLINQ.Entidades;

namespace MazmorraLINQ.Nucleo.SistemaInventario
{
    public static class InventarioJugador
    {
        public static void RecogerObjeto(Jugador jugador, Objeto objeto)
        {
            switch (objeto.Tipo)
            {
                case "Arma":
                    if (jugador.ArmaEquipada == null)
                    {
                        jugador.ArmaEquipada = objeto;
                        Console.WriteLine($"Has equipado el arma: {objeto.Nombre}");        
                    }
                    else
                    {
                        jugador.Inventario.Add(objeto);
                        Console.WriteLine($"Has guardado {objeto.Nombre} en el inventario.");        
                    }
                    break;

                case "Defensa":
                    if (jugador.ArmaduraEquipada == null)
                    {
                        jugador.ArmaduraEquipada = objeto;
                        Console.WriteLine($"Has equipado la armadura: {objeto.Nombre}");
                    }
                    else
                    {
                        jugador.Inventario.Add(objeto);
                        Console.WriteLine($"Has guardado {objeto.Nombre} en el inventario.");
                    }
                    break;
                
                case "Velocidad":
                    if (jugador.BotasEquipadas == null)
                    {
                        jugador.BotasEquipadas = objeto;
                        Console.WriteLine($"Has equipado las botas: {objeto.Nombre}");
                    }
                    else
                    {
                        jugador.Inventario.Add(objeto);
                        Console.WriteLine($"Has guardado {objeto.Nombre} en el inventario.");
                    }
                    break;
                
                case "Pocion":
                    jugador.Inventario.Add(objeto);
                    Console.WriteLine($"Has guardado la poción: {objeto.Nombre}");
                    break;
                
                default:
                    jugador.Inventario.Add(objeto);
                    Console.WriteLine($"Has guardado {objeto.Nombre} en el inventario.");
                    break;
            }
        }
    }
}