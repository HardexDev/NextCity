using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsBehavior : MonoBehaviour
{
    public TMP_Text satisfactionTMP;
    public TMP_Text argentTMP;
    public TMP_Text malusTMP;
    public TMP_Text habitantsTMP;
    public TMP_Text energieTMP;
    public TMP_Text nourritureTMP;

    [SerializeField]
    private EngineScript engineScript;
    IStatsInterface data;

    private Color baseColor = new Color(0, 0, 0, 255);


    // Start is called before the first frame update
    void Start()
    {
        UpdateData();

        InvokeRepeating("UpdateData", 1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void UpdateData()
    {
        data = new IStatsInterface(engineScript.Satisfaction, engineScript.Argent, engineScript.Ecologie, engineScript.Habitants, engineScript.Energie, engineScript.Agriculture);
        displayData(data);
    }

    public void displayData(IStatsInterface data)
    {
        satisfactionTMP.SetText(string.Format("{0:0.##}", data.satisfaction) + "%");

        string roundArgent;
        if(data.argent < 1000)
        {
            roundArgent = data.argent.ToString();
        }
        else if(data.argent < 1000000)
        {
            roundArgent = (data.argent/1000).ToString() + "k";
        }
        else
        {
            roundArgent = (data.argent / 1000000).ToString() + "M";
        }
        argentTMP.SetText(roundArgent + " €");

        malusTMP.SetText(string.Format("{0:0.##}", data.malus) + "%");

        string roundHab;
        if (data.habitants < 1000)
        {
            roundHab = data.habitants.ToString();
        }
        else if (data.habitants < 1000000)
        {
            roundHab = (data.habitants / 1000).ToString() + "k";
        }
        else
        {
            roundHab = (data.habitants / 1000000).ToString() + "M";
        }
        habitantsTMP.SetText(roundHab.ToString() + " habitants");


        
        energieTMP.SetText(string.Format("{0:0.##}", data.energie) + "% (conso / prod)");
        if(data.energie > 100f){
            energieTMP.color = new Color(255, 0, 0, 255);
        }
        else{
            energieTMP.color = baseColor;
        }

        nourritureTMP.SetText(string.Format("{0:0.##}", data.nourriture) + "% (conso / prod)");
        if(data.nourriture > 100f){
            nourritureTMP.color = new Color(255, 0, 0, 255);
        }
        else{
            nourritureTMP.color = baseColor;
        }
    }
}
