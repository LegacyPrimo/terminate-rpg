using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText = new Queue<string>();
    }

    public void StartDialogue(DialogueTexts dialogue) 
    {

    }
}
