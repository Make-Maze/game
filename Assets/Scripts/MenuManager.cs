using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject settingScreen;
    public GameObject LoginPanel;
    public GameObject PlayPanel;

    public void LoginButton()
    {
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
