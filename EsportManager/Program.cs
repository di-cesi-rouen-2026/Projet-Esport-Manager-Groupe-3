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