using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreateMap : MonoBehaviour
{
    public Transform creatingObject;
    public GameObject[] gameObjects = new GameObject[100];

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void clickButton(MapData mapData)
    {
        StartCoroutine(LoadJson.instance.GetRequest_Content(mapData.mapId));
        SceneManager.LoadScene("PlayScene");
    }
}
