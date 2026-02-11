using MazmorraLINQ.Entidades;
using System.Text.Json;

namespace MazmorraLINQ.Datos;

public static class BaseEnemigos
{
    public static List<Enemigo> Enemigos { get; private set; }

    static BaseEnemigos()
    {
        string json = File.ReadAllText("Datos/enemigos.json");
        Enemigos = JsonSerializer.Deserialize<List<Enemigo>>(json);

        //Cambio de bucle por LINQ
        Enemigos = Enemigos
            .Select(e =>
            {
                e.Vida = (int)(e.Vida * (1 + e.Nivel * 0.4));
                e.Ataque = (int)(e.Ataque * (1 + e.Ataque * 0.25));
                e.Velocidad = (int)(e.Velocidad * (1 + e.Velocidad * 0.2));
                return e;
            })
            .ToList();
    }
}
