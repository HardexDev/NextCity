using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingStatsBehavior : MonoBehaviour
{
    public TMP_Text nameTMP;
    public TMP_Text priceTMP;
    public TMP_Text malusTMP;
    public TMP_Text satisfactionTMP;
    public TMP_Text elecTMP;
    public TMP_Text eauTMP;
    public TMP_Text nourritureTMP;
    public TMP_Text habTMP;

    public TMP_Text gptTMP;


    // Start is called before the first frame update
    void Start()
    {
        IBuildingData data = new IBuildingData("Nom", 0, 0, 0, 0, 0, 0, 0);
        setBuildingDatas(data, "Texte chat GPT");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setGPTText(string text)
    {
        gptTMP.SetText(text);
    }

    public void setBuildingDatas(IBuildingData data, string gptText)
    {
        nameTMP.SetText(data.nom);

        priceTMP.SetText(data.price.ToString());
        malusTMP.SetText(data.price.ToString() + " points");
        satisfactionTMP.SetText(data.price.ToString() + " points");
        elecTMP.SetText(data.price.ToString() + " kWh");
        eauTMP.SetText(data.price.ToString() + " L / j");
        nourritureTMP.SetText(data.nourriture.ToString() + " kg / j");
        habTMP.SetText(data.habitants.ToString() + " habitants");

        setGPTText(gptText);
    }
}
