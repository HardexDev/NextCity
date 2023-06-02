using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RulerBehavior : MonoBehaviour
{
    public GameObject canvas;
    public string newGameSceneName;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onCreatingNewGame()
    {
        StartCoroutine(CreateNewGame());
    }

    public void onContinueGame()
    {

    }

    public void onOpeningParameters()
    {

    }

    IEnumerator CreateNewGame()
    {
        //Load game scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(newGameSceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
