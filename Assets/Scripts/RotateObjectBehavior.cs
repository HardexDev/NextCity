using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateObjectBehavior : MonoBehaviour
{
    public float rotationSpeed = 5f;
    private float rotationInput;
    private float smoothRotation;

    public void OnTrigger(InputValue value)
    {
        smoothRotation = Mathf.Lerp(smoothRotation, rotationInput, Time.deltaTime * rotationSpeed);
        transform.Rotate(0f, smoothRotation, 0f);
        Debug.Log("Trigger");
    }
}
