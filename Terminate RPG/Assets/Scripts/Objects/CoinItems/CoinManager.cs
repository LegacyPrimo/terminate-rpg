using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public Inventory playerInventory;
    public TextMeshProUGUI coinDisplay;


    public void UpdateCoinCount() 
    {
        coinDisplay.text = "" + playerInventory.totalCoins;
    }
}
