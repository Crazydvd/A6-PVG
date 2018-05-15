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
<<<<<<< HEAD
    private float _inProgress;
=======
    private MoveWater _water;
>>>>>>> 185169b8ba7f00d5c4c4a5bd60f4f9c63ae7974d

    private void Start()
    {
        if (interactive.tag == "Door")
            _door = interactive.GetComponentInChildren<DoorController>();
        else if (interactive.tag == "Elevator")
            _elevator = interactive.GetComponent<ElevatorController>();
<<<<<<< HEAD

    }

    void Update()
    {
        if (tag == "Lever")
            if (_inProgress > 0)
            {
                _inProgress -= Time.deltaTime;
                if (_inProgress < 0)
                    _inProgress = 0;
            }
=======
        else if (interactive.tag == "water")
            _water = interactive.GetComponent<MoveWater>();
>>>>>>> 185169b8ba7f00d5c4c4a5bd60f4f9c63ae7974d
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
        if (tag == "Lever")
        {
            if (_inProgress > 0)
                return;
            _inProgress = 2;
        }

        //Door
        if (interactive.tag == "Door")
        {
            activated = !activated;
            _door.ToggleActive();

        }
        //Elevator
        else if (interactive.tag == "Elevator")
        {
            activated = !activated;
            _elevator.ToggleACtive();
        }
<<<<<<< HEAD
        //Light
        else if (interactive.tag == "Light")
        {
            activated = !activated;
            interactive.gameObject.SetActive(!interactive.gameObject.activeSelf);
=======
        else if (interactive.tag == "water")
        {
            if (tag == "Lever")
            {
                //If so make a delay for using it
                if (!_water.InProgress)
                {
                    activated = !activated;
                    _water.ToggleActive();
                }
            }
            else
            {
                activated = !activated;
                _water.ToggleActive();
            }
>>>>>>> 185169b8ba7f00d5c4c4a5bd60f4f9c63ae7974d
        }
    }
}