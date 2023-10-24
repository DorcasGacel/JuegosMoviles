using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBuy : MonoBehaviour
{
    public PlayerController itemToBuy;
    public Text coinText;
    public ShopManager shopManager;

    private void Start()
    {
        coinText.text = shopManager.playerCoins.ToString();
    }

    public void OnBuyButtonClick()
    {
        shopManager.BuyItem(itemToBuy);
        coinText.text = shopManager.playerCoins.ToString();
    }
}
