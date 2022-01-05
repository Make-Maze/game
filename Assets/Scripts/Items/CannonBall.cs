using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float pjTime = 4;
    public PlayerMove playerMove;

    private void Awake()
    {
        StartCoroutine(BreakProjectile());
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Cannon") // 자기자신을 제외하고 부딪힌다면
        {
            if (collision.tag == "Player")
            {
                playerMove.GameOver();   
            }
            Destroy(gameObject); // 투사체 파괴
        }
    }

    IEnumerator BreakProjectile()
    {
        yield return new WaitForSeconds(pjTime);
        Destroy(gameObject);
    }

}
