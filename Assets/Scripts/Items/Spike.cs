using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public GameObject gameOverScreen;
    private GameObject player;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (spriteRenderer.sprite.name == "Spike_Up")
        {
            Destroy(player);
            gameOverScreen.SetActive(true);
        }
    }
}
