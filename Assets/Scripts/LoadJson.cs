using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft;
using System;

public class LoadJson : MonoBehaviour
{
    public static List<MapData> mapData = new List<MapData>();
    public SelectMapController selectMapController;
    public Canvas canvas;
    public CreateMap createMap;
    public MapData mapdata;
    public string PlayerEMail;

    public User user =  new User();

    private void Awake()
    {
        /*createMap = GameObject.Find("MapMaker").GetComponent<CreateMap>();
        if (mapData.Count != 0)
        {
            foreach (MapData nowMapData in mapData)
            {
                canvas = transform.GetComponentInChildren<Canvas>();
                Debug.Log("Scroll View/Viewport/Content/MapButtons(Clone)/" + nowMapData.mapName);
                canvas.transform.Find("Scroll View/Viewport/Content/MapButtons(Clone)/" + nowMapData.mapName).GetComponent<Button>().onClick.AddListener(() => { returnMapData(nowMapData); });
            }
        }*/
    }

    public void LoadStart()
    {
        Debug.Log(PlayerEMail);
        Debug.Log("http://13.125.40.125:8080/member/game/" + PlayerEMail);
        string requestMapID = "http://13.125.40.125:8080/member/game/" + "s21066@gsm.hs.kr";
        Debug.Log(requestMapID);
        StartCoroutine(GetRequest(requestMapID));
    }

    public void GetContent()
    {
        
    }

    IEnumerator GetRequest(string uri)
    {
        Debug.Log("ø‰√ª∫∏≥ø "+uri);

        UnityWebRequest handler = UnityWebRequest.Get(uri);

        Debug.Log(handler.downloadHandler.text);

        string temp = handler.downloadHandler.text;

        JObject jObj = new JObject();

        jObj = JObject.Parse(temp);

        JArray jAry = new JArray();

        jAry = JArray.Parse(jObj["maps"].ToString());

        foreach (JObject jo in jAry)
        {
            MapData mData = new MapData();

            mData.SetJsonData(jo);

            GameManager.instance.mapDataDict.Add(mData.mapId, mData);

            Debug.Log(GameManager.instance.mapDataDict.Count);
        }

        jAry = JArray.Parse(jObj["likes"].ToString());

        foreach(JObject jo in jAry)
        {
            MapData mData = new MapData();

            mData.SetJsonData(jo);

            GameManager.instance.likesDataDict.Add(mData.mapId, mData);

            Debug.Log(GameManager.instance.likesDataDict.Count);
        }

        //yield return handler.SendWebRequest();
        yield return null;
        //Debug.Log(jObj);


        /*using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
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
        }*/
    }

    IEnumerator GetRequest_Content(int mapId)
    {
        UnityWebRequest www = UnityWebRequest.Get("http://13.125.40.125:8080/map/getMap/" + mapId);
        yield return www.Send();

        string a = www.downloadHandler.text;

        a = a.Replace("\\", "");
        Debug.Log(a);

        JObject jObj = new JObject();

        jObj = JObject.Parse(a);

        JObject jSelectMap = new JObject();

        foreach (KeyValuePair<string, JToken> i in jObj)
        {
            jSelectMap = jObj[i.Key].ToObject<JObject>();
        }

        JArray jBlockAry = new JArray();
        jBlockAry = JArray.Parse(jSelectMap["block"].ToString());
        foreach (JObject value in jBlockAry)
        {
            Block block = new Block();

            block.SetJsonData(jSelectMap["mapId"].Value<string>(), value);

            Debug.Log(block.kind);

            Blocks.Add(block);
        }

        yield return null;
    }

    void returnMapData(MapData mapData)
    {
        Debug.Log(mapData.mapName);
        createMap.clickButton(mapData);
    }
}

[System.Serializable]
public class Block : TableBase
{
    public int mapId;
    public int kind;
    public float x;
    public float y;
    public float x2;
    public float y2;

    public override void SetJsonData(string key, JObject info)
    {
        base.SetJsonData(key, info);

        mapId = Int32.Parse(key);
        kind = info["kind"].Value<int>();
        x = info["x"].Value<float>();
            y = info["y"].Value<float>();
        x2 = info["x2"].Value<float>();
        y2 = info["y2"].Value<float>();
    }
}
[System.Serializable]
public class MapData : TableBase
{
    public int mapId;
    public string mapName;
    public string mapCode;
    public string img;
    public string userName;

    public override void SetJsonData(JObject info)
    {
        base.SetJsonData(info);

        mapId = info["mapId"].Value<int>();
        mapName = info["mapName"].Value<string>();
        mapCode = info["mapCode"].Value<string>();
        img = info["img"].Value<string>();
        userName = info["userName"].Value<string>();
    }
}

public class TableBase
{
    public virtual void SetJsonData(JObject info)
    {

    }
    public virtual void SetJsonData(string key, JObject info)
    {

    }
}

public class User 
{
    public List<MapData> user_map_datas = new List<MapData>();
    public List<MapData> user_like_map_datas = new List<MapData>();
}