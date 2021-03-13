using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform transformTarget;
    public float smoothTransition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != transformTarget.position) 
        {
            Vector3 targetPosition = new Vector3(transformTarget.position.x, transformTarget.position.y, 
                transform.position.z);

            transform.position = Vector3.Lerp(transform.position, 
                targetPosition, 
                smoothTransition);
        }
    }
}
