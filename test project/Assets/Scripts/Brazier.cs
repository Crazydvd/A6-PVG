﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brazier : MonoBehaviour
{
    public bool Lid;
    public GameObject Door;
    private DoorController _door;

    private void Start()
    {
        _door = Door.GetComponentInChildren<DoorController>();
        if (Lid)
        {
            _door.Open();
        }
    }

    public void Light()
    {
        Lid = true;
        _door.Open();
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Extinguish()
    {
        Lid = false;
        _door.Close();
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
