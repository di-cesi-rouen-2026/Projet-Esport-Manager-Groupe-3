using System;
using EsportManager; // j'importe toute les class du dossier EsportManager
using Microsoft.Data.Sqlite; // j'importe le package Microsoft sqlite

bdd.Connection(); // lance la connexion à la base de donnée 


// ici, on peut intéragir avec la base de donnée via bdd._connexion
// ou en utilisant bdd.NomDuneMethode()


bdd.CloseConnection(); // ferme la connexion à la base de donnée