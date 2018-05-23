using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{

    Vector3 _spawnPoint;
    Rigidbody _rigidBody;

    // Use this for initialization
    void Start()
    {
        _spawnPoint = transform.position;
        _rigidBody = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "death")
        {
            transform.position = _spawnPoint;
            if (transform.parent != null)
            {
                if (transform.parent.tag == "Player")
                {
                    transform.parent.GetComponent<Interact>().ReleaseObject();
                }
                else
                {
                    transform.parent = null;
                }
            }
        }
    }

    // prevent the box from glitching upwards
    void FixedUpdate()
    {
        if (Time.timeScale == 0)
            return;

        if (_rigidBody.velocity.y > 0f)
        {
            _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, 0f, _rigidBody.velocity.z);
        }
    }

    // prevent the player from glitching into the cube
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player" && transform.parent == other.transform)
        {
            _rigidBody.velocity.Set(_rigidBody.velocity.x, 0f, _rigidBody.velocity.z);
            other.transform.GetComponent<Interact>().ReleaseObject();
        }
    }
}
