using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentBackgroundBehavior : MonoBehaviour
{
    public List<Color> colors;

    private Image image; 

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeColor(int chosenColor)
    {
        image.color = colors[chosenColor];
    }
}
