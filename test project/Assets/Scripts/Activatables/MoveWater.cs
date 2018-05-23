using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWater : Activatable
{
    public GameObject NewPosition;

    private Vector3 _oldPosition;
    private Vector3 _newPositon;

    private float _value;
    [Tooltip("The amount in seconds it takes the water to rise to the new position.")]
    [SerializeField] private float _speed = 1;
    private bool _raised;

    [HideInInspector] public bool InProgress;

    private void Start()
    {
        _oldPosition = transform.position;
        _newPositon = NewPosition.transform.position;
        NewPosition.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;

        if (_raised)
        {
            MoveUp();
        }
        else
        {
            MoveDown();
        }
    }

    public void MoveUp()
    {
        if (_value < 1)
        {
            InProgress = true;
            _value += _speed * Time.deltaTime;
            float newY = Mathf.Lerp(_oldPosition.y, _newPositon.y, _value);
            transform.position = new Vector3(_oldPosition.x, newY, _oldPosition.z);
        }
        else
        {
            _value = 1;
            InProgress = false;
        }
    }

    public void MoveDown()
    {
        if (_value > 0)
        {
            InProgress = true;
            _value -= _speed * Time.deltaTime;
            float newY = Mathf.Lerp(_oldPosition.y, _newPositon.y, _value);
            transform.position = new Vector3(_oldPosition.x, newY, _oldPosition.z);
        }
        else
        {
            _value = 0;
            InProgress = false;
        }
    }

    override public void ToggleActive()
    {
        _raised = !_raised;
    }

    override public void ToggleActive(bool pActive)
    {
        _raised = pActive;
    }
}