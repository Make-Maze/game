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
        player = collision.transform;
        player.position = new Vector2(targetPortal.position.x, targetPortal.position.y - 1);
    }
}