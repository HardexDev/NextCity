using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchModButtonBehavior : MonoBehaviour
{
    public string creativeTexte;
    public string immersionTexte;
    public TMP_Text tmp;
    public SwitchModImageBehavior switchModImage;
    public SwitchModImageBehavior switchShopImage;
    public ShopInfoBehavior shopInterface;
    public GameObject XROrigin;
    public GameObject ImmersionSpawn;
    public List<Component> ComponentsToDisable;

    private Pose old_god_pos;
    private float CamHeightOffset = 1.8f; //offset hauteur des yeux

    // Start is called before the first frame update
    void Start()
    {
        tmp.SetText(immersionTexte);
    }

    // Update is called once per frame
    void Update()
    {
        if(XROrigin.transform.position.y != CamHeightOffset && tmp.text == immersionTexte) //ajout de l'offset de hauteur de cam en mode immersion
        {
            Vector3 newPos = XROrigin.transform.position;
            newPos.y = CamHeightOffset; //ajout d'une hauteur
            XROrigin.transform.position = newPos;
        }

    }

    public void switchMod()
    {
        if(tmp.text == creativeTexte) //passage au godmode
        {
            tmp.SetText(immersionTexte);
            setGod();
        }
        else //passage en mode immersion
        {
            tmp.SetText(creativeTexte);
            setImmersion();
        }
        switchModImage.changeMod();
        switchShopImage.changeMod();
        shopInterface.changeMod();
    }

    private void setImmersion()
    {
        old_god_pos.position = XROrigin.transform.position;
        old_god_pos.rotation = XROrigin.transform.rotation;

        Vector3 newPos = ImmersionSpawn.transform.position;
        newPos.y += CamHeightOffset; //ajout d'une hauteur
        XROrigin.transform.position = newPos;
        XROrigin.transform.rotation = ImmersionSpawn.transform.rotation;
        XRComponent_enabled(false);
        setGrabActivation(false);
    }

    private void setGod()
    {
        old_god_pos.position.y = 28.34f;
        XROrigin.transform.position = old_god_pos.position;
        XROrigin.transform.rotation = old_god_pos.rotation;
        XRComponent_enabled(true);
        setGrabActivation(true);
    }

    private void XRComponent_enabled(bool state)
    {
        foreach(Behaviour c in ComponentsToDisable)
        {
            c.enabled = state;
        }
    }

    private void setGrabActivation(bool state)
    {
        Object[] tempList = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        List<GameObject> realList = new List<GameObject>();
        GameObject temp;

        foreach (Object obj in tempList) //chaque gameobject de la scene
        {
            if (obj is GameObject)
            {
                temp = (GameObject)obj;
                if (temp.tag == "Batiment") //si batiment on active/desactive ce qui permet de grab l'objet
                    temp.GetComponent<XRGrabInteractable>().enabled = state;
            }
        }
    }
}
