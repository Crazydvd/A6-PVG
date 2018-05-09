using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "death")
        {
            Debug.Log("You died! ;(");
        }
    }
}
