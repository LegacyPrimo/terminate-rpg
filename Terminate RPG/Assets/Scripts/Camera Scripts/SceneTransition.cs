using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerSetPosition;
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWaitingTime;

    private void Awake()
    {
        if (fadeInPanel != null) 
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger) 
        {

            playerSetPosition.initialValue = playerPosition;
            StartCoroutine(FadeCoroutine());          
        }
    }
    public IEnumerator FadeCoroutine() 
    {
        if (fadeOutPanel != null) 
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }

        yield return new WaitForSeconds(fadeWaitingTime);
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!async.isDone) 
        {
            yield return null;
        }
    }
}
