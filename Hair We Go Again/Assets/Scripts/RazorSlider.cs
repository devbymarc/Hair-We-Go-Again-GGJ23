using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RazorSlider : MonoBehaviour
{
    public Image slider;
    public static float charge;
    float maxCharge = 100f;
    public static float chargeDeductor;
    public static float chargeAdder; // when increasing hair

    bool isIncreasing = true;
    bool isBuzzingDone = false;

    public GameObject allRootsGameobject;
    public Button razorClickerButton;

    public TimerScript timerSCript;

    // Facial Expressions
    public GameObject startFace;
    public GameObject neutralFace;
    public GameObject sadFace;

    // Final Game Panel
    public GameObject finalGamePanelGameobject;

    public AudioSource haircutDoneSFX;
    public AudioSource seedPopSFX;
    public AudioSource GoSFX;

    bool isDone;
    void Start()
    {
        maxCharge = 100f;
        charge = maxCharge - 0;
        chargeDeductor = 2f; // 2
        chargeAdder = 10f;
        allRootsGameobject.SetActive(false);

        neutralFace.SetActive(true);
        startFace.SetActive(false);
        sadFace.SetActive(false);
        finalGamePanelGameobject.SetActive(false);
    }


    void Update()
    {
        slider.fillAmount = charge / maxCharge;
        if (isIncreasing)
        {
            StartCoroutine(ChargeIncrease());
        }

        if (charge <= 0)
        {
            razorClickerButton.interactable = false;

            //TimerScript.finished = true;
            //timerSCript.GameFinished();
            // haircut done sfx

            if (!isDone)
            {
                neutralFace.SetActive(false);
                startFace.SetActive(true);
                sadFace.SetActive(false);

                haircutDoneSFX.Play();
                GoSFX.Play();
                //Invoke("PlayGoSFX", 1f);

                Invoke("ShowAllRootsFunc", 5f);
                Invoke("ShowFinalGamePanel", 7f);

                isDone = true;
            }

            isBuzzingDone = true;

        }
    }

    IEnumerator ChargeIncrease()
    {
        if (!isBuzzingDone)
        {
            if (charge >= 100)
            {
                chargeAdder = 0f;
            }
            else
            {
                chargeAdder = 10f;
            }

            charge += chargeAdder;
            isIncreasing = false;

            yield return new WaitForSeconds(1f);
            isIncreasing = true;
        }
    }

    void ShowAllRootsFunc()
    {
        allRootsGameobject.SetActive(true);
        neutralFace.SetActive(false);
        startFace.SetActive(false);
        sadFace.SetActive(true);

        // toink soud effect
        seedPopSFX.Play();
    }

    void ShowFinalGamePanel()
    {
        finalGamePanelGameobject.SetActive(true);
    }

    void PlayGoSFX()
    {
        GoSFX.Play();
    }
}
