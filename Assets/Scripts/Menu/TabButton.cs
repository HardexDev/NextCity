using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TabButton : MonoBehaviour, IPointerClickHandler
{
    public TabGroup tabGroup;

    public Color idleColor;
    public Color selectedColor;

    public Image image;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }

    public void resetButton()
    {
        image.color = idleColor;
    }

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        tabGroup.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}