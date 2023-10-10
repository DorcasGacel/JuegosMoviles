using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    public Image[] selectBoxes;
    public GameObject[]  atronautasPrefabs;

    void start()
    {
        foreach (var img in this.selectBoxes)
        {
            img.gameObject.SetActive(false);
        }

        this.Select(0);
    }

    public void Select(int index)
    {
        foreach (var img in this.selectBoxes)
        {
            img.gameObject.SetActive(false);
        }

        this.selectBoxes[index].gameObject.SetActive(true);
        PlayerStorage.playerPref = this.atronautasPrefabs[index];
    }

}
