using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Internal;
using TMPro;
using System;

public class TimerScript : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text highscore;
    private float startTime;
    public static bool finished = false; //

    private float msec;
    private float sec;
    private float min;

    public TMP_Text previousRunScore;
    public GameObject timerScriptGO;

    public void GameFinished()
    {
        float t = Time.time - startTime;

        if (t < PlayerPrefs.GetFloat("HighScore", float.MaxValue))
        {
            msec = (int)((t - (int)t) * 100);
            sec = (int)(t % 60);
            min = (int)(t / 60 % 60);

            PlayerPrefs.SetFloat("HighScore", t);
            highscore.text = string.Format("{0:00}:{1:00}.{2:00}", min, sec, msec);
            PlayerPrefs.Save();

        }
    }

    void Start()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("HighScore", 0));
        startTime = Time.time;
        highscore.text = string.Format("{0:00}:{1:00}.{2:00}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);


        //TimeSpan timeSpan2 = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("PreviousRunScore", 0));
        //startTime = Time.time;
        //previousRunScore.text = string.Format("{0:00}:{1:00}.{2:00}", timeSpan2.Minutes, timeSpan2.Seconds, timeSpan2.Milliseconds / 10); 
    }


    void Update()
    {
        if (!finished)
        {
            float t = Time.time - startTime;
            msec = (int)((t - (int)t) * 100);
            sec = (int)(t % 60);
            min = (int)(t / 60 % 60);
            timerText.text = string.Format("{0:00}:{1:00}.{2:00}", min, sec, msec);
        }

        // NEW LINE'
        if (RazorSlider.charge <= 0)
        {
            GameFinished();
            finished = true;

            //float t = Time.time - startTime;
            //PlayerPrefs.SetFloat("PreviousRunScore", t);
            //previousRunScore.text = string.Format("{0:00}:{1:00}.{2:00}", min, sec, msec);
            //PlayerPrefs.Save();

            //timerScriptGO.SetActive(false);
        }
    }
}