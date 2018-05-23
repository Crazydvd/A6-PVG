using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour {

    [Header("UI Element")]
    [SerializeField] private GameObject _note;
    [SerializeField] private AudioClip _noteSound;
    [SerializeField] private AudioSource _audioSource;

    private bool _reading = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_reading)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Invoke("CloseNote", 0.000001f);
            }
        }
    }

    private void startReading()
    {
        _reading = true;
    }

    public void ReadNote()
    {
        if (!_reading)
        {
            _note.SetActive(true);
            _audioSource.PlayOneShot(_noteSound);
            Invoke("startReading", 0.000001f);
        }
    }

    public void CloseNote()
    {
        _note.SetActive(false);
        _reading = false;
    }
}
