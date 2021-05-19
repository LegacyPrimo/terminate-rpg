using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceRefillPowerup : PowerUpObjects
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
