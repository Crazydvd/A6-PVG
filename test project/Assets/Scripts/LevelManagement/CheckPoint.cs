using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private bool _activated;

    public int CheckPointNumber { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.tag == "Player" && !_activated)
        {
            LevelManager.ReachCheckPoint(CheckPointNumber);
            _activated = true;
        }
    }
}