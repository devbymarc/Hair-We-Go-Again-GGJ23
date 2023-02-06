using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TScript : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text bestTimeText;
    public float time;

    private float msec;
    private float sec;
    private float min;

    private void Start()
    {
        StartCoroutine("TimerClock");

        bestTimeText.text = string.Format("{0:00}:{1:00}.{2:00}", min, sec, msec);
        bestTimeText.text = PlayerPrefs.GetFloat("BestTime", 0).ToString();
    }

    public void StopTimerClock()
    {
        StopCoroutine("TimerClock");
        Debug.Log("stop clock!");
    }

    void Update()
    {
        bestTimeText.text = string.Format("{0:00}:{1:00}.{2:00}", min, sec, msec);
        bestTimeText.text = PlayerPrefs.GetFloat("BestTime", 0).ToString("00:00.00");

    }

    IEnumerator TimerClock()
    {
        while (true)
        {
            time += Time.deltaTime;
            msec = (int)((time - (int)time) * 100);
            sec = (int)(time % 60);
            min = (int)(time / 60 % 60);

            timerText.text = string.Format("{0:00}:{1:00}.{2:00}", min, sec, msec);

            yield return null;

        }
    }

    public void GameIsFinished()
    {
        if (time < PlayerPrefs.GetFloat("BestTime", 0))
        {
            PlayerPrefs.SetFloat("BestTime", time);
            bestTimeText.text = string.Format("{0:00}:{1:00}.{2:00}", min, sec, msec);

        }
        //PlayerPrefs.SetFloat("BestTime", time);
    }
}
