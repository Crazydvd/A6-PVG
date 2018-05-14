using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public float speed = 0.05f;
    public float maxHight;
    private float minHight;
    private bool _active;

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
    
    public void ToggleACtive()
    {
        _active = !_active;
    }

}
