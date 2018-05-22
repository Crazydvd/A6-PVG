using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : Activatable
{
    public bool _closed = true;
    [HideInInspector] public bool InProgress = false;
    private AudioSource _audioSource;

    private float _originalYposition;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _originalYposition = transform.localPosition.y;
    }

    void Update()
    {
        if (_closed)
        {
            if (transform.localPosition.y > _originalYposition)
            {
                transform.position = transform.position - new Vector3(0, 0.05f, 0);
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
                transform.position = transform.position + new Vector3(0, 0.05f, 0);
                InProgress = true;
            }
            else
            {
                InProgress = false;
            }
        }
    }

    override public void ToggleActive()
    {
        _closed = !_closed;
        playSound();
    }

    private void playSound()
    {
        switch (_closed)
        {
            case true:

                break;
            case false:
                _audioSource.Play();
                break;
        }
    }

    override public void ToggleActive(bool pActive)
    {
        _closed = pActive;
    }
}