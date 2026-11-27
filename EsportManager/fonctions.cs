namespace EsportManager;

public class Fonctions
{
    private string nomChef;
    private bool gameContinue = true;
    private string contentMissing = "Ce contenu n'a pas encore été ajouté au jeu.";

    // ---------- Constructeur : appelé par "new Fonctions(...)" ----------
    public Fonctions(string nomChef)
    {
        this.nomChef = nomChef;
    }

    // ---------- Fonctions statiques : pas besoin d'objet ----------
    public static void EcrireLentement(string texte, int delai = 30)
    {
        foreach (char c in texte)
        {
            Console.Write(c);
            Thread.Sleep(delai);
        }
    }

    public static void Prologue()
    {
        string prologue =
            "BIENVENUE DANS LE ROYAUME DE FIORE !\n" +
            "Là où, tous les 5 ans, se retrouvent mages et aventuriers de tous les horizons.\n" +
            "Cette année, nous avons la chance d'accueillir les représentants des 10 Grandes Guildes.\n" +
            "Des guildes qui, lors de cette 20e ÉDITION du tournoi magique de FIORE, nous prouveront leur bravoure.\n" +
            "Alors HERO, si vous l'acceptez, votre mission sera de guider les mages de la guilde de <nomguilde>.";

        EcrireLentement(prologue, 40);

        bool restart = true;
        while (restart)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Acceptez-vous cette MISSION HERO ?");
            Console.WriteLine("1.OUI       2.NON");
            string? choix = Console.ReadLine();

            if (choix == "1")
            {
                Console.WriteLine("BONNE DECISION !");
                restart = false;
            }
            else if (choix == "2")
            {
                Console.WriteLine("");
                EcrireLentement("UN PEU DE SERIEUX HERO !");
            }
            else
            {
                Console.WriteLine("");
                EcrireLentement("Restez concentré HERO !");
            }
        }
    }

    public static string DemanderNom()
    {
        Console.WriteLine("");
        Console.WriteLine("HERO quel est votre nom ?");
        string nom = Console.ReadLine() ?? "HERO";

        Console.WriteLine();
        Thread.Sleep(1000);
        Console.WriteLine("A VOUS DE JOUER !");
        Console.WriteLine("");
        EcrireLentement($"NOUS COMPTONS SUR VOUS {nom}");

        return nom; // la fonction "renvoie" le nom qui sera stocké
    }

    // ---------- Fonctions d'objet : utilisent nomChef / gameContinue ----------
    public void Menu()
    {
        while (gameContinue)
        {
            Console.WriteLine("");
            Thread.Sleep(500);
            Console.WriteLine("================= MENU PRINCIPAL =================");
            Thread.Sleep(200);
            Console.Write("0.QUITTER        ");
            Thread.Sleep(200);
            Console.Write("1.GERER VOS MAGES        ");
            Thread.Sleep(200);
            Console.Write("2.GERER LES EQUIPES      ");
            Thread.Sleep(200);
            Console.Write("3.ORGANISER UN MATCH     ");
            Thread.Sleep(200);
            Console.Write("4.RECRUTER       ");
            Console.WriteLine("");

            string? choixMenu = Console.ReadLine();
            switch (choixMenu)
            {
                case "0":
                    FinDuJeu();
                    break;
                case "1":
                    GestionMage();
                    Thread.Sleep(500);
                    break;
                case "2":
                    GestionEquipe();
                    Thread.Sleep(500);
                    break;
                case "3":
                    OrganiserMatch();
                    Thread.Sleep(500);
                    break;
                case "4":
                    Recruter();
                    Thread.Sleep(500);
                    break;
                default:
                    Console.WriteLine("Entrée invalide, recommence.");
                    break;
            }
        }
    }

    private void FinDuJeu()
    {
        Thread.Sleep(500);
        Console.WriteLine("");
        Console.WriteLine($"Merci {nomChef} d'avoir joué. Toutes les données non sauvegardées seront perdues.");
        Console.WriteLine("Enfin, pour l'instant on n'a pas de système de sauvegarde, donc...");
        gameContinue = false;
    }

    private void GestionMage()
    {
        Console.WriteLine("");
        Console.WriteLine(contentMissing);
    }

    private void GestionEquipe()
    {
        Console.WriteLine("");
        Console.WriteLine(contentMissing);
    }

    private void OrganiserMatch()
    {
        Console.WriteLine("");
        Console.WriteLine(contentMissing);
    }

    private void Recruter()
    {
        Console.WriteLine("");
        Console.WriteLine(contentMissing);
    }
}