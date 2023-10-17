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
    public string numTag;
    private void HandleSceneLoaded()
    {
        if (!sceneLoaded)
        {
            DisableUnwantedObjects(numTag);
            sceneLoaded = true;
        }
    }
    void DisableUnwantedObjects(string numero)
    {
        GameObject[] objectsToDisable = GameObject.FindGameObjectsWithTag(numero); // Etiqueta de objetos no deseados 
        foreach (var obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
      
    }

}
