using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class ButtonMapData : MonoBehaviour
{
    public MapData mapData;

    public RawImage rawImage;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => { clickButton(); });
        rawImage = GetComponent<RawImage>();
        Debug.Log(mapData);
        Debug.Log(mapData.img);
    }

    private void Start()
    {
        Debug.Log(mapData);
        Debug.Log(mapData.img);
        StartCoroutine(DownloadImage(mapData.img));
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        Debug.Log(mapData.img + "º¸³¿");
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        Debug.Log(request.downloadHandler.text);
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            rawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }

    public void clickButton()
    {
        StartCoroutine(LoadJson.instance.GetRequest_Content(mapData.mapId));
        SceneManager.LoadScene("PlayScene");
    }
}
