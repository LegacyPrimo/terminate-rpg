using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManagement : MonoBehaviour
{
    public Image[] heartImage;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainer;

    // Start is called before the first frame update
    void Start()
    {
        InitializeHearts();   
    }

    public void InitializeHearts() 
    {
        for (int i = 0; i < heartContainer.initialValue; i++) 
        {
            heartImage[i].gameObject.SetActive(true);
            heartImage[i].sprite = fullHeart;
        }
    }
}
