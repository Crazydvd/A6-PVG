using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brazier : MonoBehaviour
{
    public bool Lit;
    private Activate _activate;

    private void Start()
    {
        _activate = GetComponent<Activate>();
        if (Lit)
        {
            _activate.Action();
        }
    }

    public void ToggleActive()
    {
        Lit = !Lit;
        _activate.Action();
        transform.GetChild(0).gameObject.SetActive(Lit);
    }


    //public void Light()
    //{
    //    Lit = true;
    //    _activate.Action();
    //    transform.GetChild(0).gameObject.SetActive(true);
    //}

    //public void Extinguish()
    //{
    //    Lit = false;
    //    _activate.Action();
    //    transform.GetChild(0).gameObject.SetActive(false);
    //}
}
