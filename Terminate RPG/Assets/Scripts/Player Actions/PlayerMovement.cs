using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum PlayerState 
{
    walk,
    attack, 
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentstate;
    public float speed;
    private Rigidbody2D rigidbody;
    private Vector3 directionChange;
    private Animator animator;
    public VectorValue startingPosition;
    public FloatValue currentHealth;
    public SignalReader playerHealthSignal;
    public Joystick joystick;
    public AttackButton attackButton;
    public Inventory playerInventory;
    public SpriteRenderer receivedItem;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, true);
        currentstate = PlayerState.walk;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        attackButton = FindObjectOfType<AttackButton>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentstate == PlayerState.interact)
        {
            return;
        }
        directionChange = Vector3.zero;
        directionChange.x = joystick.Horizontal;
        directionChange.y = joystick.Vertical;

        if (attackButton.ButtonPressed && currentstate != PlayerState.attack && currentstate != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentstate == PlayerState.walk || currentstate == PlayerState.idle) 
        {
            UpdateAnimationMovement();
        }
        
    }

    public void Knock(float knockTime, float damageTaken) 
    {
        currentHealth.runtimeValue -= damageTaken;
        if (currentHealth.runtimeValue > 0)
        {
            playerHealthSignal.Raise();
            StartCoroutine(KnockCoRoutine(knockTime));
        }
        else 
        {
            this.gameObject.SetActive(false);
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
        if (currentstate != PlayerState.interact)
        {
            currentstate = PlayerState.walk;
        }    
    }

    public void RaiseItem() 
    {
        if (playerInventory.currentItem != null) 
        {
            if (currentstate != PlayerState.interact)
            {
                currentstate = PlayerState.interact;
                receivedItem.sprite = playerInventory.currentItem.ItemSprite;
            }
            else
            {
                currentstate = PlayerState.idle;
                receivedItem.sprite = null;
                playerInventory.currentItem = null;
            }
        }
    }

    // Movement Calculation of a Character
    void CharacterMovement() 
    {
        directionChange.Normalize();
        rigidbody.MovePosition(
                transform.position + directionChange * speed * Time.deltaTime
             );
    }

    private IEnumerator KnockCoRoutine(float knockTime)
    {
        if (rigidbody)
        {
            yield return new WaitForSeconds(knockTime);
            rigidbody.velocity = Vector2.zero;
            currentstate = PlayerState.idle;
            rigidbody.velocity = Vector2.zero;
        }
    }
}

