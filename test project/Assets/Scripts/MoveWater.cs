using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWater : MonoBehaviour
{
    public GameObject NewPosition;

    private Vector3 _oldPosition;
    private Vector3 _newPositon;

    private float _value;
    [Tooltip("The amount in seconds it takes the water to rise to the new position.")]
    [SerializeField] private float _speed = 1;

    private void Start()
    {
        _oldPosition = transform.position;
        _newPositon = NewPosition.transform.position;
        NewPosition.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad5))
        {
            //MoveWaterUp(0.1f);
            MoveUp();
        }
        else if (Input.GetKey(KeyCode.Keypad2))
        {
            //MoveWaterDown(0.1f);
            MoveDown();
        }
    }

    public void MoveWaterUp(float pAmount)
    {
        transform.position = transform.position + new Vector3(0, pAmount, 0);
    }

    public void MoveWaterDown(float pAmount)
    {
        transform.position = transform.position + new Vector3(0, -pAmount, 0);
    }

    public void MoveUp()
    {
        if (_value < 1)
        {
            _value += _speed * Time.deltaTime;
            float newY = Mathf.Lerp(_oldPosition.y, _newPositon.y, _value);
            transform.position = new Vector3(_oldPosition.x, newY, _oldPosition.z);
        }
        else
        {
            _value = 1;
        }
    }

    public void MoveDown()
    {
        if (_value > 0)
        {
            _value -= _speed * Time.deltaTime;
            float newY = Mathf.Lerp(_oldPosition.y, _newPositon.y, _value);
            transform.position = new Vector3(_oldPosition.x, newY, _oldPosition.z);
        }
        else
        {
            _value = 0;
        }
    }
}