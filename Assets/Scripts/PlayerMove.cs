using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveX;
    private float moveY;
    public float moveSpeed=5f;
    public float xLimitSize;
    private float yLimitSize;

    private void FixedUpdate()
    {
        Move();
        LimitMove();
        Debug.Log(moveSpeed);
    }

    void Move()
    {

        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        Vector2 vec = new Vector2(moveX, moveY).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(vec);
    }

    void LimitMove()
    {
        yLimitSize = xLimitSize + 0.01f;
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 1 - xLimitSize)
            pos.x = 1 - xLimitSize;
        else if (pos.x > xLimitSize)
            pos.x = xLimitSize;
        else if (pos.y < 1 - yLimitSize)
            pos.y = 1 - yLimitSize;
        else if (pos.y > yLimitSize)
            pos.y = yLimitSize;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    public void IncreaseSpeed(float plusSpeed)
    {
        moveSpeed += plusSpeed;
        StartCoroutine(DecreaseSpeed(plusSpeed));
    }


    IEnumerator DecreaseSpeed(float minusSpeed)
    {
        yield return new WaitForSeconds(5);
        moveSpeed -= minusSpeed;
    }
}
