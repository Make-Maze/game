using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadJson : MonoBehaviour
{
    public static List<MapData> mapData = new List<MapData>();
    public SelectMapController selectMapController;
    public Canvas canvas;
    public CreateMap createMap;
    public MapData mapdata;
    public string inputMapID;

    private void Awake()
    {
        createMap = GameObject.Find("MapMaker").GetComponent<CreateMap>();
        if (mapData.Count != 0)
        {
            foreach (MapData nowMapData in mapData)
            {
                canvas = transform.GetComponentInChildren<Canvas>();
                Debug.Log("Scroll View/Viewport/Content/MapButtons(Clone)/" + nowMapData.mapName);
                canvas.transform.Find("Scroll View/Viewport/Content/MapButtons(Clone)/" + nowMapData.mapName).GetComponent<Button>().onClick.AddListener(() => { returnMapData(nowMapData); });
            }
        }
    }

    public void LoadStart()
    {
        // A non-existing page.
        Debug.Log("asdfadsf");
        Debug.Log(inputMapID);
        Debug.Log("http://192.168.0.32:8888/map1/" + inputMapID);
        //string requestMapID = "http://127.0.0.1:8000/";
        string requestMapID = "http://192.168.0.32:8888/map1/" + inputMapID;
        Debug.Log(requestMapID);
        StartCoroutine(GetRequest(requestMapID));
    }

    IEnumerator GetRequest(string uri)
    {
        Debug.Log("ø‰√ª∫∏≥ø "+uri);
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            Debug.Log("ø‰√ªø»");
            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    string text = webRequest.downloadHandler.text;
                    Debug.Log(pages[page] + ":\nReceived: " + text.Replace("\\",""));
                    mapData.Add(JsonUtility.FromJson<MapData>(webRequest.downloadHandler.text));
                    SceneManager.LoadScene("MapSelectScene");
                    break;
                }
        }
    }


    void returnMapData(MapData mapData)
    {
        Debug.Log(mapData.mapName);
        createMap.clickButton(mapData);
    }
}

[System.Serializable]
public class Content
{
    public int kind;
    public float x;
    public float y;
    public float x2;
    public float y2;
}
[System.Serializable]
public class MapData
{
    public string mapName;
    public string userName;
    public string userProfile;
    public string mapId;
    public List<Content> content;
}