using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : MonoBehaviour
{
    PlayerMove playerMove;

    private void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMove.IncreaseSpeed(2);
        Destroy(gameObject);
    }
}
