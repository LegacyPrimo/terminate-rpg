using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void StartGame() 
    {
        audioSource.PlayOneShot(audioClip);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() 
    {
        audioSource.PlayOneShot(audioClip);
        Application.Quit();
    }
}
