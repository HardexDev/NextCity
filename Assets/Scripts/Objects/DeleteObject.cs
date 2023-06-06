using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DeleteObject : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    public InputActionProperty actionProperty;
    public EngineScript engineScript;

    private bool isHovered = false;

    private void Awake()
    {
        // Get a reference to the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Register event callbacks
        grabInteractable.hoverEntered.AddListener(OnGrab);
        grabInteractable.hoverExited.AddListener(OnRelease);
    }

    private void OnGrab(HoverEnterEventArgs args)
    {
        isHovered = true;
    }

    private void OnRelease(HoverExitEventArgs args)
    {
        isHovered = false;
    }

    private void Update()
    {
        if (isHovered)
        {
            float isDeleteButtonPressed = actionProperty.action.ReadValue<float>();
            if (isDeleteButtonPressed == 1)
            {
                Destroy(gameObject);
                if (engineScript != null)
                {
                    engineScript.RemoveGameObject(gameObject.GetComponent<ObjectStats>());
                }
            }
        }
    }
}
