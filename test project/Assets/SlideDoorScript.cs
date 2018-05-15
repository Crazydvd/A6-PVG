using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlideDoorScript : MonoBehaviour {

    private float topMovement = 0f;
    private Dictionary<Vector3, float> Doors = new Dictionary<Vector3, float>();

    private void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, topMovement, transform.localPosition.z);
    }

    public void SetDoorPosition(Vector3 door, float doorPosition)
    {

        if (Doors.ContainsKey(door))
        {
            Doors[door] = doorPosition;
        }
        else
        {
            Doors.Add(door, doorPosition);
        }
        topMovement = Doors.Select(x => x.Value).Max();

    }
}
