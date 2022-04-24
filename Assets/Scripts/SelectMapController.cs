using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SelectMapController : MonoBehaviour
{

    public GameObject MapButton;
    public GameObject MapButtons;
    public GameObject nowMapButtons;
    public GameObject temp;
    public GameObject addMapPanel;
    public GameObject LikedMaps;
    public GameObject MyMaps;
    public float width = 50f;
    public float height = 900f;
    public int mapCount = 0;

    public int btnCnt = 0;

    public static SelectMapController instance;

    private void Awake()
    {
        instance = this;
    }

    public void CreatLikeMapButton()
    {
        if (GameManager.instance.likesDataDict.Count != 0)
        {
            for (int i = 0; i < 100; i++)
            {
                if (GameManager.instance.likesDataDict.ContainsKey(i))
                {
                    btnCnt++;
                    temp = Instantiate(MapButton, new Vector3(0, 0, 0), Quaternion.identity);
                    temp.name = GameManager.instance.likesDataDict[i].mapName;
                    temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = GameManager.instance.likesDataDict[i].mapName;
                    temp.GetComponent<ButtonMapData>().mapData = GameManager.instance.likesDataDict[i];
                    if ((btnCnt % 3) == 1)
                    {
                        nowMapButtons = Instantiate(MapButtons, new Vector3(0, 0, 0), Quaternion.identity);
                        nowMapButtons.transform.SetParent(GameObject.Find("LikedMaps").transform);
                    }
                    temp.transform.SetParent(nowMapButtons.transform);
                }
            }
            btnCnt = 0;
        }
    }

    public void CreateMyMapButton()
    {
        if (GameManager.instance.mapDataDict.Count != 0)
        {
            for (int i = 0; i < 100; i++)
            {
                if (GameManager.instance.mapDataDict.ContainsKey(i))
                {
                    btnCnt++;
                    temp = Instantiate(MapButton, new Vector3(0, 0, 0), Quaternion.identity);
                    temp.name = GameManager.instance.mapDataDict[i].mapName;
                    temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = GameManager.instance.mapDataDict[i].mapName;
                    temp.GetComponent<ButtonMapData>().mapData = GameManager.instance.mapDataDict[i];
                    if ((btnCnt % 3) == 1)
                    {
                        Debug.Log("¤±¤·¤¤¤©");
                        nowMapButtons = Instantiate(MapButtons, new Vector3(0, 0, 0), Quaternion.identity);
                        nowMapButtons.transform.SetParent(GameObject.Find("MyMaps").transform);
                    }
                    temp.transform.SetParent(nowMapButtons.transform);
                }
            }
            btnCnt = 0;
        }
        MyMaps.SetActive(false);
    }

    public void ShowMyMapButton()
    {
        MyMaps.SetActive(true);
        LikedMaps.SetActive(false);
    }

    public void ShowLikedMapButton()
    {
        LikedMaps.SetActive(true);
        MyMaps.SetActive(false);
    }

    public void addMapButton()
    {
        if (addMapPanel != false)
        {
            addMapPanel.SetActive(true);
        }
    }

    public void closeAddMapButton()
    {
        addMapPanel.SetActive(false);
        SceneManager.LoadScene("MapSelectScene");
    }
}