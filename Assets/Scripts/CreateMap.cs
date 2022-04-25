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
    public GameObject Walls;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void clickButton(MapData mapData)
    {
        StartCoroutine(LoadJson.instance.GetRequest_Content(mapData.mapId));
        SceneManager.LoadScene("PlayScene");
    }

    public void MakeMap()
    {
        Debug.Log("けしかしぉ");
        Debug.Log(GameManager.instance.Blocks.Count);
        foreach (var block in GameManager.instance.Blocks)
        {
            Debug.Log(block.kind+"/"+ block.x+"/"+ block.y+"/"+ block.x2+"/"+ block.y2);
            Debug.Log(gameObjects[block.kind]);
            Vector3 blockLoc = new Vector3(block.x, block.y);
            if (block.kind == 9)
            {
                Vector3 blockLoc2 = new Vector3(block.x2, block.y2);
                Transform portals = Instantiate(gameObjects[block.kind], new Vector3(0, 0), Quaternion.identity).GetComponent<Transform>();
                portals.transform.SetParent(Walls.transform);
                portals.transform.GetChild(0).position = blockLoc;
                portals.transform.GetChild(1).position = blockLoc2;
                return;
            }
            Instantiate(gameObjects[block.kind], blockLoc, Quaternion.identity).GetComponent<Transform>();
            Transform creatingObject = Instantiate(gameObjects[block.kind], blockLoc, Quaternion.identity).GetComponent<Transform>();
            creatingObject.transform.SetParent(Walls.transform);
        }
    }

}
