using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SelectMapController : MonoBehaviour
{
    //public ScrollRect scrollRect;
    // public List<GameObject> maps = new List<GameObject>();
    public GameObject MapButton;
    public GameObject MapButtons;
    public GameObject nowMapButtons;
    public GameObject temp;
    private List<MapData> mapData = LoadJson.mapData;
    public GameObject addMapPanel;
    public float width = 50f;
    public float height = 900f;
    public int mapCount = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log(mapData.Count);
        Debug.Log("제발 살아있다고 말해줘");
        if(mapData.Count!=0)
        CreatMapButton();
    }

    public void CreatMapButton()
    {
        for (int i = mapCount; i < mapData.Count; i++)
        {
            temp = Instantiate(MapButton, new Vector3(0, 0, 0), Quaternion.identity);
            temp.name = mapData[i].mapName;
            temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = mapData[i].mapName;
            if (((i + 1) % 3) == 1)
            {
                nowMapButtons = Instantiate(MapButtons, new Vector3(0, 0, 0), Quaternion.identity);
                nowMapButtons.transform.SetParent(GameObject.Find("Content").transform);
            }
            temp.transform.SetParent(nowMapButtons.transform);
            mapCount++;
        }
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