namespace EsportManager;

public class Role
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string StateRequise { get; set; } = string.Empty;
    public int NiveauDeStateMin { get; set; }
    public List<Capacite> Capacites { get; set; } = new();
}
