using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaManager : MonoBehaviour
{
     
    public List<GameObject> objectPool;

    public GameObject balaPrefab;


    public float fireRate = 0.2f;
    private Transform playerTransform;
    private float nextFireTime;

    private void Start()
    {
        playerTransform = transform;
    }
    public void GetBullet()
    {
        GameObject tmp;
        if (objectPool.Count > 0)
        {
            tmp = objectPool[0];
            objectPool.Remove(tmp);
            tmp.SetActive(true);
            tmp.GetComponent<BalaMovement>().InitVariables();
        }
        else
        {
            tmp = Instantiate(balaPrefab, transform.position, playerTransform.rotation);
            tmp.GetComponent<BalaMovement>().SetObjectPool(this);
            tmp.GetComponent<BalaMovement>().InitVariables();
            tmp.transform.SetParent(this.transform);
            tmp.SetActive(true);
        }

    }
    public void SetObject(GameObject obj)
    {
        objectPool.Add(obj);
    }
    private void Update()
    {
        // Disparar balas cuando se mantenga presionada la pantalla (simulación del comado Hold :))
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Debug.Log("Disparé");
            GetBullet();
            nextFireTime = Time.time + fireRate;
        }
    }
}
