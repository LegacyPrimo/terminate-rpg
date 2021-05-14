using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObjectScript : MonoBehaviour
{
    public bool playerInRange;
    public SignalReader contextOn;
    public SignalReader contextOff;
    public InteractButton interact;

    void Start()
    {
        interact = FindObjectOfType<InteractButton>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            contextOn.Raise();
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            contextOff.Raise();
            playerInRange = false;
        }
    }
}
