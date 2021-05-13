using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public ItemObjects currentItem;
    public List<ItemObjects> items = new List<ItemObjects>();
    public int totalKeys;

    public void AddItem(ItemObjects itemToAdd) 
    {
        if (itemToAdd.isKey)
        {
            totalKeys++;
        }
        else 
        {
            if (!items.Contains(itemToAdd)) 
            {
                items.Add(itemToAdd);
            }
        }
    }
}
