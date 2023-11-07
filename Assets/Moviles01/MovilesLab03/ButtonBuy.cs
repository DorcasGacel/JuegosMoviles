using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonBuy : MonoBehaviour
{
    public PlayerController itemToBuy;
    public TextMeshProUGUI coinText;

    public MenuSeleccionPersonaje menuSeleccionPersonaje;

    private void Start()
    {
       int  index = PlayerPrefs.GetInt("JugadorIndex");
        //coinText.text = menuSeleccionPersonaje.playerCoins.ToString(); 
        coinText.text  = GameManager.Instance.characters[index].coins.ToString();
    }

    public void OnBuyButtonClick()
    {
        menuSeleccionPersonaje.BuyItem(itemToBuy);

    }
}
