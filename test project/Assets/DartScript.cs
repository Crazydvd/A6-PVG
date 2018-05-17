using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartScript : MonoBehaviour {

    Rigidbody _rigidbody;
    Collider[] _colliders;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _colliders = GetComponents<Collider>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag != "Trap")
        {
            Debug.Log(other.transform.name);
            _rigidbody.isKinematic = true;
            _rigidbody.velocity = Vector3.zero;
            foreach(Collider collider in _colliders) collider.enabled = false;
            transform.parent = other.transform;
        }
    }
}
