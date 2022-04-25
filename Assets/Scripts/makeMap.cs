using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeMap : MonoBehaviour
{
    public CreateMap cm;
    private void Awake()
    {
        cm = FindObjectOfType<CreateMap>();
        cm.Walls = gameObject;
        cm.MakeMap();
    }
}