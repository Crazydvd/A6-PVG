﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    [SerializeField] float SlowedWalkingSpeed = 3;
    [SerializeField] float SlowedRunningSpeed = 4;

    [SerializeField] Image Crosshair;
    [SerializeField] Text InteractableUI;

    private GameObject _heldObject;
    private bool _holdingObject;
    private FirstPersonController _playerController;

    void Start()
    {
        _playerController = GetComponent<FirstPersonController>();
        _holdingObject = false;
    }

    void Update()
    {
        // Release object
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_heldObject != null)
            {
                Invoke("ReleaseObject", 0.0001f);
                ReleaseObject();
            }
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // LEVER
                if (hit.collider.tag == "Lever")
                {
                    Activate lever = hit.collider.GetComponent<Activate>();

                    lever.Action();

                    //lever.Animation(); moved to activate
                }

                // CUBE
                if (hit.collider.tag == "Cube" && !_holdingObject)
                {
                    _heldObject = hit.collider.gameObject;
                    hit.transform.parent = transform;
                    _playerController.SetSpeed(SlowedWalkingSpeed, SlowedRunningSpeed);
                    _holdingObject = true;
                }

                if(hit.collider.tag == "Note")
                {
                    NoteScript noteScript = hit.collider.GetComponent<NoteScript>();
                    noteScript.ReadNote();
                }

                if(hit.collider.tag == "PowerEnabler")
                {
                    PowerEnablerScript powerEnablerScript = hit.collider.GetComponent<PowerEnablerScript>();
                    powerEnablerScript.EnablePowers();
                }
            }

            if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {
                if (InteractableUI != null && Crosshair != null)
                {
                    InteractableUI.gameObject.SetActive(true);
                    Crosshair.gameObject.SetActive(false);
                }
            }
            else
            {
                ResetUI();
            }

        }
        else
        {
            ResetUI();
        }

        if (_heldObject != null && (transform.position - _heldObject.transform.position).magnitude > 4f) {
            ReleaseObject();
        }
    }

    public void ReleaseObject()
    {
        if (_heldObject != null)
        {
            _heldObject.transform.parent = null;
            _heldObject = null;
        }
        _playerController.ResetSpeed();
        _holdingObject = false;
    }

    private void ResetUI()
    {
        if (InteractableUI != null && Crosshair != null)
        {
            InteractableUI.gameObject.SetActive(false);
            Crosshair.gameObject.SetActive(true);
        }
    }
}
