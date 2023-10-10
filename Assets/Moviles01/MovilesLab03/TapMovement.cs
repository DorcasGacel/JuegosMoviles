using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TapMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5.0f; 
    private Transform player;
    [SerializeField] PlayerController playerC;

    int index;
    private GameManager GameManager;
 
    void Start()
    {
         GameManager = GameManager.Instance;
         index = PlayerPrefs.GetInt("JugadorIndex");

        player = GetComponent<Transform>();

        rb = GetComponent<Rigidbody2D>(); //***************

        Time.timeScale = 1f; // Reanudar el juego

        GameManager.characters[index].score = 0;
        GameManager.characters[index].life = 3;
        GameManager.characters[index].life = 4;
        GameManager.characters[index].life = 5;
    }

    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Convierte la posición del toque a coordenadas del mundo.
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;
                touchPosition.x = -7.26f;

                player.position = touchPosition;            
            }
        }

        //Acelerómetro
      /*
        Vector3 acceleration = Input.acceleration;

        // Mueve la nave en función de los datos del acelerómetro
        Vector2 movement = new Vector2(acceleration.x, 0);
        rb.velocity = movement * speed; */
    }

    // COLISIONES :)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(GameManager.characters[index].life + " :)");

        if (collision.CompareTag("Enemy") && GameManager.characters[index].life > 0) 
        {

            GameManager.characters[index].life--;
            Debug.Log("Game Over 1ro ");
            collision.gameObject.SetActive(false);

            if (GameManager.characters[index].life <= 0)
            {
                Debug.Log("Game Over 2do");
                
                Time.timeScale = 0f; // Pausar el juego

                this.gameObject.SetActive(false); 

                PlayerPrefs.SetInt("Score", GameManager.characters[index].score); 
                PlayerPrefs.Save(); // Guardar los cambios en PlayerPrefs

                PlayerPrefs.SetInt("Life", GameManager.characters[index].life);
                PlayerPrefs.Save(); 

            }
        }
       
    }

}
