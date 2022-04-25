using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveX;
    private float moveY;
    public float originalSpeed = 5f;
    public float moveSpeed=5f;
    public GameObject gameOverScreen;

    public void Move(Vector2 moveVec)
    {

        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        Vector2 vec = moveVec * moveSpeed * Time.deltaTime;
        transform.Translate(vec);
    }

    public void IncreaseSpeed(float plusSpeed)
    {
        if (moveSpeed == originalSpeed)
        {
        moveSpeed += plusSpeed;
        StartCoroutine(DecreaseSpeed(plusSpeed));
        }
    }

    public void GameOver()
    {
        Destroy(gameObject);
        Instantiate(gameOverScreen);
        //gameOverScreen.SetActive(true);
    }

    IEnumerator DecreaseSpeed(float minusSpeed)
    {
        yield return new WaitForSeconds(5);
        moveSpeed -= minusSpeed;
    }
}
