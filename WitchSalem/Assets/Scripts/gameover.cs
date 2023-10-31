using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
