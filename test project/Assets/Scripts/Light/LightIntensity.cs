using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour
{
    private Light _light;

    public float NormalIntensity;
    public float NewIntensity;

    private bool _normal;

    // Use this for initialization
    void Start()
    {
        _normal = true;
        _light = GetComponent<Light>();
    }

    public void ToggleIntensity()
    {
        if (_normal)
        {
            _light.intensity = NewIntensity;
        }
        else
        {
            _light.intensity = NormalIntensity;
        }
        _normal = !_normal;
    }

    public void SetIntensity(bool pBrighter)
    {
        _normal = !pBrighter;

        if (_normal)
        {
            _light.intensity = NormalIntensity;
        }
        else
        {
            _light.intensity = NewIntensity;
        }
    }
}