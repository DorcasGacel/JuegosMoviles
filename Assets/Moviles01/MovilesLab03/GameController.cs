using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController player;
    private float tiempoEntrePuntos = 1.0f;
    public TMP_Text scoreText;

    public TMP_Text coinText;

    public TMP_Text scoreTextGame;
    public TMP_Text LifeText;
    private GameManager GameManager; //********

     int index;
    public GameObject gameOverPanel;
    public GameObject gameLevelPanel;

    int score;
    int life;

    bool isPlay;

    void Start()
    {

        gameOverPanel.SetActive(false);
        GameManager = GameManager.Instance;
   
        index = PlayerPrefs.GetInt("JugadorIndex");

        InvokeRepeating("AddScore", tiempoEntrePuntos, tiempoEntrePuntos);

        InvokeRepeating("AddCoins", 3.0f, 3.0f);

        // Recuperar el puntaje guardado en PlayerPrefs
        score = PlayerPrefs.GetInt("Score");

        // Recuperar la vida guardada en PlayerPrefs
        life = PlayerPrefs.GetInt("Life");
        // Mostrar el puntaje en el texto del panel de Game Over
        scoreTextGame.text = "Score: " + score; 

        scoreText.text = "Score: " + score; 
     
        LifeText.text = "Life: " + life;  

        // Limpia el puntaje guardado en PlayerPrefs (si es necesario)
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.Save();

    }
    void Update()
    {
        if (GameManager.characters[index].life > 0)
        {
            LifeText.text = "Life : " + GameManager.characters[index].life;
            gameOverPanel.SetActive(false);
        }
        if (GameManager.characters[index].life <= 0)
        {
            Debug.Log("Game Over AAAAA");

            Time.timeScale = 0f; // Pausar el juego
            isPlay = false;
            gameOverPanel.SetActive(true);

        }
    }

    private void AddScore()
    {
        GameManager.characters[index].score++;
        
        scoreText.text = "Score : " + GameManager.characters[index].score;
        scoreTextGame.text = "Score : " + GameManager.characters[index].score;
    }
    private void AddCoins()
    {
        //Coins
        GameManager.characters[index].coins++;
        coinText.text = "Coins : " + GameManager.characters[index].coins;
    }
    public void LifeMenos()
    {
        if (GameManager.characters[index].life > 0)
        {
            LifeText.text = "Life : " + GameManager.characters[index].life;
        }
        if (GameManager.characters[index].life <= 0)
        {
            Debug.Log("Game Over AAAAA");

            Time.timeScale = 0f; 
            gameOverPanel.SetActive(true);

        }
    }

    public void RestartGame()
    {
        Debug.Log("Restart Game");
        SceneManager.LoadScene("MovilesLab01");
        Time.timeScale = 1f; // Reanudar el juego
    }

    // Método para cargar la escena del menú principal
    public void CargarMenuPrincipal()
    {
        SceneManager.LoadScene("SpaceMenu");
    }
    //Pausar Juego
    private bool juegoPausado = false;
    public void TogglePausa()
    {
        juegoPausado = !juegoPausado;
        if (juegoPausado)
        {
            Time.timeScale = 0f;
            juegoPausado = false;
        }
        else
        {
            Time.timeScale = 1f; 

        }
    }
    // Método para continuar el juego
    public void ContinuarJuego()
    {
        juegoPausado = false;
        Time.timeScale = 1f; // Reanuda el tiempo en el juego
    }

   
}
