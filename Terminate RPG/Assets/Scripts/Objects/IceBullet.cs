using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidbody;
    public float lifeTime;
    private float lifeTimeCounter;
    public float bulletCost;
    // Start is called before the first frame update
    void Start()
    {
        lifeTimeCounter = lifeTime;
    }

    private void Update()
    {
        lifeTimeCounter -= Time.deltaTime;
        if (lifeTimeCounter <= 0) 
        {
            Destroy(this.gameObject);
        }
    }

    public void Setup(Vector2 velocity, Vector3 direction) 
    {
        rigidbody.velocity = velocity.normalized * speed;
        transform.rotation = Quaternion.Euler(direction);
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            Destroy(this.gameObject);
        }
    }
}
