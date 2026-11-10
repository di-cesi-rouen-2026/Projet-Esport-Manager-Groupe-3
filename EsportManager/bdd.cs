namespace EsportManager;
using Microsoft.Data.Sqlite; // j'importe le plugin Microsoft Sqlite 
using System;

/* c'est une class static (sans instanciation) bdd
 * qui contient le liens avec la base de donnée et
 * des méthode (fonction) pour intéragir avec la base de donnée
 * on pourra ajouter des méthode en fonction des besoin
 * pour le moment il n'y a que des méthode generique
 * ---------------------------------------------------
 * pour utiliser une méthode il sufit d'écrire bdd.NomDeLaMéthode()
 * vous pouvez aussi directement utilisé la connexion a la base de donné via bdd._connexion
 * pour intéragir avec la bdd directement dans le code */

/* liste des méthode ajouté :
 * connection
 * closeConnection
 * UpdateValue
 * getValue
 * readTable
 * getTable
 * readLine
 * getLine
 * getLineIf
 * clearTable
 * mageInsert
 * capaciteInsert
 * equipeInsert
 * matchInsert
 * roleInsert */

public static class bdd
{
    private static SqliteConnection _connexion; //le liens avec la base de donné

    // methode qui créer la connexion a la base de donné.
    // a lancé au debut du program
    public static void connection()
    {
        string connectionBddString = "Data Source=..\\..\\..\\BDD";
        _connexion = new SqliteConnection(connectionBddString);
        _connexion.Open();
    }
    
    // methode pour fermer la connexion a la base de donné.
    // a lancé a la fin du programme
    public static void closeConnection()
    {
        _connexion.Dispose();
    }
    
    // permet de modifier une valeur spécifique dans une table
    public static void UpdateValue(string table,int Id, string colonne, object value)
    {
        // on créer la commande
        string UpdateQuery =
            $"UPDATE {table} SET {colonne} = $value WHERE Id = $Id"; 
        var commandUpdate = new SqliteCommand(UpdateQuery, _connexion);
        
        //on definit les valeur de la requette sql
        commandUpdate.Parameters.AddWithValue("$Id", Id); 
        commandUpdate.Parameters.AddWithValue("$value", value);
        
        // on execute la commande
        int rowsAffected = commandUpdate.ExecuteNonQuery(); 
        Console.WriteLine($"Ligne Modifier ! {rowsAffected} ligne(s) modifiée(s).");
    }
    
    // renvoie une valeur specifique d'une table
    public static string getValue(string table,int Id, string colonne)
    {
        // on créer la commande
        string selectQuery = $"SELECT {colonne} FROM {table}  WHERE Id = $id"; 
        var commandSelect = new SqliteCommand(selectQuery, _connexion);
        
        //on definit les valeur de la requette sql
        commandSelect.Parameters.AddWithValue("$id", Id);
        
        // on execute la commande
        var reader = commandSelect.ExecuteReader();
        
        // on lit la valeur
        reader.Read(); 
        string value = reader[colonne].ToString(); 
        return value;
    }
    
    // écrit dans la console tout le contenue d'une table
    public static void readTable(string table)
    {
        // on créer la commande
        string selectQuery = $"SELECT * FROM {table}";
        var commandSelect = new SqliteCommand(selectQuery, _connexion);
        
        // on execute la commande
        var reader = commandSelect.ExecuteReader();
        
        // on écrit ligne par ligne puis colonne par colonne
        Console.WriteLine($"\nContenu de la table {table} :");
        while (reader.Read()) 
        {
            for (int i = 0; i < reader.FieldCount; i++) 
            {
                string colonne = reader.GetName(i); 
                object valeur = reader.IsDBNull(i) ? "NULL" : reader.GetValue(i); 
                Console.Write($"{colonne}: {valeur}, ");
            }
            Console.WriteLine();
        }
    }
    
