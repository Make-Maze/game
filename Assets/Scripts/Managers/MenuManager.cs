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
    }

    public void StartButton()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void MapSelectButton()
    {
        SceneManager.LoadScene("MapSelectScene");
    }

    public void SettingButton()
    {
        settingScreen.SetActive(true);
    }

    public void CloseSettingButton()
    {
        settingScreen.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
