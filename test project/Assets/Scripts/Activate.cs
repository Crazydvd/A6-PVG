using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    private bool activated;
    public GameObject door;

    public void ActivateObject()
    {
        activated = !activated;
        Debug.Log(activated);
        door.GetComponentInChildren<OpenDoor>().Open();
    }
}
