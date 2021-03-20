using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RoomMovement : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement camera;
    public bool needText;
    public string titleCard;
    public GameObject text;
    public Text placeText;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            camera.minPosition += cameraChange;
            camera.maxPosition += cameraChange;
            collision.transform.position += playerChange;
            if (needText)
            {
                StartCoroutine(placeTitleCo());
            }
        }

    }

    private IEnumerator placeTitleCo() 
    {
        text.SetActive(true);
        placeText.text = titleCard;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}
