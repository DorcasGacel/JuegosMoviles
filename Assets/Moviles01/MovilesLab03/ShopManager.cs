using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public int playerCoins; // La cantidad de monedas del jugador
    public PlayerController[] itemsForSale; // Lista de objetos disponibles para comprar

    public void BuyItem(PlayerController item)
    {
        if (playerCoins >= item.price)
        {
            // El jugador tiene suficientes monedas para comprar el objeto
            playerCoins -= item.price;
            // Aquí puedes agregar la lógica para dar al jugador el objeto comprado
        }
        else
        {
            // No hay suficientes monedas para comprar el objeto
            Debug.Log("No tienes suficientes monedas.");
        }
    }
}
