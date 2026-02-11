using MazmorraLINQ.Entidades;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MazmorraLINQ.Datos
{
    public static class BaseObjetos
    {
        public static List<Objeto> Objetos { get; private set; }

        static BaseObjetos()
        {
            var opciones = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() }
            };

            // Cargar objetos normales
            string jsonObjetos = File.ReadAllText("Datos/objetos.json");
            var objetos = JsonSerializer.Deserialize<List<Objeto>>(jsonObjetos, opciones);

            // Cargar armas (como ArmaHabil)
            string jsonArmas = File.ReadAllText("Datos/armas.json");
            var armas = JsonSerializer.Deserialize<List<ArmaHabil>>(jsonArmas, opciones)
                .Cast<Objeto>() // Convertir a Objeto para unir listas
                .ToList();

            // Unir ambas listas
            objetos.AddRange(armas);

            // Guardar en la propiedad estática
            Objetos = objetos;
        }
    }
}
