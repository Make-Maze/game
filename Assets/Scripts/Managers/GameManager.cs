using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public new Vector2 StartPoint;

    public static GameManager instance;

    public Dictionary<int, MapData> mapDataDict = new Dictionary<int, MapData>();
    public Dictionary<int, MapData> likesDataDict = new Dictionary<int, MapData>();

    public List<Content> content = new List<Content>();

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this);

        StartPoint = new Vector2(0.5f, 38.5f);
        Instantiate(Player, StartPoint, Quaternion.identity).name = "Player";

    }



}
