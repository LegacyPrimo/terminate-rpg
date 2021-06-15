using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItem thisItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.isTrigger) 
        {
            AddItemToInventory();
            Destroy(this.gameObject);
        }
    }

    void AddItemToInventory() 
    {
        if (playerInventory && thisItem) 
        {
            if (playerInventory.items.Contains(thisItem))
            {
                thisItem.numberHeld++;
            }
            else 
            {
                playerInventory.items.Add(thisItem);
                thisItem.numberHeld += 1;
            }
        }
    }
}
