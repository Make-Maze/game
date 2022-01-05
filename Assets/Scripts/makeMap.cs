using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateMap cm = GameObject.Find("MapMaker").GetComponent<CreateMap>();
        Debug.Log(cm.mapData);


        Debug.Log(cm.mapData.mapId);
        Debug.Log(cm.mapData.content.Count);

        foreach (var block in cm.mapData.content)
        {
            Debug.Log(block.kind);
            Debug.Log(block.x);
            Debug.Log(block.y);
            Debug.Log(block.x2);
            Debug.Log(block.y2);
            Debug.Log(cm.gameObjects[block.kind]);
            Vector3 blockLoc = new Vector3(block.x, block.y);
            if (block.kind == 9)
            {
                Vector3 blockLoc2 = new Vector3(block.x2, block.y2);
                Transform portals = Instantiate(cm.gameObjects[block.kind], new Vector3(0, 0), Quaternion.identity).GetComponent<Transform>();
                portals.transform.SetParent(GameObject.Find("Walls").transform);
                portals.transform.GetChild(0).position = blockLoc;
                portals.transform.GetChild(1).position = blockLoc2;
            }
            else
            {

                Instantiate(cm.gameObjects[block.kind], blockLoc, Quaternion.identity).GetComponent<Transform>();
                Transform creatingObject = Instantiate(cm.gameObjects[block.kind], blockLoc, Quaternion.identity).GetComponent<Transform>();
                creatingObject.transform.SetParent(GameObject.Find("Walls").transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
