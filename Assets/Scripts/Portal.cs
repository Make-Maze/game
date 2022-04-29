using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform targetPortal;
    private Transform player;

    private void Start()
    {
        targetPortal.GetComponent<Transform>();
        player = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.gameObject.GetComponent<PlayerMove>().tpCoolDown <= 0&&collision.CompareTag("Player"))
        {
            player.position = new Vector2(targetPortal.position.x, targetPortal.position.y);
            player.gameObject.GetComponent<PlayerMove>().tpCoolDown = 1;
        }
    }
}