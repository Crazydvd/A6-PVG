using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private bool _closed = true;
    [HideInInspector] public bool InProgress = false;

    void Update()
    {
        if (_closed)
        {
            if (transform.localPosition.y > 0)
            {
                transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z), Quaternion.Euler(0, 0, 90));
                InProgress = true;
            }
            else
            {
                InProgress = false;
            }
        }
        else
        {
            if (transform.localPosition.y < 4)
            {
                transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z), Quaternion.Euler(0, 0, 90));
                InProgress = true;
            }
            else
            {
                InProgress = false;
            }
        }
    }

    public void Open()
    {
        _closed = !_closed;
    }
}