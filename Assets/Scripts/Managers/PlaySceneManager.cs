using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneManager : MonoBehaviour
{
    public void GoToMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
