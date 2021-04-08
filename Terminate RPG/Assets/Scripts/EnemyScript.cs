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

    public void KnockbackEffect(Rigidbody2D rigidbody2D, float knockTime) 
    {
        StartCoroutine(KnockCoRoutine(rigidbody2D, knockTime));
    }

    private IEnumerator KnockCoRoutine(Rigidbody2D rigidbody2D, float knockTime)
    {
        if (rigidbody2D != null)
        {
            yield return new WaitForSeconds(knockTime);
            rigidbody2D.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}

