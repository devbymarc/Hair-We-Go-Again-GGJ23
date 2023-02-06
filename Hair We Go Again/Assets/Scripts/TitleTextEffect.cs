using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleTextEffect : MonoBehaviour
{
    public TMP_Text titleTextEffect;
    public GameObject buttonsGameobjects;

    [SerializeField] private TitleText titleText;
    void Start()
    {
        Invoke("PlayText", 1.5f);
        buttonsGameobjects.SetActive(false);

        Invoke("ShowButtons", 5.5f);
    }

    void PlayText()
    {
        titleText.AddWriter(titleTextEffect, "AH, HAIR WE GO AGAIN.", 0.15f);
        
    }

    void ShowButtons()
    {
        buttonsGameobjects.SetActive(true);
    }
}
