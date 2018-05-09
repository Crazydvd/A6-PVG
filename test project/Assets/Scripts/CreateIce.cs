using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateIce : MonoBehaviour
{
    public GameObject Ice;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "water")
        {
            Vector3 something = transform.position;
            something.y = other.transform.position.y;
            GameObject IcePlate = Instantiate(Ice, something, Quaternion.Euler(0, 0, 0));
            IcePlate.transform.SetParent(other.transform);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}