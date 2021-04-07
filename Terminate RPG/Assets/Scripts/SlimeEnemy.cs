using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : EnemyScript
{
    public Transform enemyTarget;
    public float moveRadius;
    public float attackRadius;
    public Transform initialPosition;
    private Animator animator;
    private Rigidbody2D rigidbody2D;

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
                rigidbody2D.MovePosition(temporary);
                ChangeState(EnemyState.walk);
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
