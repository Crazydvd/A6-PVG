using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : Activatable
{
    public GameObject FireStream;

    public bool Active = true;

    public Mode _currentMode = Mode.INTERVAL;

    [Tooltip("If mode is INTERVAL, the amount of seconds it takes to shoot again")]
    public float Seconds = 5f;

    [Tooltip("If mode is INTERVAL, the amount of seconds it takes for the fire to dissapear")]
    public float FireTime = 5f;

    private float _coolDown;

    public enum Mode
    {
        INTERVAL,
        TOGGLE,
    }

    private void Update()
    {
        if (Time.timeScale == 0)
            return;

        if (_currentMode == Mode.TOGGLE)
        {
            if (Active)
            {
                shoot();
            }
            else
            {
                stopShooting();
            }
        }
        else
        {
            if (Active)
            {
                if (_coolDown <= 0)
                {
                    shoot();
                    _coolDown = Seconds;
                }
                else
                {
                    _coolDown -= Time.deltaTime;
                }
            }
            else
            {
                stopShooting();
            }
        }
    }

    private void shoot()
    {
        FireStream.SetActive(true);
        Invoke("stopShooting", FireTime);
    }

    private void stopShooting()
    {
        FireStream.SetActive(false);
    }

    public override void ToggleActive()
    {
        Active = !Active;
    }

    public override void ToggleActive(bool pActive)
    {
        Active = pActive;
    }
}
