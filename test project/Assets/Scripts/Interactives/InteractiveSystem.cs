using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveSystem : MonoBehaviour
{
    public List<GameObject> Activatables = new List<GameObject>();
    public List<GameObject> Deactivatables = new List<GameObject>();
    private bool _opened;

    void Update()
    {       
        if (!_opened)
        {
            foreach (GameObject activatable in Activatables)
            {
                if (!activatable.GetComponent<Activate>().activated)
                    return;
            }

            foreach (GameObject deactivatable in Deactivatables)
            {
                if (deactivatable.GetComponent<Activate>().activated)
                    return;
            }

            GetComponent<Activate>().Action();
            _opened = !_opened;
        }
    }
}
