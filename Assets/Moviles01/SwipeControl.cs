using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControl : MonoBehaviour
{
    public GameObject trailRendererObject; 

    private Vector2 swipeStartPos;
    private Vector2 swipeEndPos;
    private float minSwipeDistance = 50f; // Ajusta la distancia mínima para considerar un Swipe.

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    swipeStartPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    swipeEndPos = touch.position;
                    float swipeDistance = Vector2.Distance(swipeStartPos, swipeEndPos);

                    if (swipeDistance >= minSwipeDistance)
                    {
                        // Se ha detectado un Swipe, elimina todos los objetos.
                        EliminateAllObjects();

                        // Activar el Trail 
                        EnableTrailRenderer(touch.position);
                    }
                    break;
            }
        }
    }

    void EliminateAllObjects()
    {
      
        GameObject[] waterObjects = GameObject.FindGameObjectsWithTag("Circle");

        // Elimina cada objeto encontrado.
        foreach (GameObject waterObject in waterObjects)
        {
            Destroy(waterObject);
        }
    }

    void EnableTrailRenderer(Vector2 position)
    {
      
        trailRendererObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, 10));
        trailRendererObject.GetComponent<TrailRenderer>().enabled = true;
    }
}
