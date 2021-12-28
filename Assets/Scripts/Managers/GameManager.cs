using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public Transform StartPoint;

    public void Awake()
    {
        StartPoint = GameObject.Find("StartPoint").transform;
        StartPoint.GetComponent<Transform>();
        Instantiate(Player, StartPoint.position, Quaternion.identity).name="Player";
    }
}
