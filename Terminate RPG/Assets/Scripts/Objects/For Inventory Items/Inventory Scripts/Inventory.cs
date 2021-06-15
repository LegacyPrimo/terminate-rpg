using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Inventory : ScriptableObject
{
    public ItemObjects currentItem;
    public List<ItemObjects> items = new List<ItemObjects>();
    public int totalKeys;
    public int totalCoins;
    public float maxBullet = 10;
    public float currentBullet;

    
    public void OnEnable()
    {
        currentBullet = maxBullet;   
    }

    public void ReduceBullets(float bulletCost) 
    {
        currentBullet -= bulletCost;
    }

    public bool CheckForItem(ItemObjects itemObjects) 
    {
        if (items.Contains(itemObjects)) 
        {
            return true;
        }
        
        return false;
    }

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
