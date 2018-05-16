using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    [HideInInspector]
    public bool activated;
    public GameObject activatable;
    private DoorController _door;
    private ElevatorController _elevator;
    private float _inProgress;
    private MoveWater _water;

    private void Start()
    {
        if (activatable != null)
        {
            if (activatable.tag == "Door")
                _door = activatable.GetComponentInChildren<DoorController>();
            else if (activatable.tag == "Elevator")
                _elevator = activatable.GetComponent<ElevatorController>();
            else if (activatable.tag == "water")
                _water = activatable.GetComponent<MoveWater>();
        }
        else
        {
            if (tag != "brazier")
            {
                throw new System.Exception("You did not assign the Activatable in the Activate script on " + gameObject.name);
            }
        }
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
        activated = !activated;
        if (activatable == null)        
            return;        

        if (tag == "Lever")
        {
            if (_inProgress > 0)
                return;
            _inProgress = 2;
        }

        //Door
        if (activatable.tag == "Door")
        {
            _door.ToggleActive();

        }
        //Elevator
        else if (activatable.tag == "Elevator")
        {
            _elevator.ToggleACtive();
        }
        //Light
        else if (activatable.tag == "Light")
        {
            activatable.gameObject.SetActive(!activatable.gameObject.activeSelf);
        }
        //Water
        else if (activatable.tag == "water")
        {
            _water.ToggleActive();
        }
    }
}