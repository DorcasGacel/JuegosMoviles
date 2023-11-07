using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuSeleccionPersonaje : MonoBehaviour
{
    private int index;

    [SerializeField] private Image _image;

    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private TextMeshProUGUI totalCoins;

    [SerializeField] private GameObject candado;

    private GameManager GameManager;

    public GameObject selectionPanel;

    public int playerCoins; // La cantidad de monedas del jugador

    // public AnimatorController animator;

    void Start()
    {
        //animator = GetComponent<AnimatorController>();
        //Invoke("LoopAnimation", 2.0f);
       
        candado.SetActive(true);
        Time.timeScale = 0f;
        GameManager = GameManager.Instance;

        index = PlayerPrefs.GetInt("JugadorIndex");

        if(index > GameManager.characters.Count - 1)
        {
            index = 0;
        }

        ChangeScreen();

        GameManager.characters[0].coins = GameManager.characters[index].coins;
        GameManager.characters[1].coins = GameManager.characters[index].coins;
        GameManager.characters[2].coins = GameManager.characters[index].coins;
    }
    /*private void LoopAnimation()
    {
        animator.ReproducirAnimacion();
    }*/
    public void ChangeScreen()
   {
   //PlayerPrefs.SetInt("JugadorIndex", index);
        _image.sprite = GameManager.characters[index].image;
        name.text = GameManager.characters[index].name;
        price.text = GameManager.characters[index].price.ToString();
        totalCoins.text = GameManager.characters[index].coins.ToString();

        if (GameManager.characters[index].coins >= GameManager.characters[index].price)
        {
            candado.SetActive(false);
        }
        else
        {
            candado.SetActive(true);
        }
    }

    public void NextPersonaje()
    {
        if(index == GameManager.characters.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }

        ChangeScreen();
    }
    public void AnteriorPersonaje()
    {
        if (index == 0 )
        {
            index = GameManager.characters.Count - 1;
        }
        else
        {
            index -= 1;
        }

        ChangeScreen();
    }

    //SCENES
    public void IniciarJuego()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void SelectionPanel()
    {
        selectionPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Salí del juego");
    }

    public void BuyItem(PlayerController item)
    {
        if (GameManager.characters[index].coins >= GameManager.characters[index].price)
        {
            // El jugador tiene suficientes monedas para comprar el objeto
            GameManager.characters[index].coins -= item.price;

            // Aquí puedes agregar la lógica para dar al jugador el objeto comprado
            //GameManager.characters[index]; 
            PlayerPrefs.SetInt("JugadorIndex", index);
            //GameManager.characters[index].characterPref;
            //int n = index;
            //itemsForSale[n];
            // si tiene la plata está desbloquada a secas y no hay candado
            //candado.SetActive(false);
            ChangeScreen();
            IniciarJuego();
        }
        else if (GameManager.characters[index].coins < GameManager.characters[index].price)
        {
            // No hay suficientes monedas para comprar el objeto
            Debug.Log("No tienes suficientes monedas.");
            candado.SetActive(true);
        }
    }

}
