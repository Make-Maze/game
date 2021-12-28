using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySceneManager : MonoBehaviour
{
    public void GoToMenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
