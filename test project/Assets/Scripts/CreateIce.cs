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
            Vector3 IcePosition = transform.position;
            IcePosition.y = other.transform.position.y + 0.01f;
            GameObject IcePlate = Instantiate(Ice, IcePosition, Quaternion.Euler(0, 0, 0));
            IcePlate.transform.SetParent(other.transform);
            Destroy(gameObject);
        }

        if (other.tag == "Cube")
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ice")
        {
            IceMelt melt = collision.gameObject.GetComponent<IceMelt>();
            melt.MeltTime *= 1.2f;
        }

        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}