using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
            {
                if (hit.collider.tag == "Lever")
                {
                    Activate lever = hit.collider.GetComponent<Activate>();

                    if (!lever.activated)
                        lever.OpenDoor();
                    else
                        lever.CloseDoor();

                    lever.Animation();
                }
            }
        }

    }
}
