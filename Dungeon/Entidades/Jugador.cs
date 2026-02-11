namespace MazmorraLINQ.Entidades;

public class Jugador
{
    public int Vida { get; set; } = 200;
    public int VidaMaxima { get; set; } = 200;
    public int AtaqueBase { get; set; } = 5;
    public int Defensa { get; set; } = 6;
    public int Velocidad { get; set; } = 3;
    public int Nivel { get; set; } = 1;
    public int EnemigosDerrotados { get; set; } = 0;
    public List<Objeto> Inventario { get; set; } = new();
    public Objeto ArmaEquipada { get; set; }
    public Objeto ArmaduraEquipada { get; set; }
    public Objeto BotasEquipadas { get; set; }
    public Dictionary<string, int> CooldownsCenizas { get; set; } = new();
}
