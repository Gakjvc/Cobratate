using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calcada : MonoBehaviour
{
    GameObject[] floors;
    private void Start()
    {
        floors = GameObject.FindGameObjectsWithTag("Floor");
    }
    private void Update()
    {
        if (floors[0].transform.position.x != 0)
        {
            Debug.Log("A");
        }
    }
}
