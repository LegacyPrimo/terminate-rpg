using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObjectScript : MonoBehaviour
{
    public bool playerInRange;
    public SignalReader talkSymbolOn;
    public SignalReader talkSymbolOff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            talkSymbolOn.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            talkSymbolOff.Raise();
            playerInRange = false;
            
        }
    }
}
