
string prologue =
    "BIENVENUE DANS LE ROYAUME DE FIORE !\n" +
    "Là où, tous les 5 ans, se retrouvent mages et aventuriers de tous les horizons.\n" +
    "Cette année, nous avons la chance d'accueillir les représentants des 10 Grandes Guildes.\n" +
    "Des guildes qui, lors de cette 20e ÉDITION du tournoi magique de FIORE, nous prouveront leur bravoure.\n" +
    "Alors HERO, si vous l'acceptez, votre mission sera de guider les mages de la guilde de <nomguilde>.";

foreach (char lettre in prologue)
{
    Console.Write(lettre);
    Thread.Sleep(40); // Écriture en fondu progressif
}

bool restart = true;
while (restart)
{
    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("Acceptez vous cette MISSION HERO ?");
    Console.WriteLine("1.OUI       2.NON");
    string choix = Console.ReadLine();

    if (choix == "1")
    {
        Console.WriteLine("BONNE DECISON !");
        restart = false;
    }
    else if (choix == "2")
    {
        Console.WriteLine("");
        string shy = "UN PEU DE SERIEUX HERO !";
        foreach (char c in shy)
        {
            Console.Write(c);
            Thread.Sleep(30);
        }
    }
    else
    {
        Console.WriteLine("");
        String fool = "Restez concentré HERO !";
        foreach (char c in fool)
        {
            Console.Write(c);
            Thread.Sleep(30);
        }
    }
}

Console.WriteLine("");
Console.WriteLine("HERO quel est votre nom ?");
string nomchef = Console.ReadLine();
Console.WriteLine();
Thread.Sleep(1000);
Console.WriteLine("A VOUS DE JOUER !");
Console.WriteLine("");
String go =$"NOUS COMPTONS SUR VOUS {nomchef}";
foreach (char c in go)
{
    Console.Write(c);
    Thread.Sleep(30);
}