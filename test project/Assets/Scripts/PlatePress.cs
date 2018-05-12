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
        _numberOfPressure++;
        if (_numberOfPressure == 1 && (other.tag == "Player" || other.tag == "Cube"))
        {
            _activate.OpenDoor();
            _activate.Animation();
        }
    }

    void OnTriggerExit(Collider other)
    {
        _numberOfPressure--;
        if (_numberOfPressure == 0 && (other.tag == "Player" || other.tag == "Cube"))
        {
            _activate.CloseDoor();
            _activate.Animation();
        }
    }
}
