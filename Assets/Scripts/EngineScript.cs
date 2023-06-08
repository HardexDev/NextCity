using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EngineScript : MonoBehaviour
{
    List<ObjectStats> allObjectsStats = new List<ObjectStats>();

    private float argent = 500f;
    private float satisfaction = 10f;
    private float ecologie = 0f;
    private int habitants = 0;
    private float energie = 0f;
    private float agriculture = 0f;



    private float malusSatisfaction = 0f;
    private float ecologiepts = 0f;
    private float consoEnergie = 0f; // Consommation d'�nergie
    private float consoAgricole = 0f;
    private float prodEnergie = 0f; // Production d'�nergie
    private float prodAgricole = 0f; // Production agricole
    private float malusEco = 0f;
    private bool malusEner = false;
    private bool malusAgri = false;


    public float Argent
    {
        get { return argent; }
        set { argent = value; }
    }

    public float Satisfaction
    {
        get { return satisfaction; }
        set { satisfaction = value; }
    }

    public float Ecologie
    {
        get { return ecologie; }
        set { ecologie = value; }
    }

    public int Habitants
    {
        get { return habitants; }
        set { habitants = value; }
    }

    public float Energie
    {
        get { return energie; }
        set { energie = value; }
    }

    public float Agriculture
    {
        get { return agriculture; }
        set { agriculture = value; }
    }

     public float MalusEco
    {
        get { return malusEco; }
        set { malusEco = value; }
    }

    private float argentInterval = 5f;

    void Start()
    {
        List<GameObject> allGameObjects = GameObject.FindGameObjectsWithTag("Batiment").ToList();
        foreach (GameObject gameObject in allGameObjects)
        {
            //allObjectsStats.Add(gameObject.GetComponent<ObjectStats>());
            AddGameObjectInit(gameObject.GetComponent<ObjectStats>());
        }
        InvokeRepeating("ComputeArgent", 1f, argentInterval);
    }

    public void AddGameObject(ObjectStats gameObject)
    {
        allObjectsStats.Add(gameObject);
        RemoveArgent(gameObject.cout);
        habitants += gameObject.habitants;
        consoAgricole += gameObject.consoAgricole;
        consoEnergie += gameObject.consoEnergie;
        prodAgricole += gameObject.prodAgricole;
        prodEnergie += gameObject.prodEnergie;
        ecologiepts += gameObject.ecologie;
        malusEco += gameObject.malusEco;
        ComputePourcent();
    }

     public void AddGameObjectInit(ObjectStats gameObject)
    {
        allObjectsStats.Add(gameObject);
        habitants += gameObject.habitants;
        consoAgricole += gameObject.consoAgricole;
        consoEnergie += gameObject.consoEnergie;
        prodAgricole += gameObject.prodAgricole;
        prodEnergie += gameObject.prodEnergie;
        ecologiepts += gameObject.ecologie;
        malusEco += gameObject.malusEco;
        ComputePourcent();
    }

    public void RemoveGameObject(ObjectStats gameObject)
    {
        allObjectsStats.RemoveAll(gObject => gObject.GetInstanceID() == gameObject.GetInstanceID());
        AddArgent(gameObject.cout/2);
        Debug.Log("removing " + gameObject.habitants + " habitants");

        habitants -= gameObject.habitants;
        consoAgricole -= gameObject.consoAgricole;
        consoEnergie -= gameObject.consoEnergie;
        prodAgricole -= gameObject.prodAgricole;
        prodEnergie -= gameObject.prodEnergie;
        ecologiepts -= gameObject.ecologie;
        malusEco -= gameObject.malusEco;

        Debug.Log("habitants : " + habitants);

        ComputePourcent();
    }


    private void ComputePourcent(){

        agriculture = 100f*consoAgricole/prodAgricole;
        if(consoAgricole > prodAgricole && !malusAgri){ //surconsommation
            malusSatisfaction += 1;
            malusAgri = true;
        }

        if(consoAgricole < prodAgricole && malusAgri){ //fin de surconsommation
            malusSatisfaction -= 1;
            malusAgri = false;
        }

        energie = 100f*consoEnergie/prodEnergie;
        if(consoEnergie > prodEnergie && !malusEner){ //surconsommation
            malusSatisfaction += 1;
            malusEner = true;
        }

        if(consoEnergie < prodEnergie && malusEner){ //fin de surconsommation
            malusSatisfaction -= 1;
            malusEner = false;
        }



        ecologie = ecologiepts/allObjectsStats.Count(obj => obj.ecologie != 0);

        //satisfaction -> 50% la valeur écologique de la ville et 50% concerne les malus
        satisfaction = ecologie/2 + 50 - 10*(malusEco + malusSatisfaction);
    }

    private void ComputeArgent()
    {
        foreach(ObjectStats gameObject in allObjectsStats)
        {
            if (gameObject.revenu != 0)
            {
                argent += gameObject.revenu;
            }
        }
    }

    public bool checkArgent(float prix)
    {
        return argent >= prix;
    }

    private void RemoveArgent(float montant)
    {
        argent -= montant;
    }

    private void AddArgent(float montant)
    {
        argent += montant;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
