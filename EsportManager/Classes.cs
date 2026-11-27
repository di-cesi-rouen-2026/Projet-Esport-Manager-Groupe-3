using System;
using System.Collections.Generic;

public class Mage
{
    public string Nom { get; }
    public int Pv { get; set; }
    public int PvMax { get; set; }
    public int Attaque { get; }
    public int Defense { get; }
    public string Pouvoir {get;}
    public string Role {get;}

    public Mage(string nom, int pv, int pvmax, int attaque, int defense, string pouvoir, string role)
    {
        Nom = nom;
        Pv = pv;
        PvMax = pvmax;
        Attaque = attaque;
        Defense = defense;
        Pouvoir = "";
        Role = "";
    }
    public void Degats(Mage Mage2)
    {
        int degats = Math.Max(1, Attaque - Mage2.Defense);
        Mage2.Pv = Math.Max(0, Mage2.Pv - degats);

    }
    public void RejoindreEquipe(List<Mage> equipe){

        equipe.Add(this);
    }

}




public static class Equipe
{
    public static List<Mage> Creer()
    {
        return new List<Mage>
        {
            // Nom, PV, PvMax, attaque, défense, Pouvoir, role
            new Mage ("ARCHIMAGE", 70,90,15,4,"LANCE ESCARGOTS","ATTAQUANT"),
            new Mage ("DOME LE MAGE",120,140,2,10,"DOME DE PROTECTION","DEFENSEUR"),
            new Mage ("LE MAGE VERT",60,75,3,4,"BOULE DE RESSURECTION","SOIGNANT")
        };
    }

    public static bool EncoreEnVie(List<Mage> equipe)
    {
        foreach (Mage mage in equipe)
        {
            if (mage.Pv > 0)
            {
                return true;
            }
        }

        return false;
    }
}