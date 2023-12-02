using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour
{
    public GameObject pauseMenu; // Reference to the pause menu UI
    private bool isPaused = false;

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pauses the game
            ShowPauseMenu(); // Show the pause menu
        }
        else
        {
            Time.timeScale = 1f; // Resumes the game
            HidePauseMenu(); // Hide the pause menu
        }
    }

    private void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    private void HidePauseMenu()
    {
        pauseMenu.SetActive(false);
    }
}
