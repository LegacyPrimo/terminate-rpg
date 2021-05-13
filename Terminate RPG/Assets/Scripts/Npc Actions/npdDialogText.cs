using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npdDialogText : InteractionObjectScript
{
    
    public GameObject dialogBox;
    public Text dialogText;
    public InteractButton interact;
    public string dialog;



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
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            contextOff.Raise();
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
