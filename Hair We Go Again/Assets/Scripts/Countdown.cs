using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 3f;
    public TMP_Text openingCountdownText;
    //public TMP_Text gameTimerText;

    public GameObject gameTimerGameobject;

    public Button razorButton;

    public static bool isCountdownDone;

    public AudioSource GoSFX;
    private bool isDone;
    // Open/enable TimerScript - this will start the time
    //public GameObject timerScriptGameobject;

    void Start()
    {
        currentTime = startingTime;
        gameTimerGameobject.SetActive(false);
        razorButton.interactable = false;
        isCountdownDone = false;
        //timerScriptGameobject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        openingCountdownText.text = currentTime.ToString("00");

        if (currentTime <= 0)
        {
            currentTime = 0f;
            openingCountdownText.text = "";
            isCountdownDone = true;

            //timerScriptGameobject.SetActive(true);
            //razorButton.interactable = true;
            if (!isDone)
            {
                GoSFX.Play();
                isDone = true;
            }

        }
    }
}
