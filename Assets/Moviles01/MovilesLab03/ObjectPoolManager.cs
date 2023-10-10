using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int poolSize = 10;
    public float spawnRate = 3.0f; 
    public float minYSpawn = -5.0f;
    public float maxYSpawn = 5.0f;

    private List<GameObject> objectPool;

    private void Start()
    {
        objectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            objectPool.Add(enemy);
        }
        InvokeRepeating("RespawnEnemy", 0f, spawnRate);
    }

    private void Update()
    {
    }

   
    private void RespawnEnemy()
    {
        foreach (var enemy in objectPool)
        {
            if (!enemy.activeInHierarchy)
            {
                // Coloca al enemigo en una posición inicial
                enemy.transform.position = new Vector3(transform.position.x, Random.Range(minYSpawn, maxYSpawn), 0f);
                enemy.SetActive(true);
                break; // Solo activa un enemigo a la vez
            }
        }
    }
}
