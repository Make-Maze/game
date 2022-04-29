using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetToGoal : MonoBehaviour
{
    public GameObject ClearScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;
            ClearScreen.SetActive(true);
        }
    }
}
