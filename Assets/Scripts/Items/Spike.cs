using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public GameObject gameOverScreen;
    public PlayerMove playerMove;
    public GameObject player;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();
    }

    private void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (spriteRenderer.sprite.name == "Spike_Up" && collision.CompareTag("Player"))
        {
            playerMove.GameOver();
        }
    }
}
