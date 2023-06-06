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
        satisfactionTMP.SetText(data.satisfaction.ToString() + "%");

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

        malusTMP.SetText(data.malus.ToString() + "%");

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

        energieTMP.SetText(data.energie.ToString() + "% (conso / prod)");

        nourritureTMP.SetText(data.nourriture.ToString() + "% (conso / prod)");
    }
}
