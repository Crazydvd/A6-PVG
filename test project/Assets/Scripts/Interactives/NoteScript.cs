using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour {

    [Header("UI Element")]
    [SerializeField] private GameObject Note;

    private bool _reading = false;

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
            Note.SetActive(true);
            Invoke("startReading", 0.000001f);
        }
    }

    public void CloseNote()
    {
        Note.SetActive(false);
        _reading = false;
    }
}
