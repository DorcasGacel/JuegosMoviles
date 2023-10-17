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
      
    }

    private void HandleSceneLoaded()
    {
        if (!sceneLoaded)
        {
            //SceneGlobalManager.Instance.PlayScene("LoadScene");
            DisableUnwantedObjects();
            sceneLoaded = true;
        }
    }
    void DisableUnwantedObjects()
    {
        GameObject[] objectsToDisable = GameObject.FindGameObjectsWithTag("1"); // Etiqueta de objetos no deseados 
        foreach (var obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
    }

}
