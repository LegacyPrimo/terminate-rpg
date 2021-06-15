using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletManager : MonoBehaviour
{
    public Slider bulletSlider;
    public Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        bulletSlider.maxValue = playerInventory.maxBullet;
        bulletSlider.value = playerInventory.maxBullet;
        playerInventory.currentBullet = playerInventory.maxBullet;
    }

    public void IncreaseBullet() 
    {
        bulletSlider.value = playerInventory.currentBullet;
        if (bulletSlider.value > bulletSlider.maxValue) 
        {
            bulletSlider.value = bulletSlider.maxValue;
            playerInventory.currentBullet = playerInventory.maxBullet; 
        }
    }

    public void DecreaseBullet() 
    {
        bulletSlider.value = playerInventory.currentBullet;
        if (bulletSlider.value < 0) 
        {
            bulletSlider.value = 0;
            playerInventory.currentBullet = 0;
        }
    }
}
