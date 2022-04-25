using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject settingScreen;
    public GameObject LoginPanel;
    public GameObject InputEmailPanel;
    public TMP_InputField InputEmail;
    public GameObject PlayPanel;

    private void Start()
    {
        if (GameManager.instance.PlayerEmail.Length != 0)
        {
            LoginPanel.SetActive(false);
            PlayPanel.SetActive(true);
        }
    }

    public void LoginButton()
    {
        InputEmailPanel.SetActive(true);
    }

    public void CloseInputButton()
    {
        GameManager.instance.PlayerEmail = InputEmail.text;
        Debug.Log(InputEmail.text);
        Debug.Log(GameManager.instance.PlayerEmail);
        LoginPanel.SetActive(false);
        PlayPanel.SetActive(true);
        InputEmailPanel.SetActive(false);
    }

    public void MapSelectButton()
    {
        LoadJson.instance.LoadStart();
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}