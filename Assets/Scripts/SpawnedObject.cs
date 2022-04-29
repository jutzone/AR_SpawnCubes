using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObject : MonoBehaviour
{
    public int Points;
    private void OnEnable()
    {
        Points = Random.Range(1, 4);
        switch (Points)
        {
            case 1:
                GetComponent<Renderer>().material.color = Color.red;
                break;
            case 2:
                GetComponent<Renderer>().material.color = Color.green;
                break;
            case 3:
                GetComponent<Renderer>().material.color = Color.blue;
                break;
        }
    }
}
