using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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
    public ProjectileButton projectileButton;
    public Inventory playerInventory;
    public SpriteRenderer receivedItem;
    public GameObject projectile;
    public SignalReader decreaseBullet;
    public ItemObjects pistolGun;


    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, true);
        currentstate = PlayerState.walk;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        attackButton = FindObjectOfType<AttackButton>();
        projectileButton = FindObjectOfType<ProjectileButton>();
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
        else if(projectileButton.ButtonPressed && currentstate != PlayerState.attack && currentstate != PlayerState.stagger)
        {
            if (playerInventory.CheckForItem(pistolGun)) 
            {
                StartCoroutine(ProjectileCo());
            }
            
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
            SceneManager.LoadScene("GameOverScene");
        }
        
    }

    void UpdateAnimationMovement() 
    {
        if (directionChange != Vector3.zero)
        {
            CharacterMovement();
            directionChange.x = Mathf.Round(directionChange.x);
            directionChange.y = Mathf.Round(directionChange.y);
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

    private IEnumerator ProjectileCo()
    {
        
        currentstate = PlayerState.attack;
        yield return null;
        MakeBullet();
        yield return new WaitForSeconds(.3f);
        if (currentstate != PlayerState.interact)
        {
            currentstate = PlayerState.walk;
        }
    }

    private void MakeBullet() 
    {
        if (playerInventory.currentBullet > 0)
        {
            Vector2 temporary = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
            IceBullet iceBullet = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<IceBullet>();
            iceBullet.Setup(temporary, ChooseBulletDirection());
            playerInventory.ReduceBullets(iceBullet.bulletCost);
            decreaseBullet.Raise();
        }
    }

    Vector3 ChooseBulletDirection() 
    {
        float temporary = Mathf.Atan2(animator.GetFloat("moveY"), animator.GetFloat("moveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temporary);

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

