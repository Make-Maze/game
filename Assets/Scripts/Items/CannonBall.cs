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
        if (collision.tag != "Cannon") // �ڱ��ڽ��� �����ϰ� �ε����ٸ�
        {
            if (collision.tag == "Player")
            {
                playerMove.GameOver();   
            }
            Destroy(gameObject); // ����ü �ı�
        }
    }

    IEnumerator BreakProjectile()
    {
        yield return new WaitForSeconds(pjTime);
        Destroy(gameObject);
    }

}
