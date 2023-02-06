using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalTextEffect : MonoBehaviour
{
    public TMP_Text finalTextEffect;

    [SerializeField] private FinalText finalText;
    void Start()
    {
        Invoke("PlayText", .5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void PlayText()
    {
        finalText.AddWriter(finalTextEffect, "ARE YOU FREAKIN KIDDIN ME?", 0.08f); //0.08
        Invoke("NextScene", 3.5f);
    }
}
