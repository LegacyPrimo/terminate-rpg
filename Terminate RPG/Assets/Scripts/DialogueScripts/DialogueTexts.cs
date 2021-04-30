using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueTexts
{
    public string name;
    
    [TextArea(2,5)]
    public string[] phrases;
}
