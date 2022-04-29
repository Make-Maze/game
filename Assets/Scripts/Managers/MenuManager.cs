using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject Loading;
    public GameObject LoadingImage;
    public GameObject LoginPanel;
    public GameObject InputEmailPanel;
    public TMP_InputField InputEmail;
    public GameObject PlayPanel;

    public int rot = 0;

    private void Start()
    {
        if (GameManager.instance.PlayerEmail.Length != 0)
        {
            LoginPanel.SetActive(false);
            PlayPanel.SetActive(true);
        }
        LoadingImage = Loading.transform.GetChild(0).gameObject;
    }

    private void FixedUpdate()
    {
        if (Loading.activeSelf)
        {
            LoadingImage.transform.rotation = Quaternion.Euler(0, 0, rot);
            rot--;
            if (rot < -360)
            {
                rot = 0;
            }
        }
    }

    public void LoginButton()
    {
        InputEmailPanel.SetActive(true);
    }

    public void CloseInputButton()
    {
        if (InputEmail.text.Length > 0 && InputEmail.text.Contains("@"))
        {
            GameManager.instance.PlayerEmail = InputEmail.text;
            Debug.Log(InputEmail.text);
            Debug.Log(GameManager.instance.PlayerEmail);
            LoginPanel.SetActive(false);
            PlayPanel.SetActive(true);
            InputEmailPanel.SetActive(false);
        }
    }

    public void MapSelectButton()
    {
        Loading.SetActive(true);
        LoadJson.instance.LoadStart();
    }

    public void LogoutButton()
    {
        GameManager.instance.PlayerEmail = null;
        PlayPanel.SetActive(false);
        LoginPanel.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}