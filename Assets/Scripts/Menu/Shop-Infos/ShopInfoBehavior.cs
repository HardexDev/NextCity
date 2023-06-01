using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInfoBehavior : MonoBehaviour
{
    public List<GameObject> interfaces;

    private bool displayShop = true;

    // Start is called before the first frame update
    void Start()
    {
        interfaces[0].SetActive(true);
        interfaces[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeMod()
    {
        displayShop = !displayShop;

        if(displayShop)
        {
            interfaces[0].SetActive(true);
            interfaces[1].SetActive(false);
        }
        else
        {
            interfaces[0].SetActive(false);
            interfaces[1].SetActive(true);
        }
    }
}
