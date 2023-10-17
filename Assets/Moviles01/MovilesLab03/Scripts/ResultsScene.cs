using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Threading.Tasks;

public class ResultsScene : InitScene
{
    /* public string sceneToLoad;
     void Start()
     {
         //SceneGlobalManager.Instance.PlayScene("GameOver");
         LoadSceneAsync();
         DisableUnwantedObjects();
     }


     public async void LoadSceneAsync()
     {
         var scene = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive); //aquiiiiiiii
         scene.allowSceneActivation = false;

         scene.allowSceneActivation = true;

     }

     void DisableUnwantedObjects()
     {
         GameObject[] objectsToDisable = GameObject.FindGameObjectsWithTag("2"); // Etiqueta de objetos no deseados 
         foreach (var obj in objectsToDisable)
         {
             obj.SetActive(false);
         }
     }*/
    public GameObject canvasGame;
    public GameObject camera;
    public GameObject AudioManager;

    void Start()
    {
        SceneGlobalManager.Instance.PlayScene("MovilesLab01");

        DisableObjects();

        //DisableUnwantedObjects();
    }
    void DisableObjects()
    {
        canvasGame.SetActive(false);
        camera.SetActive(false);
        AudioManager.SetActive(false);
    }


}
