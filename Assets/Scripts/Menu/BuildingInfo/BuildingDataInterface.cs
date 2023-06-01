using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBuildingData
{
    public string nom { get; set; }
    public float price { get; set; }
    public float malus { get; set; }
    public float satis { get; set; }
    public float elec { get; set; }
    public float eau { get; set; }
    public float nourriture { get; set; }
    public float habitants { get; set; }

    public IBuildingData(string n, float p, float m, float s, float e, float ea, float no, float h)
    {
        nom = n;
        price = p;
        malus = m;
        satis = s;
        elec = e;
        eau = ea;
        nourriture = no;
        habitants = h;
    }

    public void createObject(string n, float p, float m, float s, float e, float ea, float no, float h)
    {
        nom = n;
        price = p;
        malus = m;
        satis = s;
        elec = e;
        eau = ea;
        nourriture = no;
        habitants = h;
    }
}
