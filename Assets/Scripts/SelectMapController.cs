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
    public TextMeshProUGUI NoLikedMap;
    public TextMeshProUGUI NoMyMap;
    public float width = 50f;
    public float height = 900f;
    public int mapCount = 0;

    public int btnCnt = 0;

    public GameObject Loading;
    public GameObject LoadingImage;
    public int rot = 0;
    public int loadedImages = 0;

    public GameObject MapLoading;
    public GameObject MapLoadingImage;
    public int mapRot = 0;

    public static SelectMapController instance;

    private void Awake()
    {
        instance = this;
        CreateMyMapButton();
        CreatLikeMapButton();
    }

    private void Start()
    {
        mapCount = 0;
        LoadingImage = Loading.transform.GetChild(0).gameObject;
        MapLoadingImage = MapLoading.transform.GetChild(0).gameObject;
        Debug.Log(GameManager.instance.mapDataDict.Count + GameManager.instance.likesDataDict.Count);
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ReturnToMenu();
        }
    }

    public void FixedUpdate()
    {
        if (Loading.activeSelf)
        {
            LoadingImage.transform.rotation = Quaternion.Euler(0, 0, rot);
            rot--;
            if (rot < -360)
            {
                rot = 0;
            }
            if (loadedImages == GameManager.instance.mapDataDict.Count + GameManager.instance.likesDataDict.Count)
            {
                Loading.SetActive(false);
                LikedMaps.SetActive(false);
                ShowMyMapButton();
            }
        }
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
                    if ((btnCnt % 2) == 1)
                    {
                        nowMapButtons = Instantiate(MapButtons, new Vector3(0, 0, 0), Quaternion.identity);
                        nowMapButtons.transform.SetParent(GameObject.Find("LikedMaps").transform);
                    }
                    temp.transform.SetParent(nowMapButtons.transform);
                }
            }
            btnCnt = 0;
        }
        else
            NoLikedMap.gameObject.SetActive(true);
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
                    if ((btnCnt % 2) == 1)
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
        else
        {
            NoMyMap.gameObject.SetActive(true);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ShowMyMapButton()
    {
        MyMaps.SetActive(true);
        LikedMaps.SetActive(false);
        if (GameManager.instance.mapDataDict.Count == 0)
            NoMyMap.gameObject.SetActive(true);
        NoLikedMap.gameObject.SetActive(false);
    }

    public void ShowLikedMapButton()
    {
        LikedMaps.SetActive(true);
        MyMaps.SetActive(false);
        if (GameManager.instance.likesDataDict.Count == 0)
            NoLikedMap.gameObject.SetActive(true);
        NoMyMap.gameObject.SetActive(false);
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