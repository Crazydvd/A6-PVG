using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemLighting : MonoBehaviour
{
    public ShootingScript _shootingScript;

    public LightIntensity _airPush;
    public LightIntensity _water;
    public LightIntensity _fire;
    public LightIntensity _airPull;
    public LightIntensity _ice;
    public LightIntensity _lightning;

    private LightIntensity _currentLight;

    // Use this for initialization
    void Start()
    {
        lightController();
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

    /// <summary>
    /// Automaticly toggles lights on/off and will set the intensity of the current active power to 15
    /// </summary>
    /// <param name="pLight">
    /// The the light whose intensity will be 15
    /// </param>
    public void SetLight(ShootingScript.WeaponMode pLight)
    {
        lightController();
        setCurrentLight(pLight);
        if (_currentLight != null)
        {
            _currentLight.SetIntensity(true);
        }
    }


    /// <summary>
    /// Toggles Lights on and off
    /// </summary>
    private void lightController()
    {
        if (_shootingScript.Air())
        {
            if (_shootingScript.Water())
            {
                if (_shootingScript.Fire())
                {
                    if (_shootingScript.Lit())
                    {
                        _fire.gameObject.SetActive(true);
                        _lightning.gameObject.SetActive(false);
                    }
                    else
                    {
                        _lightning.gameObject.SetActive(true);
                        _fire.gameObject.SetActive(false);
                    }

                    _fire.SetIntensity(false);
                    _lightning.SetIntensity(false);
                }
                else
                {
                    _fire.gameObject.SetActive(false);
                    _lightning.gameObject.SetActive(false);
                }

                if (_shootingScript.Lit())
                {
                    _water.gameObject.SetActive(true);
                    _ice.gameObject.SetActive(false);
                }
                else
                {
                    _ice.gameObject.SetActive(true);
                    _water.gameObject.SetActive(false);
                }

                _water.SetIntensity(false);
                _ice.SetIntensity(false);
            }
            else
            {
                _water.gameObject.SetActive(false);
                _ice.gameObject.SetActive(false);
                _fire.gameObject.SetActive(false);
                _lightning.gameObject.SetActive(false);
            }

            if (_shootingScript.Lit())
            {
                _airPush.gameObject.SetActive(true);
                _airPull.gameObject.SetActive(false);
            }
            else
            {
                _airPull.gameObject.SetActive(true);
                _airPush.gameObject.SetActive(false);
            }

            _airPush.SetIntensity(false);
            _airPull.SetIntensity(false);
        }
        else
        {
            _airPush.gameObject.SetActive(false);
            _airPull.gameObject.SetActive(false);
            _water.gameObject.SetActive(false);
            _ice.gameObject.SetActive(false);
            _fire.gameObject.SetActive(false);
            _lightning.gameObject.SetActive(false);
        }
    }
}
