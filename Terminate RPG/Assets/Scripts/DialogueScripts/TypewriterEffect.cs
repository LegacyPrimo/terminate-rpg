using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypewriterEffect : MonoBehaviour
{
    public float textSpeed = 0.1f;
    [TextArea(5,10)]
    public string fullText;
    private string currentText = "";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowTextSpeed());
    }

    IEnumerator ShowTextSpeed() 
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0,i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
