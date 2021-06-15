using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceRefillPowerup : PowerUpObjects
{

    public Inventory playerInventory;
    public float bulletValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            playerInventory.currentBullet += bulletValue;
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
