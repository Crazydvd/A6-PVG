using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    private void Start()
    {
        GetComponent<SphereCollider>().radius = GetComponent<Light>().range/2;
    }
}
