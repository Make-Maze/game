using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public new Vector2 StartPoint;

    private GameManager instance;

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
