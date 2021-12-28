using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringShoes : MonoBehaviour
{
    Vector2 size = new Vector2(3, 3);
    public LayerMask Wall;
    float closestDistance;
    Vector2 nowOffset;
    PlayerMove playerMove;
    Transform player;

    int playerLayer, wallLayer;

    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    private void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        wallLayer = LayerMask.NameToLayer("Wall");
        player = GameObject.Find("Player").transform.GetComponent<Transform>();
    }

    public void useSpringShoes()
    {
        if (Physics2D.OverlapBoxAll(player.position, size, 0, Wall).Length != 0)
        {
            Transform closestWall = null;
            Collider2D[] hit = Physics2D.OverlapBoxAll(player.position, size, 0, Wall);
            Transform walls = GetComponent<Transform>();
            for (int i = 0; i < hit.Length; i++)
            {
                walls = hit[i].GetComponent<Transform>();
                nowOffset = (player.position - walls.transform.position);
                float nowWallDistance = nowOffset.sqrMagnitude;
                if (i == 0 || (nowWallDistance < closestDistance))
                {
                    closestDistance = nowWallDistance;
                    closestWall = walls.GetComponent<Transform>();
                }
            }
            Debug.Log(closestWall.name);
            Physics2D.IgnoreLayerCollision(playerLayer, wallLayer, true);
            player.position = Vector2.MoveTowards(player.position, (closestWall.position + (closestWall.position - player.position)), 120 * Time.deltaTime);
            Physics2D.IgnoreLayerCollision(playerLayer, wallLayer, false);
        }
    }
}