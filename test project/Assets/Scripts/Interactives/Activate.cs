using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    [HideInInspector]
    public bool activated;
    private float _inProgress;

    [Tooltip("The list of activatables that this object activates")]
    public List<Activatable> Activatables = new List<Activatable>();

    public ActivateMode Mode = ActivateMode.TOGGLE;

    public enum ActivateMode
    {
        ON,
        OFF,
        TOGGLE,
        STATETOGGLE,
    }

    private void Start()
    {
        if (Activatables.Contains(null))
        {
            foreach (Activatable item in Activatables)
            {
                if (item == null)
                {
                    throw new System.Exception("You did not assign all Activatables in the Activate script on " + gameObject.name);
                }
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

        if (tag == "Lever")
        {
            if (_inProgress > 0)
            {
                activated = !activated;
                return;
            }

            _inProgress = 2;
            Animation();
        }

        if (Activatables.Count == 0)
            return;

        if (Mode == ActivateMode.TOGGLE)
        {
            foreach (Activatable item in Activatables)
            {
                item.ToggleActive();
            }
        }
        else if (Mode == ActivateMode.ON)
        {
            foreach (Activatable item in Activatables)
            {
                item.ToggleActive(true);
            }
        }
        else if (Mode == ActivateMode.OFF)
        {
            foreach (Activatable item in Activatables)
            {
                item.ToggleActive(false);
            }
        }
        else if (Mode == ActivateMode.STATETOGGLE)
        {
            foreach (Activatable item in Activatables)
            {
                item.ToggleActive(activated);
            }
        }

        /**
        //Door
        if (activatable.tag == "Door")
        {
            _door.ToggleActive();

        }
        //Elevator
        else if (activatable.tag == "Elevator")
        {
            _elevator.ToggleActive();
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
        /**/
    }
}