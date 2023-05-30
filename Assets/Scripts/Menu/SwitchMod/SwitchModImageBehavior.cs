using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchModImageBehavior : MonoBehaviour
{
    public List<Sprite> sprites;

    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeMod()
    {
        if (image.sprite == sprites[0])
        {
            image.sprite = sprites[1];
        }
        else
        {
            image.sprite = sprites[0];
        }
    }
}
