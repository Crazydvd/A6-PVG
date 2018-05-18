using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlideDoorScript : MonoBehaviour
{
    private float topMovement = 0f;
    private Dictionary<Vector3, float> Wheels = new Dictionary<Vector3, float>();

    private void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, topMovement, transform.localPosition.z);
    }

    public void SetDoorPosition(Vector3 wheel, float doorPosition)
    {

        if (Wheels.ContainsKey(wheel))
        {
            Wheels[wheel] = doorPosition;
        }
        else
        {
            Wheels.Add(wheel, doorPosition);
        }
        topMovement = Wheels.Select(x => x.Value).Max();

    }
}
