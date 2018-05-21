using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    Rigidbody _rigidbody;
    Vector3 _direction;

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        _direction = _rigidbody.velocity;
        transform.rotation = Quaternion.FromToRotation(Vector3.right, _direction);
    }
}
