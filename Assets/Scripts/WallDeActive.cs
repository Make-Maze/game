using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDeActive : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("DestroyWall", 2);
    }

    public void DestroyWall()
    {
        Destroy(transform.gameObject);
    }
}
