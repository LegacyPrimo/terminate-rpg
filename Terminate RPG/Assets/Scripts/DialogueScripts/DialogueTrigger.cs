using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueTexts dialogue;

    public void TriggerDialogue() 
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
