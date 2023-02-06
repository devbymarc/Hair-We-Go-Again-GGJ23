using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NameHolder : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button submitButton;

    public TMP_Text playerName;
    private float playerCreatedInt;

    void Start()
    {
        playerName.text = PlayerPrefs.GetString("player_name");
        inputField.characterLimit = 10;

        playerCreatedInt = PlayerPrefs.GetInt("player_created", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (inputField.text.Length >= 3)
        {
            submitButton.interactable = true;
        }
        else
        {
            submitButton.interactable = false;
        }
    }

    public void Submit()
    {
        playerName.text = inputField.text;
        PlayerPrefs.SetString("player_name", playerName.text);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        PlayerPrefs.SetInt("player_created", 1);
    }
}
