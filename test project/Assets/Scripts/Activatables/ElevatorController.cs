using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public float speed = 0.05f;
    public float maxHight;
    private float minHight;
    private bool _active;

    List<GameObject> load = new List<GameObject>();

    void Start()
    {
        minHight = transform.position.y;
    }


    void Update()
    {
        if (_active)
        {
            if (transform.localPosition.y < maxHight)
            {
                transform.position = transform.position + new Vector3(0, speed, 0);
            }
        }
        else
        {
            if (transform.localPosition.y > minHight)
            {
                transform.position = transform.position - new Vector3(0, speed, 0);
            }
        }

    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Cube" && other.transform.parent == null)
        {
            if (!load.Contains(other.gameObject))
            {
                load.Add(other.gameObject);
            }
            other.transform.parent = transform;
        }        
    }

    void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }


    public void ToggleACtive()
    {
        foreach (GameObject gObject in load)
            gObject.transform.parent = null;

        _active = !_active;
    }
}