    // renvoie tout le contenue d'une table.
    // le contenue est renvoyer sous forme d'une liste de dictionnaire.
    // on peut récupéré le contenue : lignes[numéroDeLaLigne]["NomDeLaColonne"]
    // attention ne pas confondre le numéro de la ligne avec l'id ils sont différents
    public static List<Dictionary<string, object>> getTable(string table)
    {
        // on créer la commande
        string selectQuery = $"SELECT * FROM {table}";
        var commandSelect = new SqliteCommand(selectQuery, _connexion);
        
        // on execute la commande 
        var reader = commandSelect.ExecuteReader();
        
        // on créer la liste qui va contenue toute la table
        List<Dictionary<string, object>> lignes = new(); 
        
        // on lit ligne par ligne et colonne par colonne et on l'insert dans la liste
        while (reader.Read()) 
        {
            Dictionary<string, object> ligne = new(); 
            for (int i = 0; i < reader.FieldCount; i++) 
            {
                string colonne = reader.GetName(i);
                object valeur = reader.IsDBNull(i) ? "NULL" : reader.GetValue(i);
                ligne[colonne] = valeur;
            }
            lignes.Add(ligne);
        }
        return lignes;
    }
    
    // écrit le contenue d'une ligne
    public static void ReadLine(string table, int id)
    {
        string selectQuery = $"SELECT * FROM {table} WHERE Id = $id";
        var commandSelect = new SqliteCommand(selectQuery, _connexion);
        commandSelect.Parameters.AddWithValue("$id", id);
        var reader = commandSelect.ExecuteReader();
        Dictionary<string, object> ligne = new();
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string colonne = reader.GetName(i);
                object valeur = reader.IsDBNull(i) ? "NULL" : reader.GetValue(i);
                Console.Write($"{colonne}: {valeur}, ");
            }
        }
    }
    
    // renvoie le contenue d'une ligne
    public static Dictionary<string, object> getLine(string table, int id)
    {
        string selectQuery = $"SELECT * FROM {table} WHERE Id = $id";
        var commandSelect = new SqliteCommand(selectQuery, _connexion);
        commandSelect.Parameters.AddWithValue("$id", id);
        var reader = commandSelect.ExecuteReader();
        Dictionary<string, object> ligne = new();
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string colonne = reader.GetName(i);
                object valeur = reader.IsDBNull(i) ? "NULL" : reader.GetValue(i);
                ligne[colonne] = valeur;
            }
        }
        return ligne;
    }
    
    // renvoie les ligne d'une table d'on la bonne valeur dans la colonne choisie
    public static List<Dictionary<string, object>> getLineIf(string table, string colonne, object value)
    {
        string selectQuery = $"SELECT * FROM {table} WHERE {colonne} = $value";
        var commandSelect = new SqliteCommand(selectQuery, _connexion);
        commandSelect.Parameters.AddWithValue("$value", value);
        var reader = commandSelect.ExecuteReader();
        List<Dictionary<string, object>> lignes = new();
        while (reader.Read())
        {
            Dictionary<string, object> ligne = new();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string nomColonne = reader.GetName(i);
                object valeur = reader.IsDBNull(i) ? "NULL" : reader.GetValue(i);
                ligne[nomColonne] = valeur;
            }
            lignes.Add(ligne);
        }
        return lignes;
    }
    
    // reset toute la table selectionné pour remettre a zero apres un teste. 
    // remet aussi a zero l'incrémentation
    // attention sa suprime toute les données de la table!
    // a utilisé pour suprimmé les donné de teste
    public static void ClearTable(string table)
    {
        string DeleteQuery = $"DELETE FROM {table}";
        var commandDelete = new SqliteCommand(DeleteQuery, _connexion);
        commandDelete.ExecuteNonQuery();
        
        string ResetQuery = "DELETE FROM sqlite_sequence WHERE name = $table";
        var commandReset = new SqliteCommand(ResetQuery, _connexion);
        commandReset.Parameters.AddWithValue("$table", table);
        int rowsAffected =commandReset.ExecuteNonQuery();
        Console.WriteLine($"table réinitianilé ! {rowsAffected} ligne(s) éffacée(s).");
    }

    // permet d'insérer une nouvelle ligne dans la table Mage
    public static void mageInsert(string Nom, string Prenom, bool Apte, int PV, int MaxPV, int Defense, int Attaque, int Mana, int Corruption, int Foi)
    {
        // je créer la commande
        string insertQuery =
            "INSERT INTO Mage (Nom, Prenom, Apte, PV, MaxPV, Defense, Attaque, Mana, Corruption, Foi) VALUES ($Nom, $Prenom, $Apte, $PV, $MaxPV, $Defense, $Attaque, $Mana, $Corruption, $Foi)";
        var commandInsert = new SqliteCommand(insertQuery, _connexion);
        
        // je définit les parametre de la commande
        commandInsert.Parameters.AddWithValue("$Nom", Nom);
        commandInsert.Parameters.AddWithValue("$Prenom", Prenom);
        commandInsert.Parameters.AddWithValue("$Apte", Apte);
        commandInsert.Parameters.AddWithValue("$PV", PV);
        commandInsert.Parameters.AddWithValue("$MaxPV", MaxPV);
        commandInsert.Parameters.AddWithValue("$Defense", Defense);
        commandInsert.Parameters.AddWithValue("$Attaque", Attaque);
        commandInsert.Parameters.AddWithValue("$Mana", Mana);
        commandInsert.Parameters.AddWithValue("$Corruption", Corruption);
        commandInsert.Parameters.AddWithValue("$Foi", Foi);
        
        // j'éxecute la commande
        int rowsAffected = commandInsert.ExecuteNonQuery();
        Console.WriteLine($"Ligne ajoutée ! {rowsAffected} ligne(s) modifiée(s).");
    }
    
    // permet d'insérer une nouvelle ligne dans la table Capacite
    public static void capaciteInsert(string Nom, string Description, int NiveauDeStateMin)
    {
        string insertQuery =
            "INSERT INTO Capacite (Nom, Description, NiveauDeStateMin) VALUES ($Nom, $Description, $StateMin)";
        var commandInsert = new SqliteCommand(insertQuery, _connexion);
        commandInsert.Parameters.AddWithValue("$Nom", Nom);
        commandInsert.Parameters.AddWithValue("$Description", Description);
        commandInsert.Parameters.AddWithValue("$StateMin", NiveauDeStateMin);
        int rowsAffected = commandInsert.ExecuteNonQuery();
        Console.WriteLine($"Ligne ajoutée ! {rowsAffected} ligne(s) modifiée(s).");
    }
    
    // permet d'insérer une nouvelle ligne dans la table Equipe
    public static void equipeInsert(string Nom)
    {
        string insertQuery =
            "INSERT INTO Capacite (Nom) VALUES ($Nom)";
        var commandInsert = new SqliteCommand(insertQuery, _connexion);
        commandInsert.Parameters.AddWithValue("$Nom", Nom);
        int rowsAffected = commandInsert.ExecuteNonQuery();
        Console.WriteLine($"Ligne ajoutée ! {rowsAffected} ligne(s) modifiée(s).");
    }
    
    // permet d'insérer une nouvelle ligne dans la table Match_
    public static void matchInsert(int victoire)
    {
        string insertQuery =
            "INSERT INTO Capacite (Victoire) VALUES ($victoire)";
        var commandInsert = new SqliteCommand(insertQuery, _connexion);
        commandInsert.Parameters.AddWithValue("$victoire", victoire);
        int rowsAffected = commandInsert.ExecuteNonQuery();
        Console.WriteLine($"Ligne ajoutée ! {rowsAffected} ligne(s) modifiée(s).");
    }
    
    // permet d'insérer une nouvelle ligne dans la table Role
    public static void roleInsert(string Nom, string Description, string StateRequise, int NiveauDeStateMin)
    {
        string insertQuery =
            "INSERT INTO Capacite (Nom, Description, StateRequise, NiveauDeStateMin) VALUES ($Nom, $Description, $StateRequise, $NiveauDeStateMin)";
        var commandInsert = new SqliteCommand(insertQuery, _connexion);
        commandInsert.Parameters.AddWithValue("$Nom", Nom);
        commandInsert.Parameters.AddWithValue("$Description", Description);
        commandInsert.Parameters.AddWithValue("$StateRequise", StateRequise);
        commandInsert.Parameters.AddWithValue("$NiveauDeStateMin", NiveauDeStateMin);
        int rowsAffected = commandInsert.ExecuteNonQuery();
        Console.WriteLine($"Ligne ajoutée ! {rowsAffected} ligne(s) modifiée(s).");
    }
}