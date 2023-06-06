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

    private float argentInterval = 5f;

    void Start()
    {
        List<GameObject> allGameObjects = GameObject.FindGameObjectsWithTag("Batiment").ToList();
        foreach (GameObject gameObject in allGameObjects)
        {
            allObjectsStats.Add(gameObject.GetComponent<ObjectStats>());
        }
        InvokeRepeating("ComputeArgent", 1f, argentInterval);
    }

    public void AddGameObject(ObjectStats gameObject)
    {
        allObjectsStats.Add(gameObject);
        RemoveArgent(gameObject.cout);
    }

    public void RemoveGameObject(ObjectStats gameObject)
    {
        allObjectsStats.RemoveAll(gObject => gObject.GetInstanceID() == gameObject.GetInstanceID());
        AddArgent(gameObject.cout/2);
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
