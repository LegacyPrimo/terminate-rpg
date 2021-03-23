using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState 
{
    walk,
    attack, 
    interact
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentstate;
    public float speed;
    private Rigidbody2D rigidbody;
    private Vector3 directionChange;
    private Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        directionChange = Vector3.zero;
        directionChange.x = Input.GetAxisRaw("Horizontal"); 
        directionChange.y = Input.GetAxisRaw("Vertical");
        
        if (Input.GetButtonDown("attack") && currentstate != PlayerState.attack) 
        {
            StartCoroutine(AttackCo());
        }
        else if (currentstate == PlayerState.walk) 
        {
            UpdateAnimationMovement();
        }
        
    }
    void UpdateAnimationMovement() 
    {
        if (directionChange != Vector3.zero)
        {
            CharacterMovement();
            animator.SetFloat("moveX", directionChange.x);
            animator.SetFloat("moveY", directionChange.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }

    }

    private IEnumerator AttackCo() 
    {
        animator.SetBool("Attacking", true);
        currentstate = PlayerState.attack;
        yield return null;
        animator.SetBool("Attacking", false);
        yield return new WaitForSeconds(.3f);
        currentstate = PlayerState.walk;
    }

    // Movement Calculation of a Character
    void CharacterMovement() 
    {
        rigidbody.MovePosition(
                transform.position + directionChange * speed * Time.deltaTime
             );
    }
}
