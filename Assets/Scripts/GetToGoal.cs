using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetToGoal : MonoBehaviour
{
    public GameObject ClearScreen;

    //private void Start()
    //{
    //    ClearScreen = GameObject.Find("ClearScreen");
    //    ClearScreen.SetActive(false);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ClearScreen.SetActive(true);
    }
}
