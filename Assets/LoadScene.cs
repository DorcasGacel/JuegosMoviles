using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadScene : MonoBehaviour
{

    
    void start()
    {
   
    }

    public void RestartGame()
    {
        Debug.Log("Restart Game"); 
        SceneManager.LoadScene("MovilesLab01"); 
    }
}
