using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlNpcScript : npdDialogText
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D()
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
}
