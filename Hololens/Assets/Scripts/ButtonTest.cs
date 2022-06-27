using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    public GameObject cube;
    public Transform spawnPoint;
    public List<GameObject> boxes = new List<GameObject>();

    public void OnButtonPressed()
    {
        if(boxes.Count <= 10)
        {
            GameObject box = Instantiate(cube, spawnPoint.position, spawnPoint.rotation);
            boxes.Add(box);
        }
        else
        {
            Debug.Log("no");
        }
        
    }

  
}
