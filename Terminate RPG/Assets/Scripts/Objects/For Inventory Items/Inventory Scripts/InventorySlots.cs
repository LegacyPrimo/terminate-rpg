using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour
{
    [SerializeField] private Text itemNumberText;
    [SerializeField] private Image itemImage;
    
    public InventoryItem thisItem;
    public InventoryManager thisManager;

    public void Setup(InventoryItem newItem, InventoryManager newManager) 
    {
        thisItem = newItem;
        thisManager = newManager;
        if (thisItem) 
        {
            itemImage.sprite = thisItem.itemImage;
            itemNumberText.text = "" + thisItem.numberHeld;
        }
    }

    public void ClickedOn() 
    {
        if (thisItem) 
        {
            thisManager.SetupDescriptionAndButton(thisItem.itemDescription, thisItem.usableItem, thisItem);

        }
    }

}
