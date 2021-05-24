using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public Button button;
    public GameObject pausePanel;
    public GameObject inventoryPanel;
    private bool isPaused;
    public string mainMenu;
    private int currentSceneIndex;
    private bool isInventoryClicked;

    public void Paused() 
    {
        ChangePause();
    }

    public void InventoryPaused() 
    {
        InventoryButton();
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
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }

    public void InventoryButton() 
    {
        isInventoryClicked = !isInventoryClicked;
        if (isInventoryClicked)
        {
            inventoryPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else 
        {
            inventoryPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
