using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    int index;
    void Start()
    {
        index = PlayerPrefs.GetInt("JugadorIndex");
        Instantiate(GameManager.Instance.characters[index].characterPref,transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
