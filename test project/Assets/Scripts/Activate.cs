using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    [HideInInspector]
    public bool activated;
    public GameObject interactive;
    private DoorController _door;
    private ElevatorController _elevator;

    private void Start()
    {
        if (interactive.tag == "Door")
            _door = interactive.GetComponentInChildren<DoorController>();
        else if (interactive.tag == "Elevator")
            _elevator = interactive.GetComponent<ElevatorController>();
    }

    public void Animation()
    {
        if (tag == "Lever")
            GetComponent<LeverAnimation>().PlayAnimation(activated);
        else if (tag == "Plate")
            GetComponent<PlateAnimation>().PlayAnimation(activated);
    }

    public void Action()
    {
        if (interactive.tag == "Door")
        {
            //Check if we are using lever
            if (tag == "Lever")
            {
                //If so make a delay for using it
                if (!_door.InProgress)
                {
                    activated = !activated;
                    _door.ToggleActive();
                }
            }
            else
            {
                activated = !activated;
                _door.ToggleActive();
            }
        }
        else if (interactive.tag == "Elevator")
        {
            activated = !activated;
            _elevator.ToggleACtive();
        }
    }


    //public void OpenDoor()
    //{
    //    //Check if we are using lever 
    //    if (tag == "Lever")
    //    {
    //        //If so make a delay for using it
    //        if (!_door.InProgress)
    //        {
    //            activated = true;
    //            _door.ChangeActivity();
    //        }
    //    }
    //    else
    //    {
    //        activated = true;
    //        _door.ChangeActivity();
    //    }
    //}

    //public void CloseDoor()
    //{
    //    //Check if we are using lever 
    //    if (tag == "Lever")
    //    {
    //        //If so make a delay for using it
    //        if (!_door.InProgress)
    //        {
    //            activated = false;
    //            _door.ChangeActivity();
    //        }
    //    }
    //    else
    //    {
    //        activated = false;
    //        _door.ChangeActivity();
    //    }
    //}
}