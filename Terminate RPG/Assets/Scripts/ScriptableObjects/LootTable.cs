using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Loot 
{
    public PowerUpObjects thisLoot;
    public int lootChance;
}

[CreateAssetMenu]
public class LootTable : ScriptableObject
{
    public Loot[] loots;

    public PowerUpObjects lootsPowerUp() 
    {
        int cumulativeProbability = 0;
        int currentProbability = Random.RandomRange(0,100);
        for (int i = 0; i < loots.Length; i++) 
        {
            cumulativeProbability += loots[i].lootChance;
            if (currentProbability <= cumulativeProbability) 
            {
                return loots[i].thisLoot;
            }
        }
        return null;
    }
}
