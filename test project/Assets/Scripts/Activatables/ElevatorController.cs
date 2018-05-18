using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : Activatable
{
    ////>>>>>>>>>>>>HEAD 
    //public float speed = 0.05f;
    //public float maxHight;
    //private float minHight;
    ////=================
    private bool _active;
    private Transform _container;

    ////>>>>>>>>>>>NEW:
    [Tooltip("The time in seconds it takes to reach the new position")]
    public float Seconds = 1f;
    private Vector3 _oldPosition;
    private Vector3 _direction;
    private float _distance;
    private float _originalDistance;

    public GameObject NewPosition;

    private float _value;
    ////<<<<<<<<<<<<<<<<Danny

    List<GameObject> load = new List<GameObject>();

    void Start()
    {
        ////>>>>>>>>>>HEAD
        //minHight = transform.parent.position.y;
        ////==================
        _container = transform.parent.transform;


        ////>>>>>>>>>>>>NEW:
        _oldPosition = _container.position;
        Vector3 newPosition = NewPosition.transform.position;
        _direction = newPosition - _oldPosition;
        ////<<<<<<<<<<<<<<<<<<Danny
    }


    void Update()
    {
        ////>>>>>>>>>>>HEAD
        //if (_active)
        //{
        ////===========
            ////>>>>>>>>HEAD
            //if (_container.localPosition.y < maxHight)
            //{
            //    _container.position = _container.position + new Vector3(0, speed, 0);
            //}
            ////============================

            ////>>>>>>>>>NEW:
            if (_active)
            {
                if (_value < 1)
                {
                    _value += (1 / Seconds) * Time.deltaTime;
                }
                else
                {
                    _value = 1;
                }
            }
            else
            {
                if (_value > 0)
                {
                    _value -= (1 / Seconds) * Time.deltaTime;
                }
                else
                {
                    _value = 0;
                }
            }

            float t = Mathf.Lerp(0, 1, _value);
            _container.position = _oldPosition + (_direction * t);
            ////<<<<<<<<<<<<<<<<<<<<<<<<<<<<<Danny

        ////>>>>>>>>HEAD
        //}
        //else
        //{
        //    if (_container.localPosition.y > minHight)
        //    {
        //        _container.position = _container.position - new Vector3(0, speed, 0);
        //    }
        //}
        ////=======================
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


    override public void ToggleActive()
    {
        foreach (GameObject gObject in load)
            gObject.transform.parent = null;

        _active = !_active;
    }

    override public void ToggleActive(bool pActive)
    {
        foreach (GameObject gObject in load)
            gObject.transform.parent = null;

        _active = pActive;
    }
}