using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool _closed = true;
    [HideInInspector] public bool InProgress = false;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (_closed)
        {
            if (transform.localPosition.y > 0)
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

    public void ToggleActive()
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

    //public void Open()
    //{
    //    _closed = false;
    //}

    //public void Close()
    //{
    //    _closed = true;
    //}
}