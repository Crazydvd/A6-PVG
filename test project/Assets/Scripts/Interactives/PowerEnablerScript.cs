using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerEnablerScript : MonoBehaviour {
    [SerializeField] private bool _enableAir;
    [SerializeField] private bool _enableWater;
    [SerializeField] private bool _enableFire;

    [SerializeField] private GameObject _player;

    public void EnablePowers()
    {
        ShootingScript shootingScript = _player.GetComponent<ShootingScript>();

        if (_enableAir)
            shootingScript.SetAirEnabled(true);
        if (_enableWater)
            shootingScript.SetWaterEnabled(true);
        if (_enableFire)
            shootingScript.SetFireEnabled(true);

        Destroy(gameObject);
    }
}
