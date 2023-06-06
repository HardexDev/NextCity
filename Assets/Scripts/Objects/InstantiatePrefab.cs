using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InstantiatePrefab : MonoBehaviour, IPointerClickHandler
{
    public GameObject prefabToInstanciate;
    public float yCoordinates;
    public Camera playerCamera;
    public Vector3 rotation = Vector3.zero;

    public EngineScript engineScript;
    public ObjectStats stats;
    public GameObject textSoldeInsuffisantGameObject;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (engineScript != null && stats != null)
        {
            if (engineScript.checkArgent(stats.cout))
            {
                Instantiate(prefabToInstanciate, new Vector3(playerCamera.transform.position.x + 5f, yCoordinates, playerCamera.transform.position.z + 5f), Quaternion.Euler(rotation));
                engineScript.AddGameObject(stats);
            } else
            {
                textSoldeInsuffisantGameObject.SetActive(true);
                StartCoroutine(WaitCoroutine());
            }
        }
    }

    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(5f);
        textSoldeInsuffisantGameObject.SetActive(false);
    }
}
