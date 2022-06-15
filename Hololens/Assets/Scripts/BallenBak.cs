using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallenBak : MonoBehaviour
{
    public GameObject[] cube;
    public Transform spawnPoint;

    public void OnButtonPressed()
    {
        Instantiate(cube[Random.Range(0,cube.Length)], spawnPoint.position, spawnPoint.rotation);
    }
}
