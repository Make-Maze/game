using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlaySceneManager : MonoBehaviour
{
    public GameObject MapLoading;
    public GameObject MapLoadingImage;
    public GameObject ClearScreen;
    public GameObject GameOverScreen;
    public int mapRot = 0;
    public float playTime = 0;

    private void Start()
    {
        MapLoadingImage = MapLoading.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (!ClearScreen.activeSelf)
            playTime += Time.deltaTime;
        else
        {
            string ClearMin;
            string ClearSec;
            if (playTime / 60 < 10)
            {
                ClearMin = "0" + (int)(playTime / 60);
            }
            else
            {
                ClearMin = "" + (int)(playTime / 60);
            }
            if (playTime % 60 < 10)
            {
                ClearSec = "0" + (int)(playTime % 60);
            }
            else
            {
                ClearSec = "" + (int)(playTime % 60);
            }
            ClearScreen.transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = "PlayTime\n" + ClearMin + ":" + ClearSec;
        }
    }

    private void FixedUpdate()
    {
        if (MapLoading.activeSelf)
        {
            MapLoadingImage.transform.rotation = Quaternion.Euler(0, 0, mapRot);
            mapRot--;
            if (mapRot < -360)
            {
                mapRot = 0;
            }
        }
    }

    public void GoToMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }

    public void ReStartGame()
    {
        MapLoading.SetActive(true);
        ClearScreen.SetActive(false);
        GameOverScreen.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("PlayScene");
    }
}
