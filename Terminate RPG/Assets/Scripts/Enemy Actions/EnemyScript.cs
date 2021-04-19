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
    public FloatValue maxHealth;
    public string enemyName;
    public float enemyHealth;
    public int baseAttackDamage;
    public float enemySpeed;

    private void Awake() 
    {
        enemyHealth = maxHealth.initialValue;
    }

    private void DamageIntake(float damage) 
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0) 
        {
            this.gameObject.SetActive(false);
        }
    }

    public void KnockbackEffect(Rigidbody2D rigidbody2D, float knockTime, float damageTaken) 
    {
        StartCoroutine(KnockCoRoutine(rigidbody2D, knockTime));
        DamageIntake(damageTaken);
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

