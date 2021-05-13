using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : InteractionObjectScript
{
    public ItemObjects content;
    public bool isOpen;
    public Inventory playerInventory;
    public SignalReader raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    public InteractButton interact;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        interact = FindObjectOfType<InteractButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interact.interactButtonPressed && playerInRange)
        {
            if (!isOpen)
            {
                OpenChest();
            }
            else
            {
                ChestIsOpened();
            }
        }
    }

    public void OpenChest() 
    {
        dialogBox.SetActive(true);
        dialogText.text = content.itemDescription;
        playerInventory.AddItem(content);
        playerInventory.currentItem = content;
        raiseItem.Raise();
        contextOff.Raise();
        isOpen = true;
        animator.SetBool("ChestOpened", true);
    }

    public void ChestIsOpened() 
    {
            dialogBox.SetActive(false);
            raiseItem.Raise();
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            contextOn.Raise();
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
        {
            contextOff.Raise();
            playerInRange = false;
        }
    }
}
