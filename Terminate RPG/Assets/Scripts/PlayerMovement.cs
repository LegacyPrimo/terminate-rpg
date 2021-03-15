using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
        directionChange.x = Input.GetAxisRaw("Horizontal"); //=1.0 GetAxis("Horizontal") = 1.32
        directionChange.y = Input.GetAxisRaw("Vertical");
        Debug.Log(directionChange);
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

    // Movement Calculation of a Character
    void CharacterMovement() 
    {
        rigidbody.MovePosition(
                transform.position + directionChange * speed * Time.deltaTime
             );
    }
}
