using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Threading.Tasks;
using TMPro;

public class SceneGlobalManager : MonoBehaviour
{
    public static SceneGlobalManager Instance;

   
    public Image progressBar; 
   
    [SerializeField] private TextMeshProUGUI loadingText;
    public string sceneToLoad; 
    private float targetLoad;


    public delegate void SceneLoaded();
    public static event SceneLoaded OnSceneLoaded;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        LoadSceneAsync(); // loadScene
    }
    void Update()
    {
        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, targetLoad, 3 * Time.deltaTime);
    }
    public async void LoadSceneAsync()
    {
        targetLoad = 0;
        progressBar.fillAmount = 0;

        var scene = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive); //aquiiiiiiii
        scene.allowSceneActivation = false;
        do
        {
            await Task.Delay(3000); //100
            targetLoad = scene.progress;
        } while (scene.progress < 0.9f);

        await Task.Delay(1000);

        scene.allowSceneActivation = true;

        OnSceneLoaded?.Invoke(); // Activa el evento cuando la escena se carga.

    }
    public void PlayScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }
    public void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }

}
