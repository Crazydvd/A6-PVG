using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public enum WeaponMode
    {
        NONE,
        AIR,            //Light
        WATER,          //Light
        FIRE,           //Light
        SUCTION,         //Dark
        ICE,            //Dark
        LIGHTNING,      //Dark
    }

    [Header("References")]
    public GameObject IceCone;
    public GameObject Lightning;
    public GameObject AirBall;
    public GameObject FireBall;
    public GameObject WaterBall;
    public Transform ShootingPoint;

    [SerializeField] private GameObject lightningHitParticles;

    [HideInInspector] public WeaponMode _weaponMode = WeaponMode.SUCTION;

    [Header("Powers Enabled")]
    [SerializeField] private float _suctionPower = 1000f;
    [SerializeField] private float _suctionRange = 5f;

    [SerializeField] private bool _airEnabled = true;
    [SerializeField] private bool _waterEnabled = true;
    [SerializeField] private bool _fireEnabled = true;

    [SerializeField] private bool DEBUGGING = false;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip _airBlowSound;
    [SerializeField] private AudioClip _waterSound;
    [SerializeField] private AudioClip _fireSound;

    [SerializeField] private AudioClip _airPullSound;
    [SerializeField] private AudioClip _iceSound;
    [SerializeField] private AudioClip _lightningSound;

    [SerializeField] private AudioClip _lightToggleSound;


    public GemLighting[] _gems;

    private bool _inLight = false;
    private int _lightLevel;

    private AudioSource _audioSource;
    private KeyCode[] _actionButtons = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6 };

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (_airEnabled)
        {
            _weaponMode = WeaponMode.AIR;
            ToggleMode();
        }
        else
        {
            _weaponMode = WeaponMode.NONE;
        }
    }

    private void FixedUpdate()
    {
        _lightLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // check if the player is shooting
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            DEBUGGING = !DEBUGGING;
            Debug.Log("Debugging is: " + DEBUGGING);
        }

        // check if the projectile is being changed
        if (Input.GetKeyDown(KeyCode.Alpha1) && _airEnabled)
        {
            ChangeMode(KeyCode.Alpha1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && _waterEnabled)
        {
            ChangeMode(KeyCode.Alpha2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && _fireEnabled)
        {
            ChangeMode(KeyCode.Alpha3);
        }

        // ALLOW EVERY POWER IN DEBUG MODE
        if (DEBUGGING)
        {
            foreach (KeyCode button in _actionButtons)
            {
                if (Input.GetKeyDown(button))
                {
                    ChangeMode(button);
                }
            }
        }
    }

    private void LateUpdate()
    {
        bool light = _inLight;
        if (_lightLevel <= 0)
        {
            _inLight = false;
        }
        else
        {
            _inLight = true;
        }

        if (light != _inLight)
        {
            ToggleMode();
        }
    }


    // check if the player is standing in light
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Light")
        {
            _lightLevel++;
            RaycastHit hit;
            if (Physics.Raycast(other.transform.position, transform.position - other.transform.position, out hit))
            {
                if (hit.transform.tag != "Player")
                {
                    _lightLevel--;
                    Debug.DrawRay(other.transform.position, transform.position - other.transform.position, Color.red, 0, false);
                }
                else
                {
                    Debug.DrawRay(other.transform.position, transform.position - other.transform.position, Color.green, 0, true);
                }

                if (Input.GetKey(KeyCode.Tab))
                {
                    Debug.Log("name = " + hit.collider.name);
                    Debug.Log("tag = " + hit.collider.tag);
                    Debug.Log("position = " + hit.collider.transform.position);
                }
            }
        }
    }

    private void Shoot()
    {

        // shoot projectiles
        switch (_weaponMode)
        {
            case WeaponMode.WATER:
                GameObject newWaterball = Instantiate(WaterBall, ShootingPoint.position, Quaternion.FromToRotation(Vector3.right, ShootingPoint.transform.forward));
                newWaterball.GetComponent<Rigidbody>().AddForce(ShootingPoint.transform.forward * 1000f);
                Destroy(newWaterball, 10f);
                break;
            case WeaponMode.ICE:
                RaycastHit hitz;
                Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
                Vector3 IceDirection = Vector3.zero;
                if (Physics.Raycast(ray, out hitz))
                {
                    IceDirection = hitz.point - ShootingPoint.position;
                }
                else
                {
                    IceDirection = ray.GetPoint(100f) - ShootingPoint.position;
                }
                GameObject newIceCone = Instantiate(IceCone, ShootingPoint.position, Quaternion.FromToRotation(Vector3.forward, IceDirection));
                newIceCone.GetComponent<Rigidbody>().AddForce(IceDirection.normalized * 1000f);
                Destroy(newIceCone, 10f);
                break;
            case WeaponMode.FIRE:
                GameObject newFireball = Instantiate(FireBall, ShootingPoint.position, Quaternion.FromToRotation(Vector3.right, ShootingPoint.transform.forward));
                newFireball.GetComponent<Rigidbody>().AddForce(ShootingPoint.transform.forward * 1000f);
                Destroy(newFireball, 10f);
                break;
            case WeaponMode.LIGHTNING:
                RaycastHit hit;
                Ray LightningRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
                if (Physics.Raycast(LightningRay, out hit, 100f))
                {
                    Vector3 direction = (hit.point - ShootingPoint.position);
                    int distance = 2;
                    for (int i = 0; i < direction.magnitude; i += distance)
                    {
                        GameObject newLightning = Instantiate(Lightning, ShootingPoint.position + direction.normalized * i, Quaternion.FromToRotation(Vector3.up, -direction));
                        Destroy(newLightning, 0.5f);
                    }

                    // Create particle on hit
                    GameObject hitParticleEffect = Instantiate(lightningHitParticles, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                    Destroy(hitParticleEffect, 0.5f);

                    if (hit.transform.tag == "water")
                    {
                        WaterScript wScript = hit.transform.GetComponent<WaterScript>();
                        if (wScript != null)
                            wScript.Electrocute();
                    }
                    else if (hit.transform.tag == "LightningSwitch")
                    {
                        hit.collider.gameObject.GetComponent<Activate>().Action();
                    }
                }
                break;
            case WeaponMode.AIR:
                GameObject newAirball = Instantiate(AirBall, ShootingPoint.position, Quaternion.FromToRotation(Vector3.forward, Vector3.forward));
                newAirball.GetComponent<Rigidbody>().AddForce(ShootingPoint.transform.forward * 1000f);
                Destroy(newAirball, 10f);
                break;
            case WeaponMode.SUCTION:
                RaycastHit suctionHit;
                Ray suctionRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
                if (Physics.Raycast(suctionRay, out suctionHit, _suctionRange))
                {
                    Vector3 retractionDirection = (transform.position - suctionHit.point);
                    retractionDirection.y = 0; // remove upwards/downwards force
                    if (suctionHit.transform.tag == "Cube")
                    {
                        suctionHit.rigidbody.AddForce(retractionDirection.normalized * _suctionPower);
                    }
                }
                break;
        }
        playSound();
    }

    // Check if the player is in the light and change the weapons mode accordingly
    private void ToggleMode()
    {
        ///Light:
        ///WATER
        ///FIRE
        ///AIR
        ///
        ///Dark:
        ///ICE
        ///LIGHTNING
        ///SUCTION
        ///

        if (_inLight)
        {
            switch (_weaponMode)
            {
                case WeaponMode.ICE:
                    _weaponMode = WeaponMode.WATER;
                    break;
                case WeaponMode.LIGHTNING:
                    _weaponMode = WeaponMode.FIRE;
                    break;
                case WeaponMode.SUCTION:
                    _weaponMode = WeaponMode.AIR;
                    break;
            }
        }
        else
        {
            switch (_weaponMode)
            {
                case WeaponMode.WATER:
                    _weaponMode = WeaponMode.ICE;
                    break;
                case WeaponMode.FIRE:
                    _weaponMode = WeaponMode.LIGHTNING;
                    break;
                case WeaponMode.AIR:
                    _weaponMode = WeaponMode.SUCTION;
                    break;
            }
        }

        foreach (GemLighting item in _gems)
        {
            item.SetLight(_weaponMode);
        }

        _audioSource.PlayOneShot(_lightToggleSound);
    }

    private void ChangeMode(KeyCode button)
    {
        switch (button)
        {
            case KeyCode.Alpha1:
                _weaponMode = WeaponMode.AIR;
                break;
            case KeyCode.Alpha2:
                _weaponMode = WeaponMode.WATER;
                break;
            case KeyCode.Alpha3:
                _weaponMode = WeaponMode.FIRE;
                break;
            case KeyCode.Alpha4:
                _weaponMode = WeaponMode.SUCTION;
                break;
            case KeyCode.Alpha5:
                _weaponMode = WeaponMode.ICE;
                break;
            case KeyCode.Alpha6:
                _weaponMode = WeaponMode.LIGHTNING;
                break;
        }

        if (!DEBUGGING)
        {
            ToggleMode();
        }
    }

    private void playSound()
    {
        switch (_weaponMode)
        {
            case WeaponMode.WATER:
                _audioSource.PlayOneShot(_waterSound);
                break;
            case WeaponMode.FIRE:
                _audioSource.PlayOneShot(_fireSound);
                break;
            case WeaponMode.AIR:
                _audioSource.PlayOneShot(_airBlowSound);
                break;
            case WeaponMode.ICE:
                _audioSource.PlayOneShot(_iceSound);
                break;
            case WeaponMode.LIGHTNING:
                _audioSource.PlayOneShot(_lightningSound);
                break;
            case WeaponMode.SUCTION:
                _audioSource.PlayOneShot(_airPullSound);
                break;
            }
    }

    public void SetAirEnabled(bool enabled)
    {
        _airEnabled = enabled;
        _weaponMode = WeaponMode.AIR;
        ToggleMode();
    }

    public void SetWaterEnabled(bool enabled)
    {
        _waterEnabled = enabled;
        _weaponMode = WeaponMode.WATER;
        ToggleMode();
    }

    public void SetFireEnabled(bool enabled)
    {
        _fireEnabled = enabled;
        _weaponMode = WeaponMode.FIRE;
        ToggleMode();
    }

    public bool Air()
    {
        return _airEnabled;
    }

    public bool Water()
    {
        return _waterEnabled;
    }

    public bool Fire()
    {
        return _fireEnabled;
    }

    public bool Lit()
    {
        return _inLight;
    }

    public void SetAir(bool enabled)
    {
        _airEnabled = enabled;
    }

    public void SetWater(bool enabled)
    {
        _waterEnabled = enabled;
    }

    public void SetFire(bool enabled)
    {
        _fireEnabled = enabled;
    }
}