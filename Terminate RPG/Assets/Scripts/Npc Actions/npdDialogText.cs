using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npdDialogText : InteractionObjectScript
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public InteractButton interact;

    // Start is called before the first frame update
    void Start()
    {
        interact = FindObjectOfType<InteractButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interact.interactButtonPressed && playerInRange) 
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else 
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            talkSymbolOff.Raise();
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
