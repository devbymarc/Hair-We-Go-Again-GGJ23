using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text playerTattooText;
    public TMP_Text playerTattooConvoText;

    public TMP_Text convoText;
    public static float convoNum = 0;

    public GameObject startConvoPanelGameobject;
    public GameObject startConvoFaceGameobject;
    public GameObject tattooConvoGameobject;

    public GameObject inGameFace;
    public GameObject inGameNeck;
    public GameObject inGameChair;
    public GameObject inGameHair;
    public GameObject inGameTattoo;
    //public GameObject inGameRStrand;

    public GameObject razorGameobject;
    //public GameObject sprayGameobject;

    public GameObject barberTitleGameobject;
    public GameObject youTitleGameobject;

    public GameObject controlsGameobject;
    public GameObject timerGameobject;
    public GameObject countdownTimerGameobject;
    public Button razorButton;

    public GameObject startFace;
    public GameObject sadFace;
    public GameObject neutralFace;

    // Open/enable TimerScript - this will start the time
    public GameObject timerScriptGameobject;

    [SerializeField] private IntroText introText;
    void Start()
    {
        Invoke("FirstConvoFunc", 1f);

        razorGameobject.SetActive(false);
        //sprayGameobject.SetActive(false);

        inGameFace.SetActive(false);
        inGameNeck.SetActive(false);
        inGameChair.SetActive(false);
        inGameHair.SetActive(false);
        inGameTattoo.SetActive(false);
        //inGameRStrand.SetActive(false);

        youTitleGameobject.SetActive(false);
        controlsGameobject.SetActive(false);
        timerGameobject.SetActive(false);
        countdownTimerGameobject.SetActive(false);

        startFace.SetActive(true);
        sadFace.SetActive(false);
        neutralFace.SetActive(false);

        timerScriptGameobject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Countdown.isCountdownDone == true)
        {
            razorButton.interactable = true;
            timerGameobject.SetActive(true);
            timerScriptGameobject.SetActive(true);
        }
    }

    public void NextConvo()
    {
        introText.AddWriter(convoText, "Hair wont stop growing bruh", 0.08f);
        convoNum++;

        barberTitleGameobject.SetActive(false);
        youTitleGameobject.SetActive(true);

        startFace.SetActive(false);
        neutralFace.SetActive(false);
        sadFace.SetActive(true); // sad face when telling this

        if (convoNum >= 2)
        {
            barberTitleGameobject.SetActive(true);
            youTitleGameobject.SetActive(false);
            introText.AddWriter(convoText, "Lets chop it down the roots boss!", 0.08f);

            startFace.SetActive(false);
            sadFace.SetActive(true);
            neutralFace.SetActive(false);
        }
        if (convoNum >= 3)
        {
            startConvoPanelGameobject.SetActive(false);
            startConvoFaceGameobject.SetActive(false);
            tattooConvoGameobject.SetActive(false);

            razorGameobject.SetActive(true);
            //sprayGameobject.SetActive(true);

            inGameFace.SetActive(true);
            inGameNeck.SetActive(true);
            inGameChair.SetActive(true);
            inGameHair.SetActive(true);
            inGameTattoo.SetActive(true);
            controlsGameobject.SetActive(true);
            //inGameRStrand.SetActive(false);
            //timerGameobject.SetActive(true);

            countdownTimerGameobject.SetActive(true);

            startFace.SetActive(false);
            sadFace.SetActive(false);
            neutralFace.SetActive(true);
        }
    }
    void FirstConvoFunc()
    {
        playerTattooText.text = PlayerPrefs.GetString("player_name");
        playerTattooConvoText.text = PlayerPrefs.GetString("player_name");
        introText.AddWriter(convoText, "Whats up " + PlayerPrefs.GetString("player_name") + "? ", 0.08f);
    }
}
