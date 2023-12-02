using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gameover : MonoBehaviour
{

    public TextMeshProUGUI deadInnocent;
    public TextMeshProUGUI aliveGuilty;

    private void Start()
    {
        //vscript = GetComponent<VerdictScript>();
        int deadInnocent1 = PlayerPrefs.GetInt("deadInnocent");
        int aliveGuilty1 = PlayerPrefs.GetInt("aliveGuilty");
        deadInnocent.text = "";
        aliveGuilty.text = "";

        if (deadInnocent1 > 0)
        {
            deadInnocent.text = "You have killed " + deadInnocent1 + " innocent(s). Shame on you!";

        }
        if (aliveGuilty1 > 0){

            aliveGuilty.text = "You have set free " + aliveGuilty1 +  " witches. You are a horrible judge!";
        }
        if(aliveGuilty1 == 0 && deadInnocent1 == 0)
        {
            deadInnocent.text = "Congratulations, you have mastered your judgeship!";
        }


    
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
