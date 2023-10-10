using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleTap : MonoBehaviour
{

    public ComponentsSO simpleShape;

    GameObject shapePrefab;

    bool canCreateShape = true;

    private void Update()
    {
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Convierte la posición del toque a coordenadas del mundo.
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;

                 Instantiate(shapePrefab, touchPosition, Quaternion.identity);

            }
        }
    }

    public void OnButtonClick(string buttonName)
    {
        DisableShapeCreation();
        if (buttonName == "Circle")
        {
            shapePrefab = simpleShape.circlePrefab;
        }
        else if (buttonName == "Square")
        {
            shapePrefab = simpleShape.squarePrefab;
        }
        else if (buttonName == "Triangle")
        {
            shapePrefab = simpleShape.tiangulePrefab;
        }
        EnableShapeCreation();
    }

    public void CreateShapeRed()
    {
        SpriteRenderer spriteRenderer = shapePrefab.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = simpleShape.redColor;
        }

        canCreateShape = true;
    }

    public void CreateShapeGreen()
    {
        SpriteRenderer spriteRenderer = shapePrefab.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = simpleShape.greenColor;
        }

        canCreateShape = true;
    }

    public void CreateShapeBlue()
    {
        
        SpriteRenderer spriteRenderer = shapePrefab.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = simpleShape.blueColor;
        }
    }
   
   public void EnableShapeCreation()
   {
        canCreateShape = true;
   }

    public void DisableShapeCreation()
    {
        canCreateShape = false;
    }

}





