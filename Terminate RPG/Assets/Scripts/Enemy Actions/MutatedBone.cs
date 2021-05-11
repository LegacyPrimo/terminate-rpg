using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutatedBone : EnemyScript
{
    public Transform enemyTarget;
    public float moveRadius;
    public float attackRadius;
    public Transform initialPosition;
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private Collider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyTarget = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
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
                animator.SetBool("Walking", true);
                OnTriggerEnter2D(collider2D);
            }

        }
        else if(Vector3.Distance(enemyTarget.position, transform.position) > moveRadius)
        {
            animator.SetBool("Walking", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (rigidbody2D != null) 
            {
                animator.SetBool("Attacking", true);
                currentState = EnemyState.attack;
            }
        }
        else 
        {
            animator.SetBool("Attacking", false);
            currentState = EnemyState.walk;
        }
    }

    private void SetAnimatorFloat(Vector2 setVector) 
    {
        animator.SetFloat("moveX", setVector.x);
        animator.SetFloat("moveY", setVector.y);
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

    private void ChangeState(EnemyState newState) 
    {
        if (currentState != newState) 
        {
            currentState = newState;
        }
    }
}