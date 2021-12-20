using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectMapController : MonoBehaviour
{
    //public ScrollRect scrollRect;
    // public List<GameObject> maps = new List<GameObject>();
    public GameObject MapButton;
    public GameObject MapButtons;
    public GameObject nowMapButtons;
    public GameObject temp;
    private List<MapData> mapData = LoadJsonTest.mapData;
    public float width = 50f;
    public float height = 900f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        CreatMapButton();
    }

    public void CreatMapButton()
    {
        //mapsValue++;
        for (int i = 0; i < mapData.Count; i++)
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
        }
        //scrollRect.content.sizeDelta = new Vector2(width, height);
    }
}