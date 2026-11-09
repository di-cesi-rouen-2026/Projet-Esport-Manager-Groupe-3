namespace EsportManager;
using Microsoft.Data.Sqlite;
using System;

public static class bdd
{
    private static SqliteConnection _connexion;

    public static void connection()
    {
        string connectionBddString = "Data Source=..\\..\\..\\BDD";
        _connexion = new SqliteConnection(connectionBddString);
        _connexion.Open();
    }

    public static void closeConnection()
    {
        _connexion.Dispose();
    }

    public static void mageInsert(string Nom, string Prenom, bool Apte, int PV, int MaxPV, int Defense, int Attaque, int Mana, int Corruption, int Foi)
    {
        string insertQuery =
            "INSERT INTO Mage (Nom, Prenom, Apte, PV, MaxPV, Defense, Attaque, Mana, Corruption, Foi) VALUES ($Nom, $Prenom, $Apte, $PV, $MaxPV, $Defense, $Attaque, $Mana, $Corruption, $Foi)";
        var commandInsert = new SqliteCommand(insertQuery, _connexion);
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
        int rowsAffected = commandInsert.ExecuteNonQuery();
        Console.WriteLine($"Ligne ajoutée ! {rowsAffected} ligne(s) modifiée(s).");
    }
    
    public static void mageReadAll()
    {
        string selectQuery = "SELECT * FROM Mage";
        var commandSelect = new SqliteCommand(selectQuery, _connexion);
        var reader = commandSelect.ExecuteReader();
        Console.WriteLine("\nContenu de la table Mage :");
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["Id"]}, Nom: {reader["Nom"]}, Prenom: {reader["Prenom"]}, Apte: {reader["Apte"]}, PV: {reader["PV"]}, MaxPV: {reader["MaxPV"]}, Defense: {reader["Defense"]}, Attaque: {reader["Attaque"]} , Mana: {reader["Mana"]}, Corruption: {reader["Corruption"]}, Foi: {reader["Foi"]}");
        }
    }
    
    public static void mageRead(int id)
    {
        string selectQuery = "SELECT * FROM Mage  WHERE Id = $id";
        var commandSelect = new SqliteCommand(selectQuery, _connexion);
        commandSelect.Parameters.AddWithValue("$id", id);
        var reader = commandSelect.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["Id"]}, Nom: {reader["Nom"]}, Prenom: {reader["Prenom"]}, Apte: {reader["Apte"]}, PV: {reader["PV"]}, MaxPV: {reader["MaxPV"]}, Defense: {reader["Defense"]}, Attaque: {reader["Attaque"]} , Mana: {reader["Mana"]}, Corruption: {reader["Corruption"]}, Foi: {reader["Foi"]}");
        }
    }
    
    public static void mageReadIf(string colonne, object value)
    {
        string selectQuery = $"SELECT * FROM Mage  WHERE {colonne} = $value";
        var commandSelect = new SqliteCommand(selectQuery, _connexion);
        commandSelect.Parameters.AddWithValue("$value", value);
        var reader = commandSelect.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["Id"]}, Nom: {reader["Nom"]}, Prenom: {reader["Prenom"]}, Apte: {reader["Apte"]}, PV: {reader["PV"]}, MaxPV: {reader["MaxPV"]}, Defense: {reader["Defense"]}, Attaque: {reader["Attaque"]} , Mana: {reader["Mana"]}, Corruption: {reader["Corruption"]}, Foi: {reader["Foi"]}");
        }
    }
    
    public static void mageUpdateComplet(int Id,string Nom, string Prenom, bool Apte, int PV, int MaxPV, int Defense, int Attaque, int Mana, int Corruption, int Foi)
    {
        string updateQuery =
            "UPDATE Mage SET Nom = $Nom, Prenom = $Prenom, Apte = $Apte, PV = $PV, MaxPV = $MaxPV, Defense = $Defense, Attaque = $Attaque, Mana = $Mana, Corruption = $Corruption, Foi = $Foi WHERE Id = $Id";
        var commandUpdate = new SqliteCommand(updateQuery, _connexion);
        commandUpdate.Parameters.AddWithValue("$Id", Id);
        commandUpdate.Parameters.AddWithValue("$Nom", Nom);
        commandUpdate.Parameters.AddWithValue("$Prenom", Prenom);
        commandUpdate.Parameters.AddWithValue("$Apte", Apte);
        commandUpdate.Parameters.AddWithValue("$PV", PV);
        commandUpdate.Parameters.AddWithValue("$MaxPV", MaxPV);
        commandUpdate.Parameters.AddWithValue("$Defense", Defense);
        commandUpdate.Parameters.AddWithValue("$Attaque", Attaque);
        commandUpdate.Parameters.AddWithValue("$Mana", Mana);
        commandUpdate.Parameters.AddWithValue("$Corruption", Corruption);
        commandUpdate.Parameters.AddWithValue("$Foi", Foi);
        int rowsAffected = commandUpdate.ExecuteNonQuery();
        Console.WriteLine($"Ligne Modifier ! {rowsAffected} ligne(s) modifiée(s).");
    }
    
    public static void UpdateValue(string table,int Id, string colonne, object value)
    {
        string UpdateQuery =
            $"UPDATE {table} SET {colonne} = $value WHERE Id = $Id";
        var commandUpdate = new SqliteCommand(UpdateQuery, _connexion);
        commandUpdate.Parameters.AddWithValue("$Id", Id);
        commandUpdate.Parameters.AddWithValue("$value", value);
        int rowsAffected = commandUpdate.ExecuteNonQuery();
        Console.WriteLine($"Ligne Modifier ! {rowsAffected} ligne(s) modifiée(s).");
    }
    
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
    
}