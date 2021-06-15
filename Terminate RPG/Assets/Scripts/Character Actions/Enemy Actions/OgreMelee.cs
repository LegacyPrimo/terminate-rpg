using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreMelee : EnemyScript 
{
    public Animator animator;
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyTarget = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(enemyTarget.position, transform.position) <= moveRadius
            && Vector3.Distance(enemyTarget.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temporary = Vector3.MoveTowards(transform.position, enemyTarget.position, enemySpeed * Time.deltaTime);
                ChangeAnimation(temporary - transform.position);
                rigidbody2D.MovePosition(temporary);
                ChangeState(EnemyState.walk);
            }

        }
        else if (Vector3.Distance(enemyTarget.position, transform.position) <= moveRadius
            && Vector3.Distance(enemyTarget.position, transform.position) <= attackRadius) 
        {
            if (currentState == EnemyState.walk && currentState != EnemyState.stagger) 
            {
                StartCoroutine(AttackCoroutine());
            }
                
        }
    }

    public IEnumerator AttackCoroutine() 
    {
        currentState = EnemyState.attack;
        animator.SetBool("attack", true);
        yield return new WaitForSeconds(1f);
        currentState = EnemyState.walk;
        animator.SetBool("attack", false);
    }

    private void ChangeAnimation(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimatorFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimatorFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimatorFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimatorFloat(Vector2.down);
            }
        }
    }

    private void SetAnimatorFloat(Vector2 setVector)
    {
        animator.SetFloat("moveX", setVector.x);
        animator.SetFloat("moveY", setVector.y);
    }

    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
