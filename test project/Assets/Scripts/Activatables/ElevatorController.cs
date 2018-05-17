using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public float speed = 0.05f;
    public float maxHight;
    private float minHight;
    private bool _active;
    private Transform _container;

    List<GameObject> load = new List<GameObject>();

    void Start()
    {
        minHight = transform.parent.position.y;
        _container = transform.parent.transform;
    }


    void Update()
    {
        if (_active)
        {
            if (_container.localPosition.y < maxHight)
            {
                _container.position = _container.position + new Vector3(0, speed, 0);
            }
        }
        else
        {
            if (_container.localPosition.y > minHight)
            {
                _container.position = _container.position - new Vector3(0, speed, 0);
            }
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Cube" && other.transform.parent == null)
        {
            if (!load.Contains(other.gameObject))
            {
                load.Add(other.gameObject);
            }
            other.transform.parent = _container;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.parent == _container)
        {
            other.transform.parent = null;
        }
    }


    public void ToggleActive()
    {
        foreach (GameObject gObject in load)
            gObject.transform.parent = null;

        _active = !_active;
    }
}
