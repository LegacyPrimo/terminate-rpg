using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackEffect : MonoBehaviour
{
    public float pushForce;
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PotBreaking") && this.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<ObjectBreak>().SmashObject();
        } 

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player")) 
        {
            Rigidbody2D hitObject = collision.GetComponent<Rigidbody2D>();

            if (hitObject != null) 
            {
                Vector2 positionGap = hitObject.transform.position - transform.position;
                positionGap = positionGap.normalized * pushForce;
                hitObject.AddForce(positionGap, ForceMode2D.Impulse);

                if (collision.gameObject.CompareTag("Enemy")) 
                {
                    hitObject.GetComponent<EnemyScript>().currentState = EnemyState.stagger;
                    collision.GetComponent<EnemyScript>().KnockbackEffect(hitObject, knockTime);
                }

                if (collision.gameObject.CompareTag("Player")) 
                {
                    hitObject.GetComponent<PlayerMovement>().currentstate = PlayerState.stagger;
                    collision.GetComponent<PlayerMovement>().Knock(knockTime);
                }
                
            }
        }
    }
}
