using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroText : MonoBehaviour
{
    private TMP_Text convoText;
    private string textToWrite;
    private int characterIndex;
    private float timerPerCharacter;
    private float timer;

    public GameObject continueButtonGameobject;
    public Button continueButton;

    public AudioSource typeSFX;
    public void AddWriter(TMP_Text convoText, string textToWrite, float timerPerCharacter)
    {
        this.convoText = convoText;
        this.textToWrite = textToWrite;
        this.timerPerCharacter = timerPerCharacter;
        characterIndex = 0;
    }

    private void Start()
    {
        continueButtonGameobject.SetActive(false);
    }

    private void Update()
    {
        if (convoText != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                // Display Text
                timer += timerPerCharacter;
                characterIndex++;
                convoText.text = textToWrite.Substring(0, characterIndex);
                if (GameManager.convoNum <= 2)
                {
                    typeSFX.Play();
                }



                if (characterIndex >= textToWrite.Length)
                {
                    // Entire string displayed
                    //continueButton.interactable = true;
                    continueButtonGameobject.SetActive(true);
                    convoText = null;
                    return;
                }
                else
                {
                    //continueButton.interactable = false;
                    continueButtonGameobject.SetActive(false);
                }
            }
        }
    }

}
