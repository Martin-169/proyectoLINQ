using MazmorraLINQ.Entidades;
using MazmorraLINQ.Datos;

namespace MazmorraLINQ.Nucleo;

public static class GeneradorMazmorra
{
    static Random rng = new();

    public static List<Sala> GenerarMazmorra()
    {
        //Cambio de bucle por LINQ
        return Enumerable.Range(1, 10)
            .Select(id =>
            {
                bool esBoss = id == 5 || id == 10;

                return new Sala
                {
                    Id = id,

                    Enemigos = BaseEnemigos.Enemigos
                        .OrderBy(_ => rng.Next())
                        .Take(esBoss ? 1 : rng.Next(1, 4))
                        .Select(e => CrearEnemigoEscalado(e, id, esBoss))
                        .ToList(),

                    Objetos = BaseObjetos.Objetos
                        .OrderBy(_ => rng.Next())
                        .Take(rng.Next(0, 3))
                        .ToList()
                };
            })
            .ToList();
    }

    private static Enemigo CrearEnemigoEscalado(Enemigo baseE, int sala, bool boss)
    {
        double multiplicador = 1 + (sala - 1) * 0.25;

        int vida = (int)(baseE.Vida * multiplicador);
        int ataque = (int)(baseE.Ataque * multiplicador);
        int velocidad = (int)(baseE.Velocidad * (1+ (sala -1) * 0.10));

        if (boss)
        {
            vida = (int)(vida * 1.8);
            ataque = (int)(ataque *1.8);
            velocidad += 1;
        }

        return new Enemigo
        {
            Nombre = boss ? $"BOSS {baseE.Nombre}" : baseE.Nombre,
            Tipo = baseE.Tipo,
            Nivel = sala,
            Vida = vida,
            Ataque = ataque,
            Velocidad = velocidad
        };
    }
}
