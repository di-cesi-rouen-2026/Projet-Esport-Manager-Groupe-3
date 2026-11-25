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

    public Mage(string nom, int pv, int pvmax, int attaque, int defense, string pouvoir)
    {
        Nom = nom;
        Pv = pv;
        PvMax = pvmax;
        Attaque = attaque;
        Defense = defense;
        Pouvoir = pouvoir;
    }
    public void Degats(Mage Mage2)
    {
        int degats = Math.Max(1, Attaque - Mage2.Defense);
        Mage2.Pv = Math.Max(0, Mage.Pv - degats);

    }

}




public static class ListeMages
{
    public static List<Mage> Creer()
    {
        return new List<Mage>
        {
            // Nom, PV, PvMax, attaque, défense, Pouvoir
        };
    }
}



