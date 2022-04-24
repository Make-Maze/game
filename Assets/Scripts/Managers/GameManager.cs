using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string PlayerEmail = null;

    public static GameManager instance;

    public Dictionary<int, MapData> mapDataDict = new Dictionary<int, MapData>();
    public Dictionary<int, MapData> likesDataDict = new Dictionary<int, MapData>();

    public List<Block> Blocks = new List<Block>();

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this);
    }
}
