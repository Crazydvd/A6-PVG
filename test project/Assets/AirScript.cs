using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirScript : MonoBehaviour {

    [SerializeField] private float pushForce = 1000f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Cube")
        {
            Vector3 direction = (collision.transform.position - transform.position).normalized;
            direction.y = 0;

            collision.transform.GetComponent<Rigidbody>().AddForce(direction * pushForce);
        }
        if (collision.transform.tag != "Player")
            Destroy(gameObject);
    }
}
