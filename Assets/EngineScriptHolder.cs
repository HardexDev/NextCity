using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineScriptHolder : MonoBehaviour
{
    private static EngineScriptHolder instance;
    public EngineScript sharedEngineScript;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public static EngineScriptHolder Instance
    {
        get { return instance; }
    }
}
