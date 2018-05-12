using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    private bool activated;
    public GameObject door;
    private OpenDoor _openDoor;

    private void Start()
    {
        _openDoor = door.GetComponentInChildren<OpenDoor>();
    }

    public void ActivateObject()
    {
        if (_openDoor.InProgress == false)
        {
            activated = !activated;
            Debug.Log(activated);
            GetComponent<LeverAnimation>().PlayAnimation(activated);
        }
    }

    public void activateDoor()
    {
        _openDoor.Open();
    }
}