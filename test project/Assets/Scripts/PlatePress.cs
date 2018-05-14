using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatePress : MonoBehaviour
{
    private Activate _activate;
    private int _numberOfPressure;

    void Start()
    {
        _activate = GetComponent<Activate>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Cube")
        {
            _numberOfPressure++;

            if (_numberOfPressure == 1)
            {
                _activate.Action();
                _activate.Animation();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Cube")
        {
            _numberOfPressure--;
            if (_numberOfPressure <= 0)
                _numberOfPressure = 0;

            if (_numberOfPressure == 0)
            {
                _activate.Action();
                _activate.Animation();
            }
        }
    }
}
