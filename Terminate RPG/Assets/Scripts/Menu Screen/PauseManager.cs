using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public Button button;
    public GameObject pausePanel;
    private bool isPaused;
    public string mainMenu;

    public void Paused() 
    {
        ChangePause();
    }

    public void ChangePause() 
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void QuitToMain() 
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
}
