using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : EnemyScript
{
    public Transform enemyTarget;
    public float moveRadius;
    public float attackRadius;
    public Transform initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        enemyTarget = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance() 
    {
        if (Vector2.Distance(enemyTarget.position, transform.position) <= moveRadius 
            && Vector2.Distance(enemyTarget.position, transform.position) > attackRadius) 
        {
            transform.position = Vector2.MoveTowards(transform.position, enemyTarget.position, enemySpeed * Time.deltaTime);
        }
    }
}
