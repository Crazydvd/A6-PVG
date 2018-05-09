using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            transform.position = transform.position + new Vector3(0, 0.1f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            transform.position = transform.position + new Vector3(0, -0.1f, 0);
        }
    }
}