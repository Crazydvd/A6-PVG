using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    private void Start()
    {
        GetComponent<SphereCollider>().radius = GetComponent<Light>().range/2;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("LightScript (Point light): you are lit");
        }
    }
}
