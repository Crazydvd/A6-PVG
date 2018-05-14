using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour {

    Vector3 _spawnPoint;

	// Use this for initialization
	void Start () {
        _spawnPoint = transform.position;
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "death")
        {
            transform.position = _spawnPoint;
        }
    }
}
