using System;
using EsportManager; // j'importe toute les class du dossier e-sport
using Microsoft.Data.Sqlite;

bdd.connection(); // lance la connexion a la base de donnée 

List<Dictionary<string, object>> lignes = bdd.getLineIf("Mage", "Id", 3);
Console.WriteLine($"Nom : {lignes[0]["Nom"]}, Prenom : {lignes[0]["Prenom"]}, PV : {lignes[0]["PV"]}");

bdd.closeConnection(); // ferme la connexion a la base de donné