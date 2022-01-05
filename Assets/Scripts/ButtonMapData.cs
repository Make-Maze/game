using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMapData : MonoBehaviour
{
    public static MapData mapData;

    private void Awake()
    {
        mapData = LoadJson.mapData[LoadJson.mapData.Count-1];
        
    }
}
