using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public bool interactButtonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        interactButtonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        interactButtonPressed = false; 
    }
}
