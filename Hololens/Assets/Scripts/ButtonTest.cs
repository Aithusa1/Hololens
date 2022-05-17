using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    public GameObject cube;
    public Transform spawnPoint;

    public void OnButtonPressed()
    {
        Instantiate(cube, spawnPoint.position, spawnPoint.rotation);
    }
}
