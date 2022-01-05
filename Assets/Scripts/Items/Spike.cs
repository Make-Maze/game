using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public GameObject gameOverScreen;
    public PlayerMove playerMove;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (spriteRenderer.sprite.name == "Spike_Up")
        {
            playerMove.GameOver();
        }
    }
}
