using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemLighting : MonoBehaviour
{
    /// <summary>
    /// use the weaponMode enum from shootingScript
    /// use a list of lights and remove the current mode light
    /// go through list and set all to normal
    /// set current mode light to new
    /// </summary>

    ShootingScript _shootingScript;
    ShootingScript.WeaponMode _weaponMode;

    private LightIntensity _airPush;
    private LightIntensity _water;
    private LightIntensity _fire;
    private LightIntensity _airPull;
    private LightIntensity _ice;
    private LightIntensity _lightning;

    private LightIntensity _currentLight;

    public List<LightIntensity> Lights = new List<LightIntensity>();

    // Use this for initialization
    void Start()
    {
        _shootingScript = GetComponentInParent<ShootingScript>();
        _weaponMode = _shootingScript._weaponMode;

        _airPush = Lights[0];
        _water = Lights[1];
        _fire = Lights[2];
        _airPull = Lights[3];
        _ice = Lights[4];
        _lightning = Lights[5];

        setCurrentLight(_weaponMode);
    }

    private void setCurrentLight(ShootingScript.WeaponMode pWeaponMode)
    {
        switch (pWeaponMode)
        {
            case ShootingScript.WeaponMode.NONE:
                _currentLight = null;
                break;
            case ShootingScript.WeaponMode.AIR:
                _currentLight = _airPush;
                break;
            case ShootingScript.WeaponMode.WATER:
                _currentLight = _water;
                break;
            case ShootingScript.WeaponMode.FIRE:
                _currentLight = _fire;
                break;
            case ShootingScript.WeaponMode.SUCTION:
                _currentLight = _airPull;
                break;
            case ShootingScript.WeaponMode.ICE:
                _currentLight = _ice;
                break;
            case ShootingScript.WeaponMode.LIGHTNING:
                _currentLight = _lightning;
                break;
        }
    }

    public void SetLight(ShootingScript.WeaponMode pLight)
    {
        if (!Lights.Contains(_currentLight))
        {
            Lights.Add(_currentLight);
        }
    }
}
