using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOnOff : Activatable
{
    public override void ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public override void ToggleActive(bool pActive)
    {
        gameObject.SetActive(pActive);
    }
}
