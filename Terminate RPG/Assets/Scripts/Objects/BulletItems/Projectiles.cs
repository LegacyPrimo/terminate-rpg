using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{

    public float speed;
    public Vector2 directionToMove;
    public float lifeTime;
    private float lifeTimeSeconds;
    public Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        lifeTimeSeconds = lifeTime;    
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimeSeconds -= Time.deltaTime;
        if (lifeTimeSeconds <= 0) 
        {
            Destroy(this.gameObject);
        }
    }

    public void Launch(Vector2 initialVelocity) 
    {
        rigidbody.velocity = initialVelocity * speed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
