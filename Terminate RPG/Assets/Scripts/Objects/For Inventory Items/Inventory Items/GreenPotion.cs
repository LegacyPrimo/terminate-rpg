using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPotion : MonoBehaviour
{
    public FloatValue playerBullet;
    public SignalReader bulletSignal;

    public void Use(int amountToIncrease) 
    {
        playerBullet.runtimeValue += amountToIncrease;
        bulletSignal.Raise();
    }
}
