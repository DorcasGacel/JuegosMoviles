using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMovement : MonoBehaviour
{
    public float velocidadVertical;
    private BalaManager objectPool;
    [SerializeField] PlayerController playerC;
    private Vector3 startPosition;
    public float distanciaMaxima = 10.0f; // Establece la distancia máxima a la que la bala permanecerá activa
    void Start()
    {
        // Guarda la posición de inicio de la bala
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(velocidadVertical * Time.deltaTime, 0, 0);

        // Calcula la distancia entre la posición actual y la posición de inicio
        float distancia = Vector2.Distance(transform.position, startPosition);

        // Si la distancia supera la distancia máxima, desactiva la bala
        if (distancia > distanciaMaxima)
        {
            gameObject.SetActive(false);
        }
    }
    public void InitVariables()
    {
        velocidadVertical = 2.0f;
    }
    public void SetObjectPool(BalaManager pool)
    {
        objectPool = pool;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (other.gameObject.layer == "Crater")
         if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            playerC.score = playerC.score + 4;
            // Desactiva la bala o la devuelve al Object Pool
            gameObject.SetActive(false);
        }
    }
}
