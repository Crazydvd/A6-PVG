using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    [HideInInspector]
    public bool activated;
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
            if (tag == "Lever")
                GetComponent<LeverAnimation>().PlayAnimation(activated);
            else
                GetComponent<PlateAnimation>().PlayAnimation(activated);
        }
    }

    public void activateDoor()
    {
        _openDoor.Open();
    }
}