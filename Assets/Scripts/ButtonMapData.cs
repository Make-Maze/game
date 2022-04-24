using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonMapData : MonoBehaviour
{
    public MapData mapData;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => { clickButton(); });
    }

    public void clickButton()
    {
        StartCoroutine(LoadJson.instance.GetRequest_Content(mapData.mapId));
        Debug.Log("½ÇÇàµÊ?1");
        SceneManager.LoadScene("PlayScene");
    }
}
