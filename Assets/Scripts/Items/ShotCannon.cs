using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCannon : MonoBehaviour
{
    public GameObject projectile; // 투사체 오브젝트
    private GameObject player;
    public float projectileForce; // 투사체 속도
    public float cooldown = 2;
    public string direction;
    private Vector2 shotDirection;

    private void Start()
    {
        StartCoroutine(ShootingPlayer());
        player = FindObjectOfType<PlayerMove>().gameObject;
    }

    IEnumerator ShootingPlayer()
    {
        yield return new WaitForSeconds(cooldown);
        if (player == null)
            player = FindObjectOfType<PlayerMove>().gameObject;
        if (player != null)
        {
            switch (direction)
            {
                case "up":
                    shotDirection = Vector2.up;
                    break;
                case "down":
                    shotDirection = Vector2.down;
                    break;
                case "left":
                    shotDirection = Vector2.left;
                    break;
                case "right":
                    shotDirection = Vector2.right;
                    break;
            }
            GameObject shot = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 myPos = transform.position;
            Vector2 targetPos = player.transform.position;
            shot.GetComponent<Rigidbody2D>().velocity = shotDirection * projectileForce;
            StartCoroutine(ShootingPlayer());
        }
    }

}
