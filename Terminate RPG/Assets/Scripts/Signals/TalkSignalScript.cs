using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkSignalScript : MonoBehaviour
{

    public GameObject talkSymbol;


    public void Enable()
    {
        talkSymbol.SetActive(true);
    }
    public void Disable()
    {
        talkSymbol.SetActive(false);
    }
}
