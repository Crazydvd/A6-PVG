using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brazier : Activatable
{
    public bool Lit;
    private Activate _activate;

    private void Start()
    {
        _activate = GetComponent<Activate>();
        if (Lit)
        {
            toggleFlame();
        }
    }

    override public void ToggleActive()
    {
        Lit = !Lit;
        _activate.Action();
        toggleFlame();
    }

    override public void ToggleActive(bool pActive)
    {
        if (Lit != pActive)
        {
            _activate.Action();
        }
        Lit = pActive;
        setFlame(pActive);
    }

    private void toggleFlame()
    {
        transform.GetChild(0).gameObject.SetActive(Lit);
    }
    
    private void setFlame(bool pActive)
    {
        transform.GetChild(0).gameObject.SetActive(pActive);
    }
}
