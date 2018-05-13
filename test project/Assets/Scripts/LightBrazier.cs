using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBrazier : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "brazier")
        {
            collision.gameObject.GetComponent<Brazier>().Light();
        }
    }
}