using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAndDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // ****  Comprobar si se ha tocado un objeto y configurar el arrastre 
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);

                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject == gameObject)
                        {
                            isDragging = true;
                            offset = transform.position - Camera.main.ScreenToWorldPoint(touch.position);
                        }
                    }
                    break;

                case TouchPhase.Moved:
                  
                    if (isDragging)
                    {
                        Vector3 newPosition = Camera.main.ScreenToWorldPoint(touch.position) + offset;
                        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
                    }
                    break;

                case TouchPhase.Ended:
                    // Finalizar el arrastre :)
                    isDragging = false;
                    break;
            }
        }
    }
}
