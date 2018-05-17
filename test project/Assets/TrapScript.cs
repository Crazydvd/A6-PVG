using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : Activatable {

    [SerializeField] private GameObject _dart;
    [SerializeField] private float _speed = 1000f;

    private bool _active;
	
	// Update is called once per frame
	void Update () {
        if (_active)
        {
            foreach(Transform child in transform.GetComponentInChildren<Transform>())
            {
                GameObject dart = Instantiate(_dart, child.position, Quaternion.FromToRotation(Vector3.up, transform.forward));
                dart.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
                Destroy(dart, 5f);
            }
            _active = false;
        }
	}

    public override void ToggleActive()
    {
        _active = !_active;
    }

    public override void ToggleActive(bool pActive)
    {
        _active = pActive;
    }
}
