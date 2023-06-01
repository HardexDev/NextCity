using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStatsInterface
{
    public float satisfaction { get; set; }
    public float argent { get; set; }
    public float malus { get; set; }
    public float habitants { get; set; }
    public float energie { get; set; }
    public float nourriture { get; set; }
    public float eau { get; set; }

    public IStatsInterface(float s, float a, float m, float h, float e, float n, float ea)
    {
        satisfaction = s;
        argent = a;
        malus = m;
        habitants = h;
        energie = e;
        nourriture = n;
        eau = ea;
    }

    public void createObject(
            float satis,
            float arg,
            float mal,
            float hab,
            float ener,
            float nourr,
            float e
        )
    {
        satisfaction = satis;
        argent = arg;
        malus = mal;
        habitants = hab;
        energie = ener;
        nourriture = nourr;
        eau = e;
    }
}
