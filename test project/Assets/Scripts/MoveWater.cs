using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWater : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            MoveWaterUp(0.1f);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            MoveWaterDown(-0.1f);
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
}