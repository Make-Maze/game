using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringShoes : MonoBehaviour
{
    RaycastHit2D upHit;
    RaycastHit2D leftHit;
    RaycastHit2D rightHit;
    RaycastHit2D downHit;
    GameObject closestWall;
    float maxDistance = 2f;

    void Start()
    {
        upHit = GetComponent<RaycastHit2D>();
        leftHit = GetComponent<RaycastHit2D>();
        rightHit = GetComponent<RaycastHit2D>();
        downHit = GetComponent<RaycastHit2D>();
    }

    void useSpringShoes()
    {
        Debug.DrawRay(transform.position, Vector2.up * maxDistance, Color.cyan);
        upHit = Physics2D.Raycast(transform.position, Vector2.up, maxDistance);

        Debug.DrawRay(transform.position, Vector2.left * maxDistance, Color.cyan);
        leftHit = Physics2D.Raycast(transform.position, Vector2.left, maxDistance);

        Debug.DrawRay(transform.position, Vector2.right * maxDistance, Color.cyan);
        rightHit = Physics2D.Raycast(transform.position, Vector2.right, maxDistance);

        Debug.DrawRay(transform.position, Vector2.down * maxDistance, Color.cyan);
        downHit = Physics2D.Raycast(transform.position, Vector2.down, maxDistance);

        upHit.transform.position;
    }
}
