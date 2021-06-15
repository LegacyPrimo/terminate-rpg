using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SludgeBomber : EnemyScript
{
    public Transform initialPosition;
    public GameObject projectile;
    private Animator animator;
    public Rigidbody2D rigidbody;
    public float fireDelay;
    private float fireDelaySeconds;
    public bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyTarget = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        CheckDistance();
        fireDelaySeconds -= Time.deltaTime;
        if (fireDelaySeconds <= 0) 
        {
            canFire = true;
            fireDelaySeconds = fireDelay;
        }
    }

    void CheckDistance()
    {
        if (Vector3.Distance(enemyTarget.position, transform.position) <= moveRadius
            && Vector3.Distance(enemyTarget.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                if (canFire)
                {


                    Vector3 temporaryVector = enemyTarget.transform.position - transform.position;
                    GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
                    current.GetComponent<Projectiles>().Launch(temporaryVector);
                    canFire = false;
                    ChangeState(EnemyState.walk);
                    animator.SetBool("Walking", true);
                }
            }

        }
        else if (Vector3.Distance(enemyTarget.position, transform.position) > moveRadius)
        {
            animator.SetBool("Walking", false);
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
