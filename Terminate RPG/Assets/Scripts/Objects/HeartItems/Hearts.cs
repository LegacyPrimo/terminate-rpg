using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : PowerUpObjects
{
    public FloatValue playerHealth;
    public FloatValue heartContainers;
    public float amountToAdd;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger) 
        {

            playerHealth.runtimeValue += amountToAdd;
            if (playerHealth.runtimeValue > heartContainers.runtimeValue * 2f) 
            {
                playerHealth.runtimeValue = heartContainers.runtimeValue * 2f;
            }
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }    
    }
    

}
