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
    private float _inProgress;

    private void Start()
    {
        if (interactive.tag == "Door")
            _door = interactive.GetComponentInChildren<DoorController>();
        else if (interactive.tag == "Elevator")
            _elevator = interactive.GetComponent<ElevatorController>();

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
        //Light
        else if (interactive.tag == "Light")
        {
            activated = !activated;
            interactive.gameObject.SetActive(!interactive.gameObject.activeSelf);
        }
    }
}