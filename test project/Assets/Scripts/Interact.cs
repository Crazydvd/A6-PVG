using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Interact : MonoBehaviour
{
    [SerializeField] float SlowedWalkingSpeed = 3;
    [SerializeField] float SlowedRunningSpeed = 4;

    private GameObject _heldObject;
    private FirstPersonController _playerController;

    void Start()
    {
        _playerController = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
            {
                // LEVER
                if (hit.collider.tag == "Lever")
                {
                    Activate lever = hit.collider.GetComponent<Activate>();

                    if (!lever.activated)
                        lever.OpenDoor();
                    else
                        lever.CloseDoor();

                    lever.Animation();
                }

                // CUBE
                if (hit.collider.tag == "Cube")
                {
                    _heldObject = hit.collider.gameObject;
                    hit.transform.parent = transform;
                    _playerController.SetSpeed(SlowedWalkingSpeed, SlowedRunningSpeed);
                }
            }
        }

        // Release object
        if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            if(_heldObject != null)
            {
                _heldObject.transform.parent = null;
                _heldObject = null;
                _playerController.ResetSpeed();
            }
        }

    }
}
