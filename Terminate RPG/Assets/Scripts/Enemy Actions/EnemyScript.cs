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
    public Transform enemyTarget;
    public float moveRadius;
    public float attackRadius;
    public EnemyState currentState;
    public FloatValue maxHealth;
    public string enemyName;
    public float enemyHealth;
    public int baseAttackDamage;
    public float enemySpeed;
    public Vector2 startingPosition;
    public GameObject deathEffect;
    public LootTable thisLoot;


    private void Awake() 
    {
        enemyHealth = maxHealth.initialValue;
    }

    private void OnEnable()
    {
        transform.position = startingPosition;
    }

    private void DamageIntake(float damage) 
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0) 
        {
            DeathEffect();
            MakeLoot();
            this.gameObject.SetActive(false);
        }
    }

    private void DeathEffect() 
    {
        if (deathEffect != null) 
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f); 
        }
    }
    private void MakeLoot() 
    {
        if (thisLoot != null) 
        {
            PowerUpObjects current = thisLoot.lootsPowerUp();
            if (current != null) 
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
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

