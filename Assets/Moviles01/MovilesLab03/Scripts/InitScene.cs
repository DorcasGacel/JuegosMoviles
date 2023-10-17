using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScene : MonoBehaviour
{
    private bool sceneLoaded = false;

    private void OnEnable()
    {
        SceneGlobalManager.OnSceneLoaded += HandleSceneLoaded;
    }

    private void OnDisable()
    {
        SceneGlobalManager.OnSceneLoaded -= HandleSceneLoaded;
    }

    void Start()
    {
        // No cargues la escena aquí.
    }

    private void HandleSceneLoaded()
    {
        if (!sceneLoaded)
        {
            SceneGlobalManager.Instance.PlayScene("LoadScene");
            sceneLoaded = true;
        }
    }

}
