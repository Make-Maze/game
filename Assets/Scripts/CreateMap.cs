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
    public MapData mapData;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void clickButton(MapData mapData)
    {
        this.mapData = mapData;
        SceneManager.LoadScene("PlayScene");
    }
}