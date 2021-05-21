using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class ItemObjects : ScriptableObject
{
    public Sprite ItemSprite;
    public string itemDescription;
    public bool isKey;
}
