using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackEffect : MonoBehaviour
{
    public float pushForce;
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            Rigidbody2D enemyCharacter = collision.GetComponent<Rigidbody2D>();
            if (enemyCharacter != null) 
            {
                enemyCharacter.isKinematic = false;
                Vector2 positionGap = enemyCharacter.transform.position - transform.position;
                positionGap = positionGap.normalized * pushForce;
                enemyCharacter.AddForce(positionGap, ForceMode2D.Impulse);
                StartCoroutine(KnockCoRoutine(enemyCharacter));
            }
        }
    }

    private IEnumerator KnockCoRoutine(Rigidbody2D enemyEffect) 
    {
        if (enemyEffect) 
        {
            yield return new WaitForSeconds(knockTime);
            enemyEffect.velocity = Vector2.zero;
            enemyEffect.isKinematic = true;
        }
    }
}
