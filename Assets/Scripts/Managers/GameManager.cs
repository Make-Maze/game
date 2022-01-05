using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public new Vector2 StartPoint;

    public void Awake()
    {
        StartPoint = new Vector2(0.5f, 38.5f);
        Instantiate(Player, StartPoint, Quaternion.identity).name = "Player";
    }


}
