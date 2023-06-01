using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchModButtonBehavior : MonoBehaviour
{
    public string creativeTexte;
    public string immersionTexte;
    public TMP_Text tmp;
    public SwitchModImageBehavior switchModImage;
    public SwitchModImageBehavior switchShopImage;
    public ShopInfoBehavior shopInterface;

    // Start is called before the first frame update
    void Start()
    {
        tmp.SetText(immersionTexte);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchMod()
    {
        if(tmp.text == creativeTexte)
        {
            tmp.SetText(immersionTexte);
        }
        else
        {
            tmp.SetText(creativeTexte);
        }
        switchModImage.changeMod();
        switchShopImage.changeMod();
        shopInterface.changeMod();
    }
}
