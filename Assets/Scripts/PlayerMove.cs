using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveX;
    private float moveY;
    public float moveSpeed=5f;

    private void FixedUpdate()
    {
        Move();
        Debug.Log(moveSpeed);
    }

    void Move()
    {

        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        Vector2 vec = new Vector2(moveX, moveY).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(vec);
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
