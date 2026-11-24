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
}

public class Degats
{
     public int PvActuels { get; set; }
    public int Attaque { get; }
    public int Defense { get; }

    public Degats(int pvActuels, int attaque, int defense)
    {
        PvActuels = pvActuels;
        Attaque = attaque;
        Defense = defense;
    }
    public int DegatsInfliges => Math.Max(1, Attaque - Defense);
    public int PvRestants => Math.Max(0, PvActuels - DegatsInfliges);
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



