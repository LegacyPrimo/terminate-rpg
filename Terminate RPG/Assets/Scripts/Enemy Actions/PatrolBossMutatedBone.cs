using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBossMutatedBone : MutatedBone
{
    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundDistance;

    public override void CheckDistance()
    {
        if (Vector3.Distance(enemyTarget.position, transform.position) <= moveRadius
            && Vector3.Distance(enemyTarget.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temporary = Vector3.MoveTowards(transform.position, enemyTarget.position, enemySpeed * Time.deltaTime);
                ChangeAnimation(temporary - transform.position);
                rigidbody2D.MovePosition(temporary);
                animator.SetBool("Walking", true);
            }

        }
        else if(Vector3.Distance(enemyTarget.position, transform.position) > moveRadius)
        {
            if (Vector3.Distance(transform.position, path[currentPoint].position) > roundDistance) 
            {
                Vector3 temporary = Vector3.MoveTowards(transform.position, path[currentPoint].position, enemySpeed * Time.deltaTime);
                ChangeAnimation(temporary - transform.position);
                rigidbody2D.MovePosition(temporary);
            }
            else 
            {
                ChangeGoal();
            }
            
        }
    }

    private void ChangeGoal() 
    {
        if (currentPoint == path.Length - 1)
        {
            currentPoint = 0;
            currentGoal = path[0];
        }
        else 
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }
}
