using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMapController : MonoBehaviour
{
    public ScrollRect scrollRect;
    public List<GameObject> maps = new List<GameObject>();
    //public int mapsValue=0;
    public GameObject MapButton;
    public GameObject MapButtons;
    public GameObject nowMapButtons;
    public float width = 50f;
    public float height = 900f;

    public void CreatMapButton()
    {
        //mapsValue++;
        maps.Add(Instantiate(MapButton, new Vector3(0, 0, 0), Quaternion.identity));
        if ((maps.Count % 3) == 1)
        {
            if (maps.Count != 1)
                height += 900f;
            nowMapButtons = Instantiate(MapButtons, new Vector3(0, 0, 0), Quaternion.identity);
            nowMapButtons.transform.SetParent(GameObject.Find("Content").transform);
        }
        maps[maps.Count - 1].transform.SetParent(nowMapButtons.transform);
        scrollRect.content.sizeDelta = new Vector2(width, height);
    }
}