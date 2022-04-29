using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveX;
    private float moveY;
    public float originalSpeed = 5f;
    public float moveSpeed = 5f;
    public float tpCoolDown = 0;

    public float buffTime = 0;

    //public PlaySceneManager psm;

    private void Update()
    {
        if (buffTime > 0)
        {
            buffTime -= Time.deltaTime;
            if (buffTime <= 0)
                moveSpeed -= 2;
        }
        if (tpCoolDown > 0)
        {
            tpCoolDown -= Time.deltaTime;
        }
    }

    public void Move(Vector2 moveVec)
    {

        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        Vector2 vec = moveVec * moveSpeed * Time.deltaTime;
        transform.Translate(vec);
    }

    public void IncreaseSpeed()
    {
        if (moveSpeed == originalSpeed)
        {
            moveSpeed = 7;
            buffTime = 3;
        }
    }

    public void GameOver()
    {
        if (gameObject != null)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
