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
    public MapData mapdata;

    public User user = new User();

    public static LoadJson instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
        //createMap = GameObject.Find("MapMaker").GetComponent<CreateMap>();
        //if (mapData.Count != 0)
        //{
        //    foreach (MapData nowMapData in mapData)
        //    {
        //        canvas = transform.GetComponentInChildren<Canvas>();
        //        Debug.Log("Scroll View/Viewport/MyMaps/MapButtons(Clone)/" + nowMapData.mapName);
        //        canvas.transform.Find("Scroll View/Viewport/MyMaps/MapButtons(Clone)/" + nowMapData.mapName).GetComponent<Button>().onClick.AddListener(() => { returnMapData(nowMapData); });
        //    }
        //}
    }

    public void LoadStart()
    {
        Debug.Log(GameManager.instance.PlayerEmail);
        Debug.Log("http://13.125.40.125:8080/member/game/" + GameManager.instance.PlayerEmail);
        string requestMapID = "http://13.125.40.125:8080/member/game/" + GameManager.instance.PlayerEmail;
        Debug.Log("http://13.125.40.125:8080/member/game/makeandmaze@gmail.com");
        Debug.Log(requestMapID);
        StartCoroutine(GetRequest(requestMapID));
    }

    IEnumerator GetRequest(string uri)
    {
        Debug.Log("ø‰√ª∫∏≥ø " + uri);


        UnityWebRequest handler = UnityWebRequest.Get(uri);

        yield return handler.Send();

        Debug.Log(handler.downloadHandler.text);

        string temp = handler.downloadHandler.text;

        JObject jObj = new JObject();

        jObj = JObject.Parse(temp);

        JArray jAry = new JArray();

        switch (handler.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                GetRequest(uri);
                break;
            case UnityWebRequest.Result.ProtocolError:
                GetRequest(uri);
                break;
            case UnityWebRequest.Result.Success:
                jAry = JArray.Parse(jObj["maps"].ToString());

                GameManager.instance.mapDataDict.Clear();
                GameManager.instance.likesDataDict.Clear();
                foreach (JObject jo in jAry)
                {
                    MapData mData = new MapData();

                    mData.SetJsonData(jo);

                    GameManager.instance.mapDataDict.Add(mData.mapId, mData);
                }

                jAry = JArray.Parse(jObj["likes"].ToString());

                foreach (JObject jo in jAry)
                {
                    MapData mData = new MapData();

                    mData.SetJsonData(jo);

                    GameManager.instance.likesDataDict.Add(mData.mapId, mData);

                    Debug.Log(GameManager.instance.likesDataDict.Count);
                }
                SceneManager.LoadScene("MapSelectScene");

                break;
        }

    }

    public UnityWebRequest.Result GetSuccess()
    {
        return UnityWebRequest.Result.Success;
    }

    public IEnumerator GetRequest_Content(int mapId, UnityWebRequest.Result success)
    {
        GameManager.instance.Blocks.Clear();
        Debug.Log("Ω««‡µ ?2");
        UnityWebRequest www = UnityWebRequest.Get("http://13.125.40.125:8080/map/getMap/" + mapId);
        Debug.Log("http://13.125.40.125:8080/map/getMap/" + mapId);
        yield return www.Send();
        Debug.Log("Ω««‡µ ?3");

        string a = www.downloadHandler.text;

        a = a.Replace("\\", "");
        Debug.Log(a);

        JObject jObj = new JObject();

        jObj = JObject.Parse(a);

        JObject jSelectMap = new JObject();

        switch (www.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                GetRequest_Content(mapId, GetSuccess());
                break;
            case UnityWebRequest.Result.ProtocolError:
                GetRequest_Content(mapId, GetSuccess());
                break;
            case UnityWebRequest.Result.Success:
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

                    GameManager.instance.Blocks.Add(block);
                }
                Debug.Log(GameManager.instance.Blocks.Count);
                SceneManager.LoadScene("PlayScene");
                break;
        }


    }

    //void returnMapData(MapData mapData)
    //{
    //    Debug.Log(mapData.mapName);
    //    createMap.clickButton(mapData);
    //}
}

#region Json Class
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
#endregion