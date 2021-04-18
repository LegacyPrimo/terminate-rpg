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
    public FloatValue playerCurrentHealth;

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

    public void UpdateHearts() 
    {
        float temporaryHealth = playerCurrentHealth.runtimeValue / 2;

        for (int i = 0; i < heartContainer.initialValue; i++) 
        {
            if (i <= temporaryHealth -1)
            {
                heartImage[i].sprite = fullHeart;
            }
            else if (i >= temporaryHealth)
            {
                heartImage[i].sprite = emptyHeart;
            }
            else 
            {
                heartImage[i].sprite = halfHeart;
            }
        }
    }
}
