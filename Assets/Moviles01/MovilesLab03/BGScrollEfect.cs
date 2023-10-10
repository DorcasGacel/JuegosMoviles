using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrollEfect : MonoBehaviour
{
    public float speed = 3f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime); 

        if(transform.position.x < - 22.0f)
        {
            transform.position = startPosition;
        }
    } 
}
