using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHolder : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("GAME");
        GameManager.convoNum = 0;

        TimerScript.finished = false;
        Countdown.isCountdownDone = false; // lipat muna natin
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit game!");
    }

    public void ResetButton()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
        //SceneManager.LoadScene("MENU");
    }
}
