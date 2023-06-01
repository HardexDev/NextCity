using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButtonBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onQuittingGame()
    {
        StartCoroutine(LoadHomePage());
    }

    IEnumerator LoadHomePage()
    {
        //Load game scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("HomeScene");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
