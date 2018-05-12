using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    [HideInInspector]
    public bool activated;
    public GameObject door;
    private DoorController _door;

    private void Start()
    {
        _door = door.GetComponentInChildren<DoorController>();
    }

    public void Animation()
    {
        if (tag == "Lever")
            GetComponent<LeverAnimation>().PlayAnimation(activated);
        else
            GetComponent<PlateAnimation>().PlayAnimation(activated);
    }

    public void OpenDoor()
    {
        //Check if we are using lever 
        if (tag == "Lever")
        {
            //If so make a delay for using it
            if (!_door.InProgress)
            {
                activated = true;
                _door.Open();

            }
        }
        else
        {
            activated = true;
            _door.Open();
        }
    }

    public void CloseDoor()
    {
        //Check if we are using lever 
        if (tag == "Lever")
        {
            //If so make a delay for using it
            if (!_door.InProgress)
            {
                activated = false;
                _door.Close();

            }
        }
        else
        {
            activated = false;
            _door.Close();
        }
    }
}