using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : MonoBehaviour
{
    public PlayerMove playerMove;
    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(playerMove.moveSpeed);
        Debug.Log(playerMove.originalSpeed);
        if (playerMove.moveSpeed == playerMove.originalSpeed&&collision.CompareTag("Player"))
        {
            playerMove.IncreaseSpeed();
        }
        Destroy(gameObject);
    }
}
