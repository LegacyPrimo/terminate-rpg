using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [HideInInspector]
    public bool ButtonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ButtonPressed = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
