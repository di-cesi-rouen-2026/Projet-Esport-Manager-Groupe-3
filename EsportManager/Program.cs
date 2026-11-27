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

// Le prologue (texte, "Acceptez vous cette MISSION HERO ?") est dans fonction.cs
Fonctions.Prologue();

// La question "HERO quel est votre nom ?" est aussi dans Fonctions.cs, elle renvoie le nom saisi
nomChef = Fonctions.DemanderNom();

//======================================================[MenuPrincipal]===================================================
//On lance le menu principal qui permet de jouer au jeu

// Le menu est dans fonctions.cs
var jeu = new Fonctions(nomChef);
jeu.Menu();

//======================================================[Partie du Jeu]===================================================

// FinDuJeu, GestionMage, GestionEquipe, OrganiserMatch et Recruter sont dans fonction.cs


//======================================================[Fin du programme]===================================================

bdd.CloseConnection(); // ferme la connexion à la base de donnée