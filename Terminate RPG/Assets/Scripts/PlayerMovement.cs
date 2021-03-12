using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidbody;
    private Vector3 directionChange;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        directionChange = Vector3.zero;
        directionChange.x = Input.GetAxisRaw("Horizontal");
        directionChange.y = Input.GetAxisRaw("Vertical");

        if (directionChange != Vector3.zero) 
        {
            CharacterMovement();
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
