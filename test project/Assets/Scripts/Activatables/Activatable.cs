using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activatable : MonoBehaviour
{
    public abstract void ToggleActive();

    public abstract void ToggleActive(bool pActive);
}
