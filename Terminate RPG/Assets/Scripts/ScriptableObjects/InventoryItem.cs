using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]
[System.Serializable]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public int numberHeld;
    public bool usableItem;
    public bool uniqueItem;
    public UnityEvent thisEvent;

    public void Use() 
    {
        thisEvent.Invoke();
    }

    public void DecreaseAmount(int amountToDecrease) 
    {
        numberHeld-= amountToDecrease;
        if (numberHeld < 0) 
        {
            numberHeld = 0;
        }
    }
}
