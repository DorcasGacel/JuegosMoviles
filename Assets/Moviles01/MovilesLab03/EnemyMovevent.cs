using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovevent : MonoBehaviour
{
    Camera mainCamera;
    float screenHeight;

    public float velocidadVertical = -2.0f; 
    private void Awake()
    {
        Camera mainCamera = Camera.main;
        screenHeight = mainCamera.orthographicSize * 2;
    }
    private void Update()
    {
        transform.Translate(velocidadVertical * Time.deltaTime, 0, 0);

        // Verifica si el enemigo ha salido de los límites de la pantalla
        if (transform.position.x < -13)
        {
            gameObject.SetActive(false); // Desactivar enemigo
        }
    }
}
