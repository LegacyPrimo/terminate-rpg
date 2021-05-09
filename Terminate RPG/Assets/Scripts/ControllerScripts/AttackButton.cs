using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    [HideInInspector]
    public bool ButtonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonPressed = true;
        audioSource.PlayOneShot(audioClip);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ButtonPressed = false;
    }

}
