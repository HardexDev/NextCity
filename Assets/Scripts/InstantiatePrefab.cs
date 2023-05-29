using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InstantiatePrefab : MonoBehaviour, IPointerClickHandler
{
    public GameObject prefabToInstanciate;
    public float yCoordinates;
    public Camera playerCamera;
    public Vector3 rotation = Vector3.zero;

    public void OnPointerClick(PointerEventData eventData)
    {
        Instantiate(prefabToInstanciate, new Vector3(playerCamera.transform.position.x + 5f, yCoordinates, playerCamera.transform.position.z + 5f), Quaternion.Euler(rotation));
    }
}
