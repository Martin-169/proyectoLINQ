namespace MazmorraLINQ.Entidades;

public class Sala
{
    public int Id { get; set; }
    public List<Enemigo> Enemigos { get; set; }
    public List<Objeto> Objetos { get; set; }
}
