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

    private GameManager GameManager;

    public GameObject selectionPanel;

   // public AnimatorController animator;

    void Start()
    {
        //animator = GetComponent<AnimatorController>();
        //Invoke("LoopAnimation", 2.0f);

        Time.timeScale = 0f;
        GameManager = GameManager.Instance;

        index = PlayerPrefs.GetInt("JugadorIndex");

        if(index > GameManager.characters.Count - 1)
        {
            index = 0;
        }

        ChangeScreen();
    }
    /*private void LoopAnimation()
    {
        animator.ReproducirAnimacion();
    }*/
    private void ChangeScreen()
   {
       PlayerPrefs.SetInt("JugadorIndex", index);
        _image.sprite = GameManager.characters[index].image;
        name.text = GameManager.characters[index].name;
        price.text = GameManager.characters[index].price.ToString();
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

}
