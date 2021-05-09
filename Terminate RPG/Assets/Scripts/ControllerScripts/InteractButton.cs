using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    [HideInInspector]
    public bool interactButtonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        interactButtonPressed = true;
        audioSource.PlayOneShot(audioClip);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        interactButtonPressed = false;
    }
}
