//==========================================[Lib et package]===================================================
//on importe les lib et package

using System;
using EsportManager; // j'importe toute les class du dossier EsportManager
using Microsoft.Data.Sqlite; // j'importe le package Microsoft sqlite

//==========================================[Initialisation]===================================================
//ici, on importe les données et on déclare les variables globales du jeu


bdd.Connection(); // lance la connexion à la base de donnée 
// on peut intéragir avec la base de donnée via bdd._connexion
// ou en utilisant bdd.NomDuneMethode()

string contentMissing = "ce contenue n'as pas encore étais ajouté au jeux.";
string nomChef;


//===============================================[Intro]=====================================================
//on démarre le jeu et lance le prologue

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
nomChef = Console.ReadLine();
Console.WriteLine();
Thread.Sleep(1000);
Console.WriteLine("A VOUS DE JOUER !");
Console.WriteLine("");
String go =$"NOUS COMPTONS SUR VOUS {nomChef}";
foreach (char c in go)
{
    Console.Write(c);
    Thread.Sleep(30);
}

//======================================================[MenuPrincipal]===================================================
//On lance le menu principal qui permet de jouer au jeu


bool gameContinue = true;
string choixMenu;
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
    choixMenu = Console.ReadLine();
    switch(choixMenu)
    {
        case "0":
            finDuJeu();
            break;
        case "1": 
            gestionMage();
            Thread.Sleep(500);
            break;
        case "2":
            gestionEquipe();
            Thread.Sleep(500);
            break;
        case "3":
            organiserMatch();
            Thread.Sleep(500);
            break;
        case "4":
            recruter();
            Thread.Sleep(500);
            break;
        default:
            Console.WriteLine("Entré invalide recommencer.");
            break;
    }
}

//======================================================[Partie du Jeu]===================================================
//On écrit les différentes parties du jeu qu'on pourra appeler via le menu Principale

void finDuJeu()
{
    Thread.Sleep(500);
    Console.WriteLine("");
    Console.WriteLine($"Merci {nomChef} d'avoir joué. toute donnés non sauvegarder sera perdu");
    Console.WriteLine("enfin pour l'instant on a pas de système de save donc...");
    gameContinue = false;
}

void gestionMage()
{
    Console.WriteLine("");
    Console.WriteLine(contentMissing);
}

void gestionEquipe()
{
    Console.WriteLine("");
    Console.WriteLine(contentMissing);
}

void organiserMatch()
{
    Console.WriteLine("");
    Console.WriteLine(contentMissing);
}

void recruter()
{
    Console.WriteLine("");
    Console.WriteLine(contentMissing);
}


//======================================================[Fin du programme]===================================================

bdd.CloseConnection(); // ferme la connexion à la base de donnée

//=====================================================[creation du premier combat automatique 3vs3]
List<Mage> equipe1 = Equipe.Creer();
List<Mage> equipe2 = Equipe.Creer();

Console.WriteLine("Voulez vous lancer un premier combat?");
Console.WriteLine("1.oui ========= 2.non ");
string choixcombatt = Console.ReadLine();
int.TryParse(choixcombatt, out int choixcombat);


//FONCTION SORT POUR DECIDER QUEL MAGE VA APPLIQUER SON ROLE PAR TOUR
Random hasard = new Random();

int indice = hasard.Next(equipe2.Count);
Mage cible = equipe2[indice];

//Console.WriteLine($"Le sort cible {cible.Nom} !");
//equipe1[0].Degats(cible);




// LE COMBAT COMMENCE

if (choixcombat==1)
{
    Console.WriteLine($"VOICI LES MAGES QUI FERONT PARTIE DE TON EQUIPE");
    foreach (Mage mage in equipe1){
        Console.WriteLine($"{mage.Nom} a {mage.Pv}/{mage.PvMax} PV.");
        Console.WriteLine($"Ce mage est un {mage.Role} et possede le pouvoir de {mage.Pouvoir}");
    }

    Console.WriteLine($"VOICI LES MAGES DE L'EQUIPE ADVERSAIRE");
    foreach (Mage mage in equipe2){
        Console.WriteLine($"{mage.Nom} a {mage.Pv}/{mage.PvMax} PV.");
        Console.WriteLine($"Ce mage est un {mage.Role} et possede le pouvoir de {mage.Pouvoir}");
    }


    int i = 0;
    Console.WriteLine($"VOUS COMMENCEZ A ATTAQUER!!");
    while (Equipe.EncoreEnVie(equipe1) && Equipe.EncoreEnVie(equipe2))
    {
        i++;
        Console.WriteLine($"========================== TOUR {i} =========================");
        
        //ATTAQUE DE LEQUIPE 1 VERS LEQUIPE 2//
        if(equipe2[1].Pv > 0){
            equipe1[0].Degats(equipe2[1]);
            Console.WriteLine($"{equipe2[1].Nom} a maintenant {equipe2[1].Pv} PV.");
        }
        else if(equipe2[0].Pv > 0){
            Console.WriteLine($"VOUS AVEZ VAINCU LE DEFENSEUR!! ");
            equipe1[0].Degats(equipe2[0]);
            Console.WriteLine($"{equipe2[0].Nom} a maintenant {equipe2[0].Pv} PV.");
        }
        else{
            Console.WriteLine($"VOUS AVEZ VAINCU LE SOIGNANT!! ");
            equipe1[0].Degats(equipe2[2]);
            Console.WriteLine($"{equipe2[2].Nom} a maintenant {equipe2[2].Pv} PV.");
        }
        
        //ATTAQUE DE LEQUIPE 2 VERS LEQUIPE 1//
        if(equipe1[1].Pv > 0){
            equipe2[0].Degats(equipe1[1]);
            Console.WriteLine($"{equipe1[1].Nom} a maintenant {equipe1[1].Pv} PV.");
        }
        else if(equipe2[0].Pv > 0){
            Console.WriteLine($"VOUS AVEZ VAINCU LE DEFENSEUR!! ");
            equipe2[0].Degats(equipe1[0]);
            Console.WriteLine($"{equipe1[0].Nom} a maintenant {equipe1[0].Pv} PV.");
        }
        else{
            Console.WriteLine($"VOUS AVEZ VAINCU LE SOIGNANT!! ");
            equipe2[0].Degats(equipe1[2]);
            Console.WriteLine($"{equipe1[2].Nom} a maintenant {equipe1[2].Pv} PV.");
        }

    }

    if (!Equipe.EncoreEnVie(equipe1))
    {
        Console.WriteLine("VOUS ETES NUL");
    }
    else
    {
        Console.WriteLine("BRAVO, VOUS AVEZ BATTU L'EQUIPE ADVERSAIRE");
    }


};


