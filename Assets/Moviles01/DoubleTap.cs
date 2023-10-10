using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTap : MonoBehaviour
{
  
    public LayerMask objectLayer; 
    public GameObject selectedObject;
    private float lastTapTime = 0;
    private float doubleTapTimeThreshold = 0.3f; // tiempo l�mite para un doble toque.

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Lanza un rayo desde la posici�n del toque en direcci�n al mundo.
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero, Mathf.Infinity, objectLayer);

                if (hit.collider != null)
                {
                    // Se encontr� un objeto con collider, verifica si se hizo un doble toque.
                    if (Time.time - lastTapTime <= doubleTapTimeThreshold)
                    {
                        // Se realiz� un doble toque.
                        Destroy(hit.collider.gameObject);
                    }
                    lastTapTime = Time.time;
                }
            }
        }
    }
}
