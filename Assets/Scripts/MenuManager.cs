using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject settingScreen;
    public GameObject LoginPanel;
    public GameObject PlayPanel;

    public GameObject normalWall;
    public GameObject invisibleWall;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoginButton()
    {
        LoginPanel.SetActive(false);
        PlayPanel.SetActive(true);
    }

    public void StartButton(/*MapData mapData*/)
    {
        SceneManager.LoadScene("PlaySceneEx");
        //for (int i = 0; i < mapData.blocks.Length; i++)
        //{
        //    GameObject Wall = null;
        //    switch (mapData.blocks[i][0])
        //    {
        //        case 1:
        //            Wall = normalWall;
        //            break;
        //        case 2:
        //            Wall = invisibleWall;
        //            break;
        //    }
        //    Instantiate(Wall, new Vector2(mapData.blocks[i][1], mapData.blocks[i][2]), Quaternion.identity);
        //}
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
