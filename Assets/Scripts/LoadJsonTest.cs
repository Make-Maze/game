using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadJsonTest : MonoBehaviour
{
    public List<MapData> mapData = new List<MapData>();
    public SelectMapController selectMapController;

    public void LoadStart()
    {
        selectMapController = GetComponent<SelectMapController>();
        // A non-existing page.
        StartCoroutine(GetRequest("http://127.0.0.1:8000/"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

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
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    mapData.Add(JsonUtility.FromJson<MapData>(webRequest.downloadHandler.text));
                    selectMapController.CreatMapButton(mapData[mapData.Count-1]);
                    break;
            }
        }
    }
}

[System.Serializable]
public class MapData
{
    public string mapName;
    public float[][] blocks;
}