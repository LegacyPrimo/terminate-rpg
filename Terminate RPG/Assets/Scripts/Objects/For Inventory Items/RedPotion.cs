using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotion : MonoBehaviour
{
    public FloatValue playerHealth;
    public SignalReader healthSignal;

    public void Use(int amountToIncrease)
    {
        playerHealth.runtimeValue += amountToIncrease;
        healthSignal.Raise();
    }
}
