namespace EsportManager;

public class Mage
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Prenom { get; set; } = string.Empty;
    public bool Apte { get; set; }
    public int? PV { get; set; }
    public int? MaxPV { get; set; }
    public int? Defense { get; set; }
    public int? Attaque { get; set; }
    public int? Mana { get; set; }
    public int? Corruption { get; set; }
    public int? Foi { get; set; }
    public int? Id_Role { get; set; }
    public int? Id_Equipe { get; set; }
    public Role? Role { get; set; }
    public IReadOnlyList<Capacite> Capacites =>
        (IReadOnlyList<Capacite>?)Role?.Capacites ?? Array.Empty<Capacite>();
}
