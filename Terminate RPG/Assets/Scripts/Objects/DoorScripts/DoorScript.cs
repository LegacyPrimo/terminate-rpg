using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}
public class DoorScript : InteractionObjectScript
{
    
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D boxCollider2D;

    private void Start()
    {
        
        interact = FindObjectOfType<InteractButton>();
    }
    private void Update()
    {
        if (interact.interactButtonPressed && playerInRange)
        {
            if (thisDoorType == DoorType.key)
            {
                if (playerInventory.totalKeys > 0) 
                {
                    playerInventory.totalKeys--;
                    Open();
                }
            }
            else
            {
                Close();
            }
        }
    }

    public void Open() 
    {
        doorSprite.enabled = false;
        open = true;
        boxCollider2D.enabled = false;
    }

    public void Close() 
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !open)
        {
            contextOn.Raise();
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !open)
        {
            contextOff.Raise();
            playerInRange = false;
        }
    }
}
