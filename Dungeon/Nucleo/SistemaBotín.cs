using MazmorraLINQ.Entidades;
using MazmorraLINQ.Datos;

namespace MazmorraLINQ.Nucleo;

public static class SistemaBotin
{
    static Random rng = new();

    public static Objeto GenerarBotin()
    {
        return BaseObjetos.Objetos
            .OrderBy(_ => rng.Next())
            .Take(3)
            .MaxBy(o => o.Valor);
    }
}
