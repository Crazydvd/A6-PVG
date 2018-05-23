using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : Activatable
{
    private bool _active;
    private Transform _container;

    [Tooltip("The time in seconds it takes to reach the new position")]
    public float Seconds = 1f;
    private Vector3 _oldPosition;
    private Vector3 _direction;

    public GameObject NewPosition;

    private float _value;

    List<GameObject> load = new List<GameObject>();

    [Tooltip("If this is true the platform will keep going back and forth until it's deactivated")]
    public bool KeepGoing = false;
    private bool _back = false;

    void Start()
    {
        _container = transform.parent.transform;

        _oldPosition = _container.position;
        Vector3 newPosition = NewPosition.transform.position;
        _direction = newPosition - _oldPosition;
    }


    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        if (KeepGoing && _active)
        {
            if (!_back)
            {
                if (_value < 1)
                    _value += (1 / Seconds) * Time.deltaTime;
                else
                    _back = true;
            }
            else
            {
                if (_value > 0)
                    _value -= (1 / Seconds) * Time.deltaTime;
                else
                    _back = false;
            }

            float t = Mathf.Lerp(0, 1, _value);
            _container.position = _oldPosition + (_direction * t);
        }
        else
        {
            if (_active)
            {
                if (_value < 1)
                    _value += (1 / Seconds) * Time.deltaTime;
                else
                    _value = 1;
            }
            else
            {
                if (_value > 0)
                    _value -= (1 / Seconds) * Time.deltaTime;
                else
                    _value = 0;
            }

            float t = Mathf.Lerp(0, 1, _value);
            _container.position = _oldPosition + (_direction * t);
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