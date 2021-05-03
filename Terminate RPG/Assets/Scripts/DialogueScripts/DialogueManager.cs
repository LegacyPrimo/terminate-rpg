using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text phraseDialogue;
    private Queue<string> dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText = new Queue<string>();
    }

    public void StartDialogue(DialogueTexts dialogue) 
    {
        nameText.text = dialogue.name;
        dialogueText.Clear();

        foreach (string sentence in dialogue.phrases) 
        {
            dialogueText.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() 
    {
        if (dialogueText.Count == 0) 
        {
            EndDialogue();
            return;
        }
        string textPhrase = dialogueText.Dequeue();
        phraseDialogue.text = textPhrase;
    }

    public void EndDialogue() 
    {

    }
}
