using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState 
{
    idle,
    walk, 
    attack,
    stagger
}

public class EnemyScript : MonoBehaviour
{
    public EnemyState currentState;
    public string enemyName;
    public int enemyHealth;
    public int baseAttackDamage;
    public float enemySpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
